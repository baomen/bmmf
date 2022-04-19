using AutoMapper;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using System.Linq;
using BaoMen.Common.Extension;
using BaoMen.MultiMerchant.Util;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class MerchantController : BaseController<string, Entity.Merchant, Entity.MerchantFilter, Models.Merchant, Models.CreateMerchant, Models.UpdateMerchant, Models.DeleteMerchant, IMerchantManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        public MerchantController(IMerchantManager manager, IMapper mapper) : base(manager, mapper)
        {

        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ResponseData<int> GetListCount([FromQuery] Entity.MerchantFilter filter)
        {
            return DoGetListCount(filter);
        }

        /// <summary>
        /// 获取商户选项列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery] Entity.MerchantFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }

        /// <summary>
        /// 获取用户商户列表
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ResponseData<ICollection<Models.Merchant>> GetUserMerchantList([FromQuery] Models.UserMerchantRequest request)
        {
            return Invoke<ICollection<Models.Merchant>>(responseData =>
            {
                if (string.IsNullOrEmpty(request.Mobile) || string.IsNullOrEmpty(request.Password))
                {
                    responseData.ErrorNumber = 10001;
                    responseData.ErrorMessage = Properties.Resources.Error_10001;
                    return;
                }
                IUserManager userManager = GetRequiredService<IUserManager>();
                ICollection<Entity.User> users = userManager.GetListByMobile(request.Mobile);
                string md5Password = request.Password.To32MD5();
                if (!users.Any(p => p.Password == md5Password && p.Status == 1))
                {
                    responseData.ErrorNumber = 10003;
                    responseData.ErrorMessage = Properties.Resources.Error_10003;
                    return;
                }
                responseData.Data = mapper.Map<ICollection<Models.Merchant>>(manager.GetListByMobile(request.Mobile));
            });
        }

        /// <summary>
        /// 获取当前用户商户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<Models.Merchant>> GetCurrentUserMerchantList()
        {
            return Invoke<ICollection<Models.Merchant>>(responseData =>
            {
                ICurrentUserService currentUserService = GetRequiredService<ICurrentUserService>();
                IUserManager userManager = GetRequiredService<IUserManager>();
                Entity.User user = userManager.Get(currentUserService.GetCurrentUser().Id);
                responseData.Data = mapper.Map<ICollection<Models.Merchant>>(manager.GetListByMobile(user.Mobile));
            });
        }
    }
}
