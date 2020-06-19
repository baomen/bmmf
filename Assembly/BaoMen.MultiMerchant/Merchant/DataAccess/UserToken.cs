/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:57
*/

using BaoMen.Common.Data;
using BaoMen.Common.Extension;
using BaoMen.Common.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BaoMen.MultiMerchant.Merchant.DataAccess
{
    /// <summary>
    /// 商户用户令牌数据访问
    /// </summary>
    #region class UserToken (generated)
    public partial class UserToken : DapperDataAccess<string, Entity.UserToken, Entity.UserTokenFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public UserToken(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_user_token"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.UserToken item)
        {
            string sql = $"INSERT INTO {TableName} (UserId,MerchantId,Token,Expires) VALUES (@UserId,@MerchantId,@Token,@Expires)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.UserToken item)
        {
            string sql = $"UPDATE {TableName} SET MerchantId=@MerchantId,Token=@Token,Expires=@Expires WHERE UserId=@UserId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.UserToken item)
        {
            string sql = $"DELETE FROM {TableName} WHERE UserId=@UserId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", item.UserId);
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
        protected override DapperCommand CreateGetCommand(string id)
        {
            string sql = $"SELECT {TableName}.UserId,{TableName}.MerchantId,{TableName}.Token,{TableName}.Expires FROM {TableName}";
            sql += " WHERE UserId=@UserId";
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = new { UserId = id }
            };
        }

        /// <summary>
        /// 创建过滤器的sql语句及参数
        /// </summary>
        /// <param name="filter">过滤器实例</param>
        /// <returns>where条件及参数</returns>
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.UserTokenFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.UserId", "UserId", filter.UserId, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);
            AddParameter(stringBuilder, $"{TableName}.Token", "Token", filter.Token, parameter);
            AddParameter(stringBuilder, $"{TableName}.Expires", "Expires", filter.Expires, parameter);
            AddParameter(stringBuilder, $"{TableName}.Expires", "ExpiresMin", filter.ExpiresMin, parameter);
            AddParameter(stringBuilder, $"{TableName}.Expires", "ExpiresMax", filter.ExpiresMax, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class UserToken
    {
        /// <summary>
        /// 过期Token
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int ExpireToken(string userId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"update {TableName} set Expires=@Expires where UserId=@UserId";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Transaction = transaction,
                    Parameters = new
                    {
                        Expires = DateTime.Now,
                        UserId = userId
                    }
                };
                if (connection == null)
                {
                    connection = CreateConnection();
                }
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties["userId"] = userId;
            });
        }

        /// <summary>
        /// 过期Token(多个)
        /// </summary>
        /// <param name="userIds">用户ID</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int ExpireTokens(ICollection<string> userIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"update {TableName} set Expires=@Expires where UserId in @UserIds";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Transaction = transaction,
                    Parameters = new
                    {
                        Expires = DateTime.Now,
                        UserIds = userIds
                    }
                };
                if (connection == null)
                {
                    connection = CreateConnection();
                }
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties["userId"] = userIds;
            });
        }

    }
}