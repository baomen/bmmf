using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Util;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BaoMen.Demo.AdminWebApi.Utils
{
    /// <summary>
    /// 当前用户
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserManager userManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="userManager">系统用户业务逻辑</param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserManager userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public IUser GetCurrentUser()
        {
            Claim claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null) return null;
            return userManager.Get(claim.Value);
        }
    }
}
