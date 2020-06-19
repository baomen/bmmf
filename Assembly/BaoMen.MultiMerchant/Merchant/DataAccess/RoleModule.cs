/*
Author: WangXinBin
CreateTime: 2019/10/23 11:52:23
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
    /// 商户角色模块数据访问
    /// </summary>
    #region class RoleModule (generated)
    public partial class RoleModule : DapperDataAccess<Tuple<string, string>, Entity.RoleModule, Entity.RoleModuleFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public RoleModule(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_role_module"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.RoleModule item)
        {
            string sql = $"INSERT INTO {TableName} (RoleId,ModuleId) VALUES (@RoleId,@ModuleId)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.RoleModule item)
        {
            string sql = $"UPDATE {TableName} SET WHERE RoleId=@RoleId And ModuleId=@ModuleId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.RoleModule item)
        {
            string sql = $"DELETE FROM {TableName} WHERE RoleId=@RoleId And ModuleId=@ModuleId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("RoleId", item.RoleId);
            dynamicParameters.Add("ModuleId", item.ModuleId);
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
            string sql = $"SELECT {TableName}.RoleId,{TableName}.ModuleId FROM {TableName}";
            sql += " WHERE RoleId=@RoleId And ModuleId=@ModuleId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("RoleId", id.Item1);
            dynamicParameters.Add("ModuleId", id.Item2);
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = dynamicParameters
            };
        }
    }
    #endregion

    public partial class RoleModule
    {
        /// <summary>
        /// 创建过滤器的sql语句及参数
        /// </summary>
        /// <param name="filter">过滤器实例</param>
        /// <returns>where条件及参数</returns>
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.RoleModuleFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, "RoleId", "RoleId", filter.RoleId, parameter);
            AddParameter(stringBuilder, "ModuleId", "ModuleId", filter.ModuleId, parameter);
            if (filter.MerchantId != null)
            {
                stringBuilder.Append(" and RoleId in (select Id from mch_role where MerchantId=@MerchantId)");
                parameter.Add("MerchantId", filter.MerchantId.Value);
            }
            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }

        internal int Delete(string roleId, IDbTransaction transaction)
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

        /// <summary>
        /// 根据模块ID删除数据
        /// </summary>
        /// <param name="moduleId">模块ID</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int DeleteByModuleId(string moduleId, IDbTransaction transaction)
        {
            return ProcessDelete(() =>
            {
                string sql = $"delete from {TableName} where ModuleId=@ModuleId";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Parameters = new
                    {
                        ModuleId = moduleId
                    },
                    Transaction = transaction
                };
                return transaction.Connection.Execute(command);
            },
            (log) =>
            {
                log.Properties["moduleId"] = moduleId;
            });
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="roleModules"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal int Insert(IList<Entity.RoleModule> roleModules, IDbTransaction transaction)
        {
            return ProcessInsert(() =>
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"INSERT INTO {TableName} (RoleId,ModuleId) VALUES ");
                foreach (Entity.RoleModule roleModule in roleModules)
                {
                    stringBuilder.Append($"('{roleModule.RoleId}','{roleModule.ModuleId}'),");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                DapperCommand command = new DapperCommand
                {
                    CommandText = stringBuilder.ToString(),
                    Transaction = transaction
                };
                return transaction.Connection.Execute(command);
            },
            (log) =>
            {
                log.Properties["roleModules"] = roleModules;
            });
        }
    }
}