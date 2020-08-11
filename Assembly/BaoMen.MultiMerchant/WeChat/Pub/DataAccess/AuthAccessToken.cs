/*
Author: WangXinBin
CreateTime: 2020-07-23 11:07:32
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

namespace BaoMen.MultiMerchant.WeChat.Pub.DataAccess
{
    /// <summary>
    /// 微信公众号网页授权凭据数据访问
    /// </summary>
    #region class AuthAccessToken (generated)
    public partial class AuthAccessToken : DapperDataAccess<Tuple<string, string>, Entity.AuthAccessToken, Entity.AuthAccessTokenFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public AuthAccessToken(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "wx_pub_auth_access_token"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.AuthAccessToken item)
        {
            string sql = $"INSERT INTO {TableName} (AppId,OpenId,MerchantId,AccessToken,RefreshToken,ExpiresIn,Scope,CreateTime,ExpiresTime) VALUES (@AppId,@OpenId,@MerchantId,@AccessToken,@RefreshToken,@ExpiresIn,@Scope,@CreateTime,@ExpiresTime)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.AuthAccessToken item)
        {
            string sql = $"UPDATE {TableName} SET AccessToken=@AccessToken,RefreshToken=@RefreshToken,ExpiresIn=@ExpiresIn,Scope=@Scope,ExpiresTime=@ExpiresTime WHERE AppId=@AppId And OpenId=@OpenId And MerchantId=@MerchantId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.AuthAccessToken item)
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
            string sql = $"SELECT {TableName}.AppId,{TableName}.OpenId,{TableName}.MerchantId,{TableName}.AccessToken,{TableName}.RefreshToken,{TableName}.ExpiresIn,{TableName}.Scope,{TableName}.CreateTime,{TableName}.ExpiresTime FROM {TableName}";
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.AuthAccessTokenFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.AppId", "AppId", filter.AppId, parameter);
            AddParameter(stringBuilder, $"{TableName}.OpenId", "OpenId", filter.OpenId, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);
            AddParameter(stringBuilder, $"{TableName}.AccessToken", "AccessToken", filter.AccessToken, parameter);
            AddParameter(stringBuilder, $"{TableName}.RefreshToken", "RefreshToken", filter.RefreshToken, parameter);
            AddParameter(stringBuilder, $"{TableName}.ExpiresIn", "ExpiresIn", filter.ExpiresIn, parameter);
            AddParameter(stringBuilder, $"{TableName}.Scope", "Scope", filter.Scope, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTime", filter.CreateTime, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMin", filter.CreateTimeMin, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMax", filter.CreateTimeMax, parameter);
            AddParameter(stringBuilder, $"{TableName}.ExpiresTime", "ExpiresTime", filter.ExpiresTime, parameter);
            AddParameter(stringBuilder, $"{TableName}.ExpiresTime", "ExpiresTimeMin", filter.ExpiresTimeMin, parameter);
            AddParameter(stringBuilder, $"{TableName}.ExpiresTime", "ExpiresTimeMax", filter.ExpiresTimeMax, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class AuthAccessToken
    {
        /// <summary>
        /// 插入或更新数据
        /// </summary>
        /// <param name="item">应用访问凭据</param>
        /// <returns></returns>
        internal int InserOrUpdate(Entity.AuthAccessToken item)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"INSERT INTO {TableName} (AppId,OpenId,MerchantId,AccessToken,RefreshToken,ExpiresIn,Scope,CreateTime,ExpiresTime) VALUES (@AppId,@OpenId,@MerchantId,@AccessToken,@RefreshToken,@ExpiresIn,@Scope,@CreateTime,@ExpiresTime)";
                sql += $" ON DUPLICATE KEY UPDATE AccessToken=@AccessToken,ExpiresIn=@ExpiresIn,ExpiresTime=@ExpiresTime";
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