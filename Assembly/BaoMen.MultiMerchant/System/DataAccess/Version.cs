/*
Author: WangXinBin
CreateTime: 2019/10/23 12:03:54
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

namespace BaoMen.MultiMerchant.System.DataAccess
{
	/// <summary>
    /// 系统版本数据访问
    /// </summary>
	#region class Version (generated)
    public partial class Version : DapperDataAccess<string,Entity.Version, Entity.VersionFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public Version(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }
               
        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "sys_version"; } }
               
        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.Version item)
        {
			item.Id = CreateId();
            string sql = $"INSERT INTO {TableName} (Id,Name,Status,Description) VALUES (@Id,@Name,@Status,@Description)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.Version item)
        {
            string sql = $"UPDATE {TableName} SET Name=@Name,Status=@Status,Description=@Description WHERE Id=@Id";
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
        protected override DapperCommand CreateDeleteCommand(Entity.Version item)
        {
            string sql = $"DELETE FROM {TableName} WHERE Id=@Id";    
            DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("Id", item.Id);
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
            string sql = $"SELECT {TableName}.Id,{TableName}.Name,{TableName}.Status,{TableName}.Description FROM {TableName}";
            sql += " WHERE Id=@Id";
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = new {Id=id}
            };
        }
        
        /// <summary>
        /// 创建过滤器的sql语句及参数
        /// </summary>
        /// <param name="filter">过滤器实例</param>
        /// <returns>where条件及参数</returns>
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.VersionFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            		AddParameter(stringBuilder, "Id", "Id", filter.Id, parameter);
		AddParameter(stringBuilder, "Name", "Name", filter.Name, parameter);
		AddParameter(stringBuilder, "Status", "Status", filter.Status, parameter);
		AddParameter(stringBuilder, "Description", "Description", filter.Description, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
	#endregion
}