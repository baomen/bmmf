/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:58
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
    /// 商户用户数据访问
    /// </summary>
    #region class User (generated)
    public partial class User : DapperDataAccess<string, Entity.User, Entity.UserFilter>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="providerName">数据提供程序名称</param>
        public User(string connectionString, string providerName) : base(connectionString, providerName)
        {

        }

        /// <summary>
        /// 数据库表名
        /// </summary>
        protected override string TableName { get { return "mch_user"; } }

        /// <summary>
        /// 取得插入数据的数据库命令
        /// </summary>
        /// <param name="item">实体数据</param>
        /// <returns></returns> 
        protected override DapperCommand CreateInsertCommand(Entity.User item)
        {
            item.Id = CreateId();
            string sql = $"INSERT INTO {TableName} (Id,MerchantId,UserName,Password,Name,Mobile,Email,Avatar,CreateTime,Status,WechatOpenId,WechatMpOpenId,WechatUnionId,DingTalkId,AlipayId,Description) VALUES (@Id,@MerchantId,@UserName,@Password,@Name,@Mobile,@Email,@Avatar,@CreateTime,@Status,@WechatOpenId,@WechatMpOpenId,@WechatUnionId,@DingTalkId,@AlipayId,@Description)";
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
        protected override DapperCommand CreateUpdateCommand(Entity.User item)
        {
            string sql = $"UPDATE {TableName} SET UserName=@UserName,Password=@Password,Name=@Name,Mobile=@Mobile,Email=@Email,Avatar=@Avatar,Status=@Status,WechatOpenId=@WechatOpenId,WechatMpOpenId=@WechatMpOpenId,WechatUnionId=@WechatUnionId,DingTalkId=@DingTalkId,AlipayId=@AlipayId,Description=@Description WHERE Id=@Id And MerchantId=@MerchantId";
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
        protected override DapperCommand CreateDeleteCommand(Entity.User item)
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
        /// 创建读取单条数据的数据库命令
        /// </summary>
        /// <param name="id">实体标识</param>
        /// <returns>数据库命令</returns>
        protected override DapperCommand CreateGetCommand(string id)
        {
            string sql = $"SELECT {TableName}.Id,{TableName}.MerchantId,{TableName}.UserName,{TableName}.Password,{TableName}.Name,{TableName}.Mobile,{TableName}.Email,{TableName}.Avatar,{TableName}.CreateTime,{TableName}.Status,{TableName}.WechatOpenId,{TableName}.WechatMpOpenId,{TableName}.WechatUnionId,{TableName}.DingTalkId,{TableName}.AlipayId,{TableName}.Description FROM {TableName}";
            sql += " WHERE Id=@Id";
            return new DapperCommand()
            {
                CommandText = sql,
                Parameters = new { Id = id }
            };
        }

        /// <summary>
        /// 创建过滤器的sql语句及参数
        /// </summary>
        /// <param name="filter">过滤器实例</param>
        /// <returns>where条件及参数</returns>
        protected override (string, DynamicParameters) CreateFilterSqlWhere(Entity.UserFilter filter)
        {
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder stringBuilder = new StringBuilder();
            AddParameter(stringBuilder, $"{TableName}.Id", "Id", filter.Id, parameter);
            AddParameter(stringBuilder, $"{TableName}.MerchantId", "MerchantId", filter.MerchantId, parameter);
            AddParameter(stringBuilder, $"{TableName}.UserName", "UserName", filter.UserName, parameter);
            AddParameter(stringBuilder, $"{TableName}.Password", "Password", filter.Password, parameter);
            AddParameter(stringBuilder, $"{TableName}.Name", "Name", filter.Name, parameter);
            AddParameter(stringBuilder, $"{TableName}.Mobile", "Mobile", filter.Mobile, parameter);
            AddParameter(stringBuilder, $"{TableName}.Email", "Email", filter.Email, parameter);
            AddParameter(stringBuilder, $"{TableName}.Avatar", "Avatar", filter.Avatar, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTime", filter.CreateTime, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMin", filter.CreateTimeMin, parameter);
            AddParameter(stringBuilder, $"{TableName}.CreateTime", "CreateTimeMax", filter.CreateTimeMax, parameter);
            AddParameter(stringBuilder, $"{TableName}.Status", "Status", filter.Status, parameter);
            AddParameter(stringBuilder, $"{TableName}.WechatOpenId", "WechatOpenId", filter.WechatOpenId, parameter);
            AddParameter(stringBuilder, $"{TableName}.WechatMpOpenId", "WechatMpOpenId", filter.WechatMpOpenId, parameter);
            AddParameter(stringBuilder, $"{TableName}.WechatUnionId", "WechatUnionId", filter.WechatUnionId, parameter);
            AddParameter(stringBuilder, $"{TableName}.DingTalkId", "DingTalkId", filter.DingTalkId, parameter);
            AddParameter(stringBuilder, $"{TableName}.AlipayId", "AlipayId", filter.AlipayId, parameter);
            AddParameter(stringBuilder, $"{TableName}.Description", "Description", filter.Description, parameter);

            RemoveSqlConditionPrefix(stringBuilder);
            return (stringBuilder.ToString(), parameter);
        }
    }
    #endregion


    public partial class User
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="item">用户实体</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int ModifyPassword(Entity.User item, IDbConnection connection, IDbTransaction transaction)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"update {TableName} set Password=@Password where Id=@Id";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Transaction = transaction,
                    Parameters = new
                    {
                        item.Password,
                        item.Id
                    }
                };
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties["item"] = item;
            });
        }
        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="item">用户实体</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int ModifyAvatar(Entity.User item, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"update {TableName} set Avatar=@Avatar where Id=@Id";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Transaction = transaction,
                    Parameters = new
                    {
                        item.Avatar,
                        item.Id
                    }
                };
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties["item"] = item;
            });
        }

        /// <summary>
        /// 修改个人设置
        /// </summary>
        /// <param name="item">用户实体</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">数据库事务</param>
        /// <returns></returns>
        internal int ModifyPersonalSetting(Entity.User item, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            return ProcessUpdate(() =>
            {
                string sql = $"update {TableName} set Name=@Name,Email=@Email,Description=@Description where Id=@Id";
                DapperCommand command = new DapperCommand
                {
                    CommandText = sql,
                    Transaction = transaction,
                    Parameters = new
                    {
                        item.Avatar,
                        item.Id,
                        item.Name,
                        item.Email,
                        item.Description
                    }
                };
                return connection.Execute(command);
            }, (log) =>
            {
                log.Properties["item"] = item;
            });
        }
    }
}