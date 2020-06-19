/*
Author: WangXinBin
CreateTime: 2019/10/23 11:49:41
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;
using BaoMen.MultiMerchant.System;
using Microsoft.Extensions.DependencyInjection;
using BaoMen.Common.Constant;
using System.Data;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class OperateHistoryManager (generated)
    /// <summary>
    /// 商户操作日志业务逻辑
    /// </summary>
    public partial class OperateHistoryManager : Util.MerchantBusinessLogicBase<int, OperateHistory, OperateHistoryFilter, DataAccess.OperateHistory>, IOperateHistoryManager
    {
        private readonly System.BusinessLogic.IOperateHistoryManager systemOperateHistoryManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public OperateHistoryManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
            systemOperateHistoryManager = serviceProvider.GetRequiredService<System.BusinessLogic.IOperateHistoryManager>();
        }

        /// <summary>
        /// 插入操作历史
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="relatedId">相关ID</param>
        /// <param name="value">实体实例</param>
        /// <param name="dataOperationType">操作类型</param>
        /// <param name="user">操作人,为空时代表当前操作人</param>
        /// <param name="description">描述信息（可空）</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        public int Insert<T>(string relatedId, T value, DataOperationType dataOperationType, Util.IUser user, string description = null, IDbTransaction transaction = null)
        {
            return ProcessInsert(
                () =>
                {
                    OperateHistory item = new OperateHistory();
                    if (user == null)
                    {
                        Util.ICurrentUserService currentUserService = serviceProvider.GetRequiredService<Util.ICurrentUserService>();
                        user = currentUserService.GetCurrentUser();
                    }
                    if (user == null || string.IsNullOrEmpty(user.Id))
                    {
                        throw new ArgumentNullException("user", "unable to insert operation history");
                    }
                    //如果操作人是商户用户则写入商户操作历史，否则写入系统操作历史
                    if (user is Util.IMerchantUser)
                    {
                        if (value == null)
                            throw new ArgumentNullException("value");

                        Util.IMerchantUser merchantUser = user as Util.IMerchantUser;
                        if (string.IsNullOrEmpty(merchantUser.MerchantId))
                        {
                            throw new ArgumentNullException("merchantId", "unable to insert operation history");
                        }

                        Type type = typeof(T);
                        item.RelatedId = relatedId;
                        item.AssemblyName = type.Assembly.FullName;
                        item.EntityType = type.FullName;
                        item.OperateTime = DateTime.Now;
                        item.Type = (int)dataOperationType;
                        item.Description = description;
                        item.UserId = merchantUser.Id;
                        item.MerchantId = merchantUser.MerchantId;
                        item.Value = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                        return dal.Insert(item, transaction);
                    }
                    else
                    {
                        return systemOperateHistoryManager.Insert(relatedId, value, dataOperationType, user: user);
                    }
                },
                (log) =>
                {
                    log.Properties[nameof(value)] = value;
                    log.Properties[nameof(user)] = user;
                    log.Properties[nameof(relatedId)] = relatedId;
                    log.Properties[nameof(dataOperationType)] = dataOperationType;
                    log.Properties[nameof(description)] = description;
                });
        }
    }
    #endregion
}