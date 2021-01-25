using AutoMapper;
using BaoMen.Common.Data;
using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Web.Util;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;
using Model = BaoMen.MultiMerchant.Web.Merchant.Models;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户用户
    /// </summary>
    [ApiExplorerSettings(GroupName = "merchant")]
    public abstract class UserController : MerchantBaseController<string, Entity.User, Entity.UserFilter, Model.User, Model.CreateUser, Model.UpdateUser, Model.DeleteUser, IUserManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public UserController(IUserManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }

        /// <summary>
        /// 获取单个商户用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<Model.UserDetail> Get([FromQuery] string id)
        {
            return DoGet<Model.UserDetail>(id);
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
                if (entity == null)
                {
                    throw new ArgumentException("商户用户不存在");
                }
                responseData.Data = manager.ResetPassword(entity);
            }
            catch (BusinessLogicException businessLogicException)
            {
                responseData.Exception = businessLogicException;
                responseData.ErrorNumber = 1002;
                responseData.ErrorMessage = Properties.Resources.Error_1002;
                logger.Error(responseData);
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = Properties.Resources.Error_1000;
                logger.Error(responseData);
            }
            return responseData;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="filter">过滤器</param>
        /// <returns></returns>
        [HttpGet]
        public virtual ResponseData<int> GetListCount([FromQuery]Entity.UserFilter filter)
        {
            return DoGetListCount(filter);
        }

        /// <summary>
        /// 获取商户用户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<ICollection<TextValue<string>>> GetOptions([FromQuery]Entity.UserFilter filter)
        {
            filter.Status = 1;
            return DoGetList<TextValue<string>>(filter);
        }

        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseData<bool> ValidateMobile(string mobile)
        {
            ResponseData<bool> responseData = new ResponseData<bool>();
            try
            {
                if (string.IsNullOrEmpty(mobile) || mobile.Length != 11)
                {
                    responseData.ErrorNumber = 1005;
                    responseData.ErrorMessage = Properties.Resources.Error_1005;
                }
                else
                {
                    Entity.User user = manager.GetByMobile(mobile);
                    responseData.Data = user == null;
                }
            }
            catch (Exception exception)
            {
                responseData.Exception = exception;
                responseData.ErrorNumber = 1000;
                responseData.ErrorMessage = Properties.Resources.Error_1000;
            }
            return responseData;
        }
    }
}
