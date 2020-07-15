﻿using BaoMen.Common.Model;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace BaoMen.Common.Extension
{
    //public static partial class DapperExtension
    //{
    //    public static IEnumerable<TReturn> Query<TReturn>(this IDbConnection connection, int startRowIndex, int maximumRows, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
    //    {
    //        System.Type connectionType = connection.GetType();
    //        if (connectionType == typeof(MySql.Data.MySqlClient.MySqlConnection))
    //        {
    //            sql = GetMySqlPageSql(sql, startRowIndex, maximumRows);
    //            return connection.Query<TReturn>(sql, param, transaction, buffered, commandTimeout, commandType);
    //        }
    //        else
    //        {
    //            throw new System.NotSupportedException($"not supported database type : {connectionType.FullName}");
    //        }
    //    }

    //    public static IEnumerable<TReturn> Query<TReturn>(this IDbConnection connection, int startRowIndex, int maximumRows, CommandDefinition command)
    //    {
    //        System.Type connectionType = connection.GetType();
    //        if (connectionType == typeof(MySql.Data.MySqlClient.MySqlConnection))
    //        {
    //            string sql = GetMySqlPageSql(command.CommandText, startRowIndex, maximumRows);
    //            CommandDefinition newCommand = new CommandDefinition(sql, command.Parameters, command.Transaction, command.CommandTimeout, command.CommandType, command.Flags, command.CancellationToken);
    //            return connection.Query<TReturn>(newCommand);
    //        }
    //        else
    //        {
    //            throw new System.NotSupportedException($"not supported database type : {connectionType.FullName}");
    //        }
    //    }

    //    public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection connection, int startRowIndex, int maximumRows, CommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
    //    {
    //        System.Type connectionType = connection.GetType();
    //        if (connectionType == typeof(MySql.Data.MySqlClient.MySqlConnection))
    //        {
    //            string sql = GetMySqlPageSql(command.CommandText, startRowIndex, maximumRows);
    //            CommandDefinition newCommand = new CommandDefinition(sql, command.Parameters, command.Transaction, command.CommandTimeout, command.CommandType, command.Flags, command.CancellationToken);
    //            return connection.Query<TFirst, TSecond, TReturn>(sql, map, command.Parameters, command.Transaction, command.Buffered, splitOn, command.CommandTimeout, command.CommandType);
    //        }
    //        else
    //        {
    //            throw new System.NotSupportedException($"not supported database type : {connectionType.FullName}");
    //        }
    //    }

    //    public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection connection, CommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
    //    {
    //        return connection.Query<TFirst, TSecond, TReturn>(command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn, command.CommandTimeout, command.CommandType);
    //    }
    //}

    /// <summary>
    /// Dapper扩展
    /// </summary>
    public static partial class DapperExtension
    {
        public static NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        #region Execute

        public static int Execute(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.Execute(commandDefinition);
        }

        public static T ExecuteScalar<T>(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.ExecuteScalar<T>(commandDefinition);
        }
        #endregion

        #region Query

        public static T QuerySingle<T>(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.QuerySingle<T>(commandDefinition);
        }

        public static T QuerySingleOrDefault<T>(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.QuerySingleOrDefault<T>(commandDefinition);
        }

        public static T QueryFirst<T>(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.QueryFirst<T>(commandDefinition);
        }

        public static T QueryFirstOrDefault<T>(this IDbConnection dbConnection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return dbConnection.QueryFirstOrDefault<T>(commandDefinition);
        }

        public static IEnumerable<TReturn> Query<TReturn>(this IDbConnection connection, DapperCommand command)
        {
            CheckDapperCommand(command);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return connection.Query<TReturn>(commandDefinition);
        }

        public static IEnumerable<TReturn> Query<TReturn>(this IDbConnection connection, DapperCommand command, int startRowIndex = 0, int maximumRows = int.MaxValue)
        {
            CheckDapperCommand(command);
            PreparePageCommand(connection, command, startRowIndex, maximumRows);
            CommandDefinition commandDefinition = CreateCommandDefine(command);
            return connection.Query<TReturn>(commandDefinition);
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection connection, DapperCommand command, Func<TFirst, TSecond, TReturn> map, string splitOn, int startRowIndex = 0, int maximumRows = int.MaxValue)
        {
            CheckDapperCommand(command);
            PreparePageCommand(connection, command, startRowIndex, maximumRows);
            bool buffered = (command.Flags & CommandFlags.Buffered) != 0;
            return connection.Query<TFirst, TSecond, TReturn>(
                sql: command.CommandText,
                map: map,
                param: command.Parameters,
                transaction: command.Transaction,
                buffered: buffered,
                splitOn: splitOn,
                commandTimeout: command.CommandTimeout,
                commandType: command.CommandType);
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbConnection connection, DapperCommand command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn, int startRowIndex = 0, int maximumRows = int.MaxValue)
        {
            CheckDapperCommand(command);
            PreparePageCommand(connection, command, startRowIndex, maximumRows);
            bool buffered = (command.Flags & CommandFlags.Buffered) != 0;
            return connection.Query(
                sql: command.CommandText,
                map: map,
                param: command.Parameters,
                transaction: command.Transaction,
                buffered: buffered,
                splitOn: splitOn,
                commandTimeout: command.CommandTimeout,
                commandType: command.CommandType);
        }

        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection connection, DapperCommand command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn, int startRowIndex = 0, int maximumRows = int.MaxValue)
        {
            CheckDapperCommand(command);
            PreparePageCommand(connection, command, startRowIndex, maximumRows);
            bool buffered = (command.Flags & CommandFlags.Buffered) != 0;
            return connection.Query(
                sql: command.CommandText,
                map: map,
                param: command.Parameters,
                transaction: command.Transaction,
                buffered: buffered,
                splitOn: splitOn,
                commandTimeout: command.CommandTimeout,
                commandType: command.CommandType);
        }
        #endregion


        private static void CheckDapperCommand(DapperCommand command)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (string.IsNullOrEmpty(command.CommandText)) throw new ArgumentNullException("command.CommandText");
        }

        private static void PreparePageCommand(IDbConnection connection, DapperCommand command, int startRowIndex, int maximumRows)
        {
            if (startRowIndex == 0 && maximumRows == int.MaxValue) return;
            switch (connection)
            {
                case MySqlConnection conn:
                    PrepareMySqlPageCommand(command, startRowIndex, maximumRows);
                    break;
                default:
                    throw new System.NotSupportedException($"not supported database type : {connection.GetType().FullName}");
            }
        }

        private static void PrepareMySqlPageCommand(DapperCommand command, int startRowIndex, int maximumRows)
        {
            command.CommandText = $"{command.CommandText} LIMIT {startRowIndex},{maximumRows}";
        }

        public static int GetIntIdentity(this IDbConnection connection, IDbTransaction transaction)
        {
            switch (connection)
            {
                //case MySql.Data.MySqlClient.MySqlConnection conn:
                case MySqlConnector.MySqlConnection conn:
                    return connection.ExecuteScalar<int>(sql: "SELECT @@IDENTITY", transaction: transaction);
                case System.Data.SqlClient.SqlConnection conn:
                    return conn.ExecuteScalar<int>(sql: "select @@identity", transaction: transaction);
                default:
                    throw new System.NotSupportedException($"not supported database type : {connection.GetType().FullName}");
            }
        }

        public static long GetLongIdentity(this IDbConnection connection, IDbTransaction transaction)
        {
            switch (connection)
            {
                //case MySql.Data.MySqlClient.MySqlConnection conn:
                case MySqlConnector.MySqlConnection conn:
                    return conn.ExecuteScalar<long>(sql: "SELECT @@IDENTITY", transaction: transaction);
                case System.Data.SqlClient.SqlConnection conn:
                    return conn.ExecuteScalar<long>(sql: "select @@identity", transaction: transaction);
                default:
                    throw new System.NotSupportedException($"not supported database type : {connection.GetType().FullName}");
            }
        }

        /// <summary>
        /// 创建CommandDefinition实例
        /// </summary>
        /// <param name="dapperCommand"></param>
        /// <returns></returns>
        public static CommandDefinition CreateCommandDefine(DapperCommand dapperCommand)
        {
            return new CommandDefinition(
                    dapperCommand.CommandText,
                    dapperCommand.Parameters,
                    dapperCommand.Transaction,
                    dapperCommand.CommandTimeout,
                    dapperCommand.CommandType,
                    dapperCommand.Flags,
                    dapperCommand.CancellationToken);
        }
    }
}
