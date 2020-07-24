
/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:32
*/

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using BaoMen.MultiMerchant.WeChat.Pub.Entity;
using BaoMen.Common.Data;

namespace BaoMen.MultiMerchant.WeChat.Pub.BusinessLogic
{
    #region class AuthAccessTokenManager (generated)
    /// <summary>
    /// 微信公众号网页授权凭据业务逻辑
    /// </summary>
    public partial class AuthAccessTokenManager : MultiMerchant.Util.MerchantCacheableBusinessLogicBase<Tuple<string,string>,AuthAccessToken,AuthAccessTokenFilter,DataAccess.AuthAccessToken>,IAuthAccessTokenManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public AuthAccessTokenManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {

        }
        
        /// <summary>
        /// 获取实体标识字段名称
        /// </summary>
        /// <remarks>
        /// <para>默认标识字段不为Id。覆盖此属性</para>
        /// </remarks>
        protected override string IdentityPropertyName
        {
            get { return "ComplexKey"; }
        }
    }
    #endregion
}