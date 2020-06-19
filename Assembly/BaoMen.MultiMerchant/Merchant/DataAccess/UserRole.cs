/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:25
*/

using BaoMen.Common.Data;
using BaoMen.Common.Extension;
using BaoMen.Common.Model;
using Dapper;
using System;
using System.Data;
using System.Text;

namespace BaoMen.MultiMerchant.Merchant.DataAccess
{
    /// <summary>
    /// 商户用户角色数据访问
    /// </summary>
    #region class UserRole (generated)
    public partial class UserRole : DapperDataAccess<Tuple<string, string>, Entity.UserRole, Entity.UserRoleFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public UserRole(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_user_role"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.UserRole item)
        {
            string sql = $"INSERT INTO {TableName} (UserId,RoleId,MerchantId) VALUES (@UserId,@RoleId,@MerchantId)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.UserRole item)
        {
            string sql = $"UPDATE {TableName} SET MerchantId=@MerchantId WHERE UserId=@UserId And RoleId=@RoleId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.UserRole item)
        {
            string sql = $"DELETE FROM {TableName} WHERE UserId=@UserId And RoleId=@RoleId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", item.UserId);
            dynamicParameters.Add("RoleId", item.RoleId);
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
            string sql = $"SELECT {TableName}.UserId,{TableName}.RoleId,{TableName}.MerchantId FROM {TableName}";
            sql += " WHERE UserId=@UserId And RoleId=@RoleId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", id.Item1);
            dynamicParameters.Add("RoleId", id.Item2);
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.UserRoleFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.UserId", "UserId", filter.UserId, parameter);
            AddParameter(stringBuilder, $"{TableName}.RoleId", "RoleId", filter.RoleId, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class UserRole
    {
        /// <summary>
        /// 删除用户的数据
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int Delete(string userId, IDbTransaction transaction)
        {
            return ProcessDelete(() =>
            {
                string sql = $"delete from {TableName} where UserId=@UserId";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Parameters = new
                    {
                        UserId = userId
                    },
                    Transaction = transaction
                };
                return transaction.Connection.Execute(command);
            },
            (log) =>
            {
                log.Properties["userId"] = userId;
            });
        }

        /// <summary>
        /// 删除角色的数据
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int DeleteByRoleId(string roleId, IDbTransaction transaction)
        {
            return ProcessDelete(() =>
            {
                string sql = $"delete from {TableName} where RoleId=@RoleId";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Parameters = new
                    {
                        RoleId = roleId
                    },
                    Transaction = transaction
                };
                return transaction.Connection.Execute(command);
            },
            (log) =>
            {
                log.Properties["roleId"] = roleId;
            });
        }
    }
}