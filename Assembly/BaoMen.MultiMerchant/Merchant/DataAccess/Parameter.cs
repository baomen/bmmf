/*
Author: WangXinBin
CreateTime: 2019/10/29 14:25:42
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
    /// 商户参数数据访问
    /// </summary>
    #region class Parameter (generated)
    public partial class Parameter : DapperDataAccess<string, Entity.Parameter, Entity.ParameterFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public Parameter(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_parameter"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.Parameter item)
        {
            string sql = $"INSERT INTO {TableName} (Id,ParentId,MerchantId,Name,Value,Description) VALUES (@Id,@ParentId,@MerchantId,@Name,@Value,@Description)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.Parameter item)
        {
            string sql = $"UPDATE {TableName} SET ParentId=@ParentId,Name=@Name,Value=@Value,Description=@Description WHERE Id=@Id And MerchantId=@MerchantId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.Parameter item)
        {
            string sql = $"DELETE FROM {TableName} WHERE Id=@Id And MerchantId=@MerchantId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", item.Id);
            dynamicParameters.Add("MerchantId", item.MerchantId);
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
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.ParameterFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, "Id", "Id", filter.Id, parameter);
            AddParameter(stringBuilder, "ParentId", "ParentId", filter.ParentId, parameter);
            AddParameter(stringBuilder, "MerchantId", "MerchantId", filter.MerchantId, parameter);
            AddParameter(stringBuilder, "Name", "Name", filter.Name, parameter);
            AddParameter(stringBuilder, "Value", "Value", filter.Value, parameter);
            AddParameter(stringBuilder, "Description", "Description", filter.Description, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion

    public partial class Parameter
    {
        /// <summary>
        /// 创建读取单条数据的数据库命令
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns>数据库命令</returns>
        protected override DapperCommand CreateGetCommand(string id)
        {
            throw new NotImplementedException();
        }
    }
}