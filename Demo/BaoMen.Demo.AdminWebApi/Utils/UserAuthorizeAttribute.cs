using BaoMen.MultiMerchant.System.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using BaoMen.Common.Model;
using Entity = BaoMen.MultiMerchant.System.Entity;
using NLog;

namespace BaoMen.Demo.AdminWebApi.Utils
{
    /// <summary>
    /// 用户授权
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 需要用户授权时调用
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAnonymous = context.ActionDescriptor.EndpointMetadata.Any(a => a is AllowAnonymousAttribute);
            if (isAnonymous) return;

            Claim claim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                //context.Result = new UnauthorizedResult();
                context.Result = new JsonResult(new ResponseData
                {
                    ErrorNumber = 401,
                    ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_401
                });
            }
            else
            {
                if (claim.Value == Constant.RootUserId)
                {
                    //写死了默认管理员
                }
                else
                {
                    IUserManager userManager = context.HttpContext.RequestServices.GetRequiredService<IUserManager>();
                    Entity.User user = userManager.Get(claim.Value);
                    if (user == null)
                    {
                        context.Result = new JsonResult(new ResponseData
                        {
                            ErrorNumber = 401,
                            ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_401
                        });
                    }
                    else
                    {
                        Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor controllerActionDescriptor = context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor;
                        string actionFullName = $"{controllerActionDescriptor.ControllerTypeInfo.FullName}.{controllerActionDescriptor.ActionName}";
                        IModuleManager moduleManager = context.HttpContext.RequestServices.GetRequiredService<IModuleManager>();
                        ICollection<Entity.Module> modules = moduleManager.GetList(new Entity.ModuleFilter { Status = 1, Type = 3, Method = actionFullName });
                        ICollection<string> userModules = user.Roles.SelectMany(role => role.Modules, (p, q) => q.Id).ToList();
                        bool hasPermissioin = modules.Any(p => userModules.Contains(p.ParentId));
                        if (!hasPermissioin)
                        {
                            //context.Result = new ForbidResult();
                            context.Result = new JsonResult(new ResponseData
                            {
                                ErrorNumber = 403,
                                ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_403
                            });
                            logger.Warn($"user {user.UserName} no permission {actionFullName}");
                        }
                    }
                }
            }
        }
    }
}
