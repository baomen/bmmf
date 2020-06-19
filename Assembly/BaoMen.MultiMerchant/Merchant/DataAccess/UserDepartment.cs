/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:32
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

namespace BaoMen.MultiMerchant.Merchant.DataAccess
{
    /// <summary>
    /// 商户用户部门数据访问
    /// </summary>
    #region class UserDepartment (generated)
    public partial class UserDepartment : DapperDataAccess<Tuple<string, string>, Entity.UserDepartment, Entity.UserDepartmentFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public UserDepartment(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_user_department"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.UserDepartment item)
        {
            string sql = $"INSERT INTO {TableName} (UserId,DepartmentId,MerchantId) VALUES (@UserId,@DepartmentId,@MerchantId)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.UserDepartment item)
        {
            string sql = $"UPDATE {TableName} SET MerchantId=@MerchantId WHERE UserId=@UserId And DepartmentId=@DepartmentId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.UserDepartment item)
        {
            string sql = $"DELETE FROM {TableName} WHERE UserId=@UserId And DepartmentId=@DepartmentId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", item.UserId);
            dynamicParameters.Add("DepartmentId", item.DepartmentId);
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
            string sql = $"SELECT {TableName}.UserId,{TableName}.DepartmentId,{TableName}.MerchantId FROM {TableName}";
            sql += " WHERE UserId=@UserId And DepartmentId=@DepartmentId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", id.Item1);
            dynamicParameters.Add("DepartmentId", id.Item2);
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.UserDepartmentFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.UserId", "UserId", filter.UserId, parameter);
            AddParameter(stringBuilder, $"{TableName}.DepartmentId", "DepartmentId", filter.DepartmentId, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class UserDepartment
    {
        /// <summary>
        /// 删除用户的部门
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
    }
}