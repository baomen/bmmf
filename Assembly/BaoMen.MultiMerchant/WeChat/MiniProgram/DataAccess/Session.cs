/*
Author: WangXinBin
CreateTime: 2020-08-31 19:01:29
*/

using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using BaoMen.Common.Data;
using BaoMen.Common.Model;
using BaoMen.Common.Extension;

namespace BaoMen.MultiMerchant.WeChat.MiniProgram.DataAccess
{
    /// <summary>
    /// 微信小程序登录凭证校验数据访问
    /// </summary>
    #region class Session (generated)
    public partial class Session : DapperDataAccess<Tuple<string, string>, Entity.Session, Entity.SessionFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public Session(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "wx_mp_session"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.Session item)
        {
            string sql = $"INSERT INTO {TableName} (AppId,OpenId,MerchantId,SessionKey,UnionId,CreateTime) VALUES (@AppId,@OpenId,@MerchantId,@SessionKey,@UnionId,@CreateTime)";
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = item
            };
        }

        /// <summary>
        /// 取得更新数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns>
        protected override DapperCommand CreateUpdateCommand(Entity.Session item)
        {
            string sql = $"UPDATE {TableName} SET SessionKey=@SessionKey,UnionId=@UnionId WHERE AppId=@AppId And OpenId=@OpenId And MerchantId=@MerchantId";
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = item
            };
        }

        /// <summary>
        /// 取得删除数据的数据库命令
        /// </summary>
        /// <param name="item">实体实例</param>
        /// <returns></returns>
        protected override DapperCommand CreateDeleteCommand(Entity.Session item)
        {
            string sql = $"DELETE FROM {TableName} WHERE AppId=@AppId And OpenId=@OpenId And MerchantId=@MerchantId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("AppId", item.AppId);
            dynamicParameters.Add("OpenId", item.OpenId);
            dynamicParameters.Add("MerchantId", item.MerchantId);
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = dynamicParameters
            };
        }

        /// <summary>
        /// 创建读取单条数据的数据库命令
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns>数据库命令</returns>
        protected override DapperCommand CreateGetCommand(Tuple<string, string> id)
        {
            if (id == null)
                return null;
            string sql = $"SELECT {TableName}.AppId,{TableName}.OpenId,{TableName}.MerchantId,{TableName}.SessionKey,{TableName}.UnionId,{TableName}.CreateTime FROM {TableName}";
            sql += " WHERE AppId=@AppId And OpenId=@OpenId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("AppId", id.Item1);
            dynamicParameters.Add("OpenId", id.Item2);
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = dynamicParameters
            };
        }

        /// <summary>
        /// 创建过滤器的sql语句及参数
        /// </summary>
        /// <param name="filter">过滤器实例</param>
        /// <returns>where条件及参数</returns>
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.SessionFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.AppId", "AppId", filter.AppId, parameter);
            AddParameter(stringBuilder, $"{TableName}.OpenId", "OpenId", filter.OpenId, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);
            AddParameter(stringBuilder, $"{TableName}.SessionKey", "SessionKey", filter.SessionKey, parameter);
            AddParameter(stringBuilder, $"{TableName}.UnionId", "UnionId", filter.UnionId, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTime", filter.CreateTime, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMin", filter.CreateTimeMin, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMax", filter.CreateTimeMax, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class Session
    {
        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">微信小程序登录凭证</param>
        /// <returns></returns>
        internal int InserOrUpdate(Entity.Session item)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"INSERT INTO {TableName} (AppId,OpenId,MerchantId,SessionKey,UnionId,CreateTime) VALUES (@AppId,@OpenId,@MerchantId,@SessionKey,@UnionId,@CreateTime)";
                sql += $" ON DUPLICATE KEY UPDATE SessionKey=@SessionKey,CreateTime=@CreateTime";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Parameters = item
                };
                IDbConnection connection = CreateConnection();
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties[nameof(item)] = item;
            });
        }
    }
}