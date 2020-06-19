/*
Author: WangXinBin
CreateTime: 2020-04-07 17:36:11
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

namespace BaoMen.MultiMerchant.Merchant.DataAccess
{
	/// <summary>
    /// 商户用户登录历史数据访问
    /// </summary>
	#region class UserLoginHistory (generated)
    public partial class UserLoginHistory : DapperDataAccess<int,Entity.UserLoginHistory, Entity.UserLoginHistoryFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public UserLoginHistory(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }
               
        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_user_login_history"; } }
               
        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.UserLoginHistory item)
        {
            string sql = $"INSERT INTO {TableName} (MerchantId,Mobile,LoginTime,Type,Result,UserAgent,ClientIp,ServerIp,Description) VALUES (@MerchantId,@Mobile,@LoginTime,@Type,@Result,@UserAgent,@ClientIp,@ServerIp,@Description)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.UserLoginHistory item)
        {
            string sql = $"UPDATE {TableName} SET MerchantId=@MerchantId,Mobile=@Mobile,LoginTime=@LoginTime,Type=@Type,Result=@Result,UserAgent=@UserAgent,ClientIp=@ClientIp,ServerIp=@ServerIp,Description=@Description WHERE Id=@Id";
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
        protected override DapperCommand CreateDeleteCommand(Entity.UserLoginHistory item)
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
        protected override DapperCommand CreateGetCommand(int id)
        {
            string sql = $"SELECT {TableName}.Id,{TableName}.MerchantId,{TableName}.Mobile,{TableName}.LoginTime,{TableName}.Type,{TableName}.Result,{TableName}.UserAgent,{TableName}.ClientIp,{TableName}.ServerIp,{TableName}.Description FROM {TableName}";
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.UserLoginHistoryFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            		AddParameter(stringBuilder, $"{TableName}.Id", "Id", filter.Id, parameter);
		AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);
		AddParameter(stringBuilder, $"{TableName}.Mobile", "Mobile", filter.Mobile, parameter);
		AddParameter(stringBuilder, $"{TableName}.LoginTime", "LoginTime", filter.LoginTime, parameter);
		AddParameter(stringBuilder, $"{TableName}.LoginTime", "LoginTimeMin", filter.LoginTimeMin, parameter);
		AddParameter(stringBuilder, $"{TableName}.LoginTime", "LoginTimeMax", filter.LoginTimeMax, parameter);
		AddParameter(stringBuilder, $"{TableName}.Type", "Type", filter.Type, parameter);
		AddParameter(stringBuilder, $"{TableName}.Result", "Result", filter.Result, parameter);
		AddParameter(stringBuilder, $"{TableName}.UserAgent", "UserAgent", filter.UserAgent, parameter);
		AddParameter(stringBuilder, $"{TableName}.ClientIp", "ClientIp", filter.ClientIp, parameter);
		AddParameter(stringBuilder, $"{TableName}.ServerIp", "ServerIp", filter.ServerIp, parameter);
		AddParameter(stringBuilder, $"{TableName}.Description", "Description", filter.Description, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
	#endregion
}