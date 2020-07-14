using AutoMapper;
using BaoMen.Common.Data;
using BaoMen.Common.Extension;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entity = BaoMen.MultiMerchant.System.Entity;

namespace BaoMen.Demo.AdminWebApi.System.Controllers
{
    /// <summary>
    /// 系统用户
    /// </summary>
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    //[ApiVersionNeutral] //忽略版本
    //[Route("api/v{version:apiVersion}/system/[controller]/[action]")]
    [Route("api/system/[controller]/[action]")]
    
    public class UserController : MultiMerchant.Web.Util.BaseController<string, Entity.User, Entity.UserFilter, MultiMerchant.Web.System.Models.User, MultiMerchant.Web.System.Models.CreateUser, MultiMerchant.Web.System.Models.UpdateUser, MultiMerchant.Web.System.Models.DeleteUser, IUserManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public UserController(IUserManager manager, IMapper mapper) : base(manager, mapper)
        {
        }

        #region Authentication & Authorization
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginRequest">登录请求参数</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ResponseData<MultiMerchant.Web.System.Models.TokenResponse> Login(MultiMerchant.Web.System.Models.LoginRequest loginRequest)
        {
            ResponseData<MultiMerchant.Web.System.Models.TokenResponse> responseData = new ResponseData<MultiMerchant.Web.System.Models.TokenResponse>();
            try
            {
                if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
                {
                    responseData.ErrorNumber = 10001;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10001;
                    return responseData;
                }
                Entity.User user = manager.GetList(new Entity.UserFilter { UserName = loginRequest.UserName }).FirstOrDefault();
                Entity.UserLoginHistory userLoginHistory = new Entity.UserLoginHistory
                {
                    UserAgent = Request.Headers["User-Agent"],
                    ClientIp = this.GetClientIp(),
                    ServerIp = this.GetServerIp(),
                    Type = this.GetBorwserType(),
                    UserName = loginRequest.UserName
                };
                if (user == null)
                {
                    userLoginHistory.Result = 2;
                    responseData.ErrorNumber = 10002;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10002;
                }
                else if (user.Password != loginRequest.Password.To32MD5())
                {
                    userLoginHistory.Result = 3;
                    responseData.ErrorNumber = 10003;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10003;
                }
                else if (user.Status == 0)
                {
                    userLoginHistory.Result = 5;
                    responseData.ErrorNumber = 10007;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10007;
                }
                else
                {
                    userLoginHistory.Result = 1;
                    responseData.Data = CreateAccessToken(user);
                }
                IUserLoginHistoryManager userLoginHistoryManager = HttpContext.RequestServices.GetRequiredService<IUserLoginHistoryManager>();
                userLoginHistoryManager.Insert(userLoginHistory);
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
            }
            return responseData;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseData Logout()
        {
            ResponseData responseData = new ResponseData();
            try
            {
                Entity.User user = DoGetCurrentUser();
                manager.ExpireToken(user.Id);
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                logger.Error(exception);
            }
            return responseData;
        }

        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="refreshToken">刷新用的令牌</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseData<MultiMerchant.Web.System.Models.TokenResponse> RefreshToken(string refreshToken)
        {
            ResponseData<MultiMerchant.Web.System.Models.TokenResponse> responseData = new ResponseData<MultiMerchant.Web.System.Models.TokenResponse>();
            try
            {
                string token = string.Empty;
                try
                {
                    IConfiguration configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                    token = refreshToken.DecryptAES(configuration["Jwt:SecurityKey"]);
                }
                catch
                {

                }
                Entity.UserToken userToken = manager.GetUserToken(token);
                if (userToken == null)
                {
                    responseData.ErrorNumber = 10006;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10006;
                }
                else if (userToken.Expires < DateTime.Now)
                {
                    responseData.ErrorNumber = 10005;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10005;
                }
                else
                {
                    Entity.User user = manager.Get(userToken.UserId);
                    responseData.Data = CreateAccessToken(user);
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = exception.Message;
            }
            return responseData;
        }

        /// <summary>
        /// 获取刷新用的令牌
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<MultiMerchant.Web.System.Models.TokenResponse> GetRefreshToken()
        {
            ResponseData<MultiMerchant.Web.System.Models.TokenResponse> responseData = new ResponseData<MultiMerchant.Web.System.Models.TokenResponse>();
            try
            {
                Claim claim = User.FindFirst(ClaimTypes.NameIdentifier);
                IConfiguration configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                string token = Guid.NewGuid().ToString("N");
                _ = int.TryParse(configuration["Jwt:RefreshTokenExpires"], out int expires);
                Entity.UserToken userToken = new Entity.UserToken
                {
                    UserId = claim.Value,
                    Expires = DateTime.Now.AddSeconds(expires),
                    Token = token
                };
                if (manager.UpdateUserToken(userToken) == 1)
                {
                    responseData.Data = new MultiMerchant.Web.System.Models.TokenResponse
                    {
                        Token = token.EncryptAES(configuration["Jwt:SecurityKey"]),
                        Expires = expires
                    };
                }
                else
                {
                    responseData.ErrorNumber = 1001;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1001;
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = exception.Message;
            }
            return responseData;
        }


        /// <summary>
        /// 获取系统用户的Token
        /// </summary>
        /// <param name="user">系统用户实例</param>
        /// <returns></returns>
        private MultiMerchant.Web.System.Models.TokenResponse CreateAccessToken(Entity.User user)
        {
            // push the user’s name into a claim, so we can identify the user later on.
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name, user.Name)
            };
            //不同操作的ModuleId存入Claim
            //List<string> moduleIds = new List<string>();
            //foreach (Entity.Role role in user.Roles)
            //{
            //    moduleIds.AddRange(role.Modules.Where(p => p.Type == 4 && !string.IsNullOrEmpty(p.Method) && p.Status == 1).Select(p => p.ParentId));
            //}
            //moduleIds.Distinct().ToList().ForEach((id) =>
            //{
            //    claims.Add(new Claim("ModuleId", id));
            //});

            IConfiguration configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"])); // 获取密钥
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //凭证 ，根据密钥生成

            //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
            /*
                * Claims (Payload)
                Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:

                iss: The issuer of the token，token 是给谁的  发送者
                aud: 接收的
                sub: The subject of the token，token 主题
                exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                iat: Issued At。 token 创建时间， Unix 时间戳格式
                jti: JWT ID。针对当前 token 的唯一标识
                除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
            */
            _ = int.TryParse(configuration["Jwt:Expires"], out int expires);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(expires),
                signingCredentials: signingCredentials
            );
            return new MultiMerchant.Web.System.Models.TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = expires
            };
        }

        #endregion

        /// <summary>
        /// 获取当前用户实体
        /// </summary>
        /// <returns></returns>
        protected MultiMerchant.System.Entity.User DoGetCurrentUser()
        {
            MultiMerchant.Util.ICurrentUserService currentUser = GetRequiredService<MultiMerchant.Util.ICurrentUserService>();
            return currentUser.GetCurrentUser() as MultiMerchant.System.Entity.User;
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<MultiMerchant.Web.System.Models.User> GetCurrentUser()
        {
            ResponseData<MultiMerchant.Web.System.Models.User> responseData = new ResponseData<MultiMerchant.Web.System.Models.User>();
            try
            {
                Entity.User entity = DoGetCurrentUser();
                if (entity != null)
                {
                    responseData.Data = mapper.Map<MultiMerchant.Web.System.Models.User>(entity);
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
            }
            return responseData;
        }

        //[NonAction]
        //[CapSubscribe("getcurrentuser.success.time")]
        //public void ReceiveMessage(DateTime time)
        //{
        //    logger.Error("message time is:" + time);
        //}
        //[NonAction]
        //[CapSubscribe("BaoMen.Shop.System.User.Updated")]
        //public void ReceiveMessage(Entity.User user)
        //{
        //    logger.Error("BaoMen.Shop.System.User.Updated:" + user);
        //}

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ResponseData<int> GetListCount([FromQuery] Entity.UserFilter filter)
        {
            ResponseData<int> responseData = new ResponseData<int>();
            try
            {
                responseData.Data = manager.GetListCount(filter);
            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                responseData.Exception = exception;
                logger.Error(exception);
            }
            return responseData;
        }

        /// <summary>
        /// 获取商户用户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery] Entity.UserFilter filter)
        {
            return DoGetList<TextValue<string>>(filter);
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        [HttpPut]
        public ResponseData ModifyPassword(string oldPassword, string newPassword)
        {
            ResponseData responseData = new ResponseData();
            try
            {
                Entity.User entity = DoGetCurrentUser();
                if (entity.Password == oldPassword.To32MD5())
                {
                    int rows = manager.ModifyPassword(entity, newPassword);
                    if (rows == 0)
                    {
                        responseData.ErrorNumber = 1002;
                        responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1002;
                    }
                }
                else
                {
                    responseData.ErrorNumber = 10003;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_10003;
                    logger.Warn(responseData);
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                logger.Error(responseData);
            }
            return responseData;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpPut]
        public ResponseData<string> ResetPassword(string id)
        {
            ResponseData<string> responseData = new ResponseData<string>();
            try
            {
                Entity.User entity = manager.Get(id);
                responseData.Data = manager.ResetPassword(entity);
            }
            catch (BusinessLogicException businessLogicException)
            {
                responseData.Exception = businessLogicException;
                responseData.ErrorNumber = 1002;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1002;
                logger.Error(responseData);
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                logger.Error(responseData);
            }
            return responseData;
        }

        /// <summary>
        /// 修改个人设置
        /// </summary>
        /// <param name="item">个人设置实体</param>
        /// <returns></returns>
        [HttpPut]
        public ResponseData<string> UpdateUserPersonalSetting(MultiMerchant.Web.System.Models.UpdateUserPersonalSetting item)
        {
            ResponseData<string> responseData = new ResponseData<string>();
            try
            {
                Entity.User entity = mapper.Map<Entity.User>(item);
                int rows = manager.Update(entity);
                if (rows == 0)
                {
                    responseData.ErrorNumber = 1002;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1002;
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                logger.Error(responseData);
            }
            return responseData;
        }

        /// <summary>
        /// 修改头像,通过Form表单提交
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseData<string> UpdateAvatar(IFormFile file)
        {
            ResponseData<string> responseData = new ResponseData<string>();
            try
            {
                if (file == null)
                {
                    responseData.ErrorNumber = 1000;
                    responseData.ErrorMessage = "文件为空";
                    return responseData;
                }
                Entity.User entity = DoGetCurrentUser();
                int row = manager.UpdateAvatar(entity, file);
                if (row == 0)
                {
                    responseData.ErrorNumber = 1002;
                    responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1002;
                }
                responseData.Data = entity.Avatar;

            }
            catch (Exception exception)
            {
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = MultiMerchant.Web.Properties.Resources.Error_1000;
                responseData.Exception = exception;
                logger.Error(exception);
            }
            return responseData;
        }

        ///// <summary>
        ///// 从Token中获取用户身份
        ///// </summary>
        ///// <param name="token"></param>
        ///// <returns></returns>
        //private ClaimsPrincipal GetPrincipalFromAccessToken(string token)
        //{
        //    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        //    try
        //    {
        //        IConfiguration configuration = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        //        return handler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateAudience = false,
        //            ValidateIssuer = false,
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"])),
        //            ValidateLifetime = false
        //        }, out SecurityToken validatedToken);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[ActionName("GetToken")]
        ////[MapToApiVersion("2.0")]
        //[ApiVersion("1.1")]
        //[ApiExplorerSettings(IgnoreApi = true)] //去掉swagger的api文档
        //public ResponseData<string> GetToken_V2(string userName, string password)
        //{
        //    return new ResponseData<string>()
        //    {
        //        Value = "version 2.0"
        //    };
        //}
    }

    ///// <summary>
    ///// 用户控制器
    ///// </summary>
    //[ApiVersion("2.0")]
    ////[Route("api/v{version:apiVersion}/system/[controller]/[action]")]
    //[Route("api/system/User/[action]")]
    //public class UserController_v2 : BaseController<string, Entity.User, Entity.UserFilter, IUserManager>
    //{
    //    /// <summary>
    //    /// 构造函数
    //    /// </summary>
    //    /// <param name="manager">业务逻辑实例</param>
    //    public UserController_v2(IUserManager manager) : base(manager)
    //    {

    //    }

    //    [AllowAnonymous]
    //    [HttpGet]
    //    public ResponseData<string> GetToken(string userName, string password)
    //    {
    //        return new ResponseData<string>()
    //        {
    //            Value = "version 2.0"
    //        };
    //    }
    //}
}
