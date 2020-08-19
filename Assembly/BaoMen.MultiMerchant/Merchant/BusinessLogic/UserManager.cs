/*
Author: WangXinBin
CreateTime: 2019/10/23 11:51:58
*/

using Microsoft.Extensions.Configuration;
using BaoMen.MultiMerchant.Merchant.Entity;
using BaoMen.Common.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using BaoMen.Common.Extension;
using BaoMen.Common.Constant;
using BaoMen.Common.Model;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BaoMen.MultiMerchant.Merchant.BusinessLogic
{
    #region class UserManager (generated)
    /// <summary>
    /// 商户用户业务逻辑
    /// </summary>
    public partial class UserManager : Util.MerchantCacheableBusinessLogicBase<string, User, UserFilter, DataAccess.User>, IUserManager
    {
        private readonly IRoleManager roleManager;
        private readonly UserRoleManager userRoleManager;
        private readonly UserDepartmentManager userDepartmentManager;
        private readonly UserTokenManager userTokenManager;
        private IOperateHistoryManager operateHistoryManager;
        private readonly IParameterManager parameterManager;
        private static readonly char[] passwordConstant = {
                    '0','1','2','3','4','5','6','7','8','9',
                    'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                    'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
                };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration">配置实例</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public UserManager(IConfiguration configuration, IServiceProvider serviceProvider) : base(configuration, serviceProvider)
        {
            roleManager = serviceProvider.GetRequiredService<IRoleManager>();
            parameterManager = serviceProvider.GetRequiredService<IParameterManager>();
            operateHistoryManager = serviceProvider.GetRequiredService<IOperateHistoryManager>();
            userRoleManager = serviceProvider.GetRequiredService<UserRoleManager>();
            userDepartmentManager = serviceProvider.GetRequiredService<UserDepartmentManager>();
            userTokenManager = serviceProvider.GetRequiredService<UserTokenManager>();

        }

        /// <summary>
        /// 插入系统用户
        /// </summary>
        /// <param name="item">系统用户实体</param>
        /// <returns></returns>
        protected override int DoInsert(User item)
        {
            item.CreateTime = DateTime.Now;
            item.Password = item.Password.To32MD5();
            PrepareUser(item);
            return ProcessWithTransaction((transaction) =>
            {
                int rows = dal.Insert(item, transaction);
                rows += InsertExtention(item, transaction);
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Insert, transaction: transaction);
                return rows;
            });
        }

        /// <summary>
        /// 更新系统用户
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override int DoUpdate(User item)
        {
            PrepareUser(item);
            return ProcessWithTransaction((transaction) =>
            {
                int rows = DeleteExtention(item, transaction);
                rows += InsertExtention(item, transaction);
                rows += dal.Update(item, transaction);
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, transaction: transaction);
                return rows;
            });
        }

        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override int DoDelete(User item)
        {
            return ProcessWithTransaction((transaction) =>
            {
                int rows = DeleteExtention(item, transaction);
                rows += dal.Delete(item, transaction);
                operateHistoryManager.Insert(item.Id, item, DataOperationType.Delete, transaction: transaction);
                return rows;
            });
        }

        private void PrepareUser(Entity.User item)
        {
            item.Email ??= string.Empty;
            item.UserName ??= string.Empty;
            item.WechatMpOpenId ??= string.Empty;
            item.WechatOpenId ??= string.Empty;
            item.WechatUnionId ??= string.Empty;
            item.DingTalkId ??= string.Empty;
            item.AlipayId ??= string.Empty;
        }

        private int InsertExtention(User item, IDbTransaction transaction)
        {
            int rows = 0;
            if (item.Roles?.Count > 0)
            {
                var userRoles = from p in item.Roles select new UserRole() { UserId = item.Id, RoleId = p.Id, MerchantId = item.MerchantId };
                foreach (var userRole in userRoles)
                {
                    rows += userRoleManager.Dal.Insert(userRole, transaction);
                }
            }
            if (item.Departments?.Count > 0)
            {
                var userDepartments = item.Departments.Select(p => new UserDepartment { UserId = item.Id, DepartmentId = p.Id, MerchantId = item.MerchantId }).ToList();
                foreach (UserDepartment userDepartment in userDepartments)
                {
                    rows += userDepartmentManager.Dal.Insert(userDepartment, transaction);
                }
            }
            rows += userTokenManager.Dal.Insert(new UserToken { UserId = item.Id, MerchantId = item.MerchantId, Expires = item.CreateTime, Token = Guid.NewGuid().ToString("N") }, transaction);
            return rows;
        }

        private int DeleteExtention(User item, IDbTransaction transaction)
        {
            int rows = userRoleManager.Dal.Delete(item.Id, transaction);
            rows += userDepartmentManager.Dal.Delete(item.Id, transaction);
            rows += userTokenManager.Dal.Delete(new UserToken { UserId = item.Id }, transaction);
            return rows;
        }

        /// <summary>
        /// 获取用户令牌
        /// </summary>
        /// <param name="merchantId">商户ID</param>
        /// <param name="token">令牌</param>
        /// <returns></returns>
        public Entity.UserToken GetUserToken(string merchantId, string token)
        {
            if (string.IsNullOrEmpty(merchantId) || string.IsNullOrEmpty(token)) return null;
            IDictionary<string, Entity.UserToken> tokens = userTokenManager.GetCacheData(merchantId);
            return tokens.Values.Where(p => p.Token == token).SingleOrDefault();
        }


        /// <summary>
        /// 更新用户令牌
        /// </summary>
        /// <param name="item">用户令牌实例</param>
        /// <returns></returns>
        public int UpdateUserToken(UserToken item)
        {
            return userTokenManager.Update(item);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="item">用户实体</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public int ModifyPassword(User item, string newPassword)
        {
            return ProcessUpdate(() =>
            {
                User user = Get(item.Id);
                if (item.Password != user.Password)
                {
                    throw new ArgumentException("原密码不正确");
                }
                else
                {
                    item.Password = newPassword.To32MD5();
                    int affectRows = ProcessWithTransaction((transaction) =>
                    {
                        int rows = dal.ModifyPassword(item, transaction.Connection, transaction);
                        rows += userTokenManager.Dal.ExpireToken(item.Id, transaction.Connection, transaction);
                        rows += operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, description: "用户修改密码", transaction: transaction);
                        return rows;
                    });
                    if (affectRows > 0)
                    {
                        RemoveCache();
                    }
                    return affectRows;
                }
            }, (log) =>
            {
                log.Properties["item"] = item;
                log.Properties["newPassword"] = newPassword;
            });
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string ResetPassword(User item)
        {
            string newPassword = CreateDefaultPassword();
            int affectRows = ProcessUpdate(() =>
            {
                string oldPassword = item.Password;
                item.Password = newPassword.To32MD5();
                int updateRows = ProcessWithTransaction((transaction) =>
                {
                    int rows = dal.ModifyPassword(item, transaction.Connection, transaction);
                    rows += userTokenManager.Dal.ExpireToken(item.Id, transaction.Connection, transaction);
                    rows += operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, description: "重置密码", transaction: transaction);
                    return rows;
                });
                if (updateRows == 0)
                {
                    item.Password = oldPassword;
                }
                else
                {
                    RemoveCache();
                }
                return updateRows;
            },
            (log) =>
            {
                log.Properties["item"] = item;
            });
            if (affectRows > 0)
            {
                return newPassword;
            }
            else
            {
                throw new BusinessLogicException("重置用户密码失败");
            }
        }

        /// <summary>
        /// 过期Token
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public int ExpireToken(string userId)
        {
            return ProcessUpdate(() =>
            {
                return userTokenManager.Dal.ExpireToken(userId);
            }, (log) =>
            {
                log.Properties["userId"] = userId;
            });
        }

        /// <summary>
        /// 过期Token(多个)
        /// </summary>
        /// <param name="userIds">用户ID</param>
        /// <returns></returns>
        public int ExpireTokens(ICollection<string> userIds)
        {
            return ProcessUpdate(() =>
            {
                return userTokenManager.Dal.ExpireTokens(userIds);
            }, (log) =>
            {
                log.Properties["userIds"] = userIds;
            });
        }

        /// <summary>
        /// 生成默认随机密码
        /// </summary>
        /// <returns></returns>
        private string CreateDefaultPassword()
        {
            StringBuilder newRandom = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                newRandom.Append(passwordConstant[random.Next(62)]);
            }
            return newRandom.ToString();
        }

        /// <summary>
        /// 添加实体的扩展属性
        /// </summary>
        /// <param name="item"></param>
        protected override void AppendExtention(User item)
        {
            item.Roles = userRoleManager.GetList(new UserRoleFilter { UserId = item.Id }).Select(p => roleManager.Get(p.RoleId)).Where(p => p != null).ToList();
            IDepartmentManager departmentManager = serviceProvider.GetRequiredService<IDepartmentManager>();
            ICollection<UserDepartment> userDepartments = userDepartmentManager.GetList(new UserDepartmentFilter { UserId = item.Id });
            item.Departments = userDepartments.Select(p => departmentManager.Get(p.DepartmentId)).ToList();
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        public override void RemoveCache()
        {
            userRoleManager.RemoveCache();
            userDepartmentManager.RemoveCache();
            base.RemoveCache();
        }

        /// <summary>
        /// 根据用户ID查询用户，直接查询数据库，不走缓存
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(string id)
        {
            return ProcessSelect(() =>
            {
                if (string.IsNullOrEmpty(id) || id.Length != 32)
                {
                    throw new ArgumentException("invalid id");
                }
                return dal.Get(id);
            }, (log) =>
            {
                log.Properties[nameof(id)] = id;
            });
        }

        /// <summary>
        /// 根据手机号码查询用户，直接查询数据库，不走缓存
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public User GetByMobile(string mobile)
        {
            return ProcessSelect(() =>
            {
                if (string.IsNullOrEmpty(mobile) || mobile.Length != 11)
                {
                    throw new ArgumentException("invalid mobile");
                }
                UserFilter userFilter = new UserFilter { Mobile = mobile };
                return dal.GetList(userFilter).FirstOrDefault();
            }, (log) =>
            {
                log.Properties[nameof(mobile)] = mobile;
            });
        }

        /// <summary>
        ///  根据ID取得名称
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetName(string key)
        {
            return Get(key)?.Name;
        }

        /// <summary>
        /// 修改头像
        /// </summary>
        /// <param name="item">用户实例</param>
        /// <param name="file">文件流</param>
        /// <returns></returns>
        public int UpdateAvatar(User item, IFormFile file)
        {
            return ProcessUpdate(() =>
            {
                IUploadFileManager uploadFileManager = serviceProvider.GetRequiredService<IUploadFileManager>();
                UploadFile uploadFile = uploadFileManager.CreateUploadFile(item.MerchantId, item.Id, item.Id, 1, file.FileName);
                string physicalPath = uploadFileManager.GetPhysicalPath(uploadFile.RelativePath);
                uploadFileManager.SaveFile(physicalPath, file);

                string existAvatar = item.Avatar;
                item.Avatar = uploadFile.RelativePath;

                int affectRows = ProcessWithTransaction((transaction) =>
                {
                    int rows = dal.ModifyAvatar(item, transaction.Connection, transaction);
                    rows += operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, description: "用户修改头像", transaction: transaction);
                    rows += uploadFileManager.Insert(uploadFile, transaction);
                    return rows;
                });
                if (affectRows > 0)
                {
                    RemoveCache();
                    //if (!string.IsNullOrEmpty(existAvatar))
                    //{
                    //    try
                    //    {
                    //        File.Delete(uploadFileManager.GetPhysicalPath(uploadFile.RelativePath));
                    //    }
                    //    catch (Exception exception)
                    //    {
                    //    }
                    //}
                }
                return affectRows;
            }, (log) =>
             {
                 log.Properties[nameof(item)] = item;
             });
        }

        /// <summary>
        /// 用户修改个人设置
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ModifyPersonalSetting(User item)
        {
            item.Email ??= string.Empty;
            return ProcessUpdate(() =>
            {
                int row = dal.ModifyPersonalSetting(item);
                if (row > 0)
                {
                    RemoveCache();
                    operateHistoryManager.Insert(item.Id, item, DataOperationType.Update, description: "修改用户设置");
                }
                return row;
            }, (log) =>
            {
                log.Properties["item"] = item;
            });
        }

    }
    #endregion
}