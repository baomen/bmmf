/*
Author: WangXinBin
CreateTime: 2019/10/23 12:04:03
*/

using BaoMen.Common.Data.Attribute;
using BaoMen.Common.Model;
using System;
using System.Collections.Generic;

namespace BaoMen.MultiMerchant.System.Entity
{
    #region class VersionModule (generated)
    /// <summary>
    /// 系统版本模块实体
    /// </summary>
	[Serializable]
    [DatabaseEntity(TableName = "sys_version_module")]
    public partial class VersionModule
    {	
        private Tuple<string,string> complexKey;
        /// <summary>
        /// 复合主键Item1:VersionId  Item2:ModuleId  
        /// </summary>
        public Tuple<string,string> ComplexKey
        {
            get
            {
                if (complexKey == null)
                {
                    complexKey = Tuple.Create(VersionId, ModuleId);
                }
                return complexKey;
            }
        }
		/// <summary>
        /// 版本ID
        /// </summary>
		/// <remarks>
		/// ColumnName: VersionId (Primary Key)
		/// ColumnType: CHAR(32)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 32
		/// </remarks>
		public string VersionId { get; set; }
        
		/// <summary>
        /// 模块ID
        /// </summary>
		/// <remarks>
		/// ColumnName: ModuleId (Primary Key)
		/// ColumnType: CHAR(32)
		/// AllowDBNull: False
		/// Unique: False
        /// Size: 32
		/// </remarks>
		public string ModuleId { get; set; }
        
    }
	#endregion
    
	#region class VersionModuleFilter (generated)
    /// <summary>
    /// 系统版本模块实体过滤器
    /// </summary>
	[Serializable]
    [DatabaseEntityFilter(EntityType = typeof(VersionModule))]
	public partial class VersionModuleFilter
	{		
		/// <summary>
        /// 版本ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "VersionId")]
        public FilterProperty<string> VersionId { get; set; }
        
		/// <summary>
        /// 模块ID
        /// </summary>
        [DatabaseEntityFilterProperty(EntityPropertyName = "ModuleId")]
        public FilterProperty<string> ModuleId { get; set; }
        
	}
	#endregion
}