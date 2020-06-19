/*
Author: WangXinBin
CreateTime: 2019/10/23 12:04:04
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

namespace BaoMen.MultiMerchant.System.DataAccess
{
	/// <summary>
    /// 系统版本模块数据访问
    /// </summary>
	#region class VersionModule (generated)
    public partial class VersionModule : DapperDataAccess<Tuple<string,string>,Entity.VersionModule, Entity.VersionModuleFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public VersionModule(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }
               
        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "sys_version_module"; } }
               
        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.VersionModule item)
        {
            string sql = $"INSERT INTO {TableName} (VersionId,ModuleId) VALUES (@VersionId,@ModuleId)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.VersionModule item)
        {
            string sql = $"UPDATE {TableName} SET WHERE VersionId=@VersionId And ModuleId=@ModuleId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.VersionModule item)
        {
            string sql = $"DELETE FROM {TableName} WHERE VersionId=@VersionId And ModuleId=@ModuleId";    
            DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("VersionId", item.VersionId);
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
        protected override DapperCommand CreateGetCommand(Tuple<string,string> id)
        {
            if (id == null)
                return null;
            string sql = $"SELECT {TableName}.VersionId,{TableName}.ModuleId FROM {TableName}";
            sql += " WHERE VersionId=@VersionId And ModuleId=@ModuleId";
            DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("VersionId", id.Item1);
                dynamicParameters.Add("ModuleId", id.Item2);
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.VersionModuleFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            		AddParameter(stringBuilder, "VersionId", "VersionId", filter.VersionId, parameter);
		AddParameter(stringBuilder, "ModuleId", "ModuleId", filter.ModuleId, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
	#endregion

    public partial class VersionModule
    {
        internal int Delete(string versionId, IDbTransaction transaction)
        {
            return ProcessDelete(() =>
            {
                string sql = $"delete from {TableName} where VersionId=@VersionId";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Parameters = new
                    {
                        VersionId = versionId
                    },
                    Transaction = transaction
                };
                return transaction.Connection.Execute(command);
            },
            (log) =>
            {
                log.Properties["versionId"] = versionId;
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
    }
}