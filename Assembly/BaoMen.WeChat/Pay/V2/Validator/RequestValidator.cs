using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaoMen.WeChat.Pay.V2.Validator
{
    /// <summary>
    /// 验证器
    /// </summary>
    public static class RequestValidator
    {
        #region validate
        /// <summary>
        /// 验证场景ID
        /// </summary>
        /// <param name="sceneId">场景ID</param>
        /// <param name="validationContext">验证上下文</param>
        /// <returns></returns>
        public static ValidationResult ValidateSceneId(string sceneId, ValidationContext validationContext)
        {
            throw new NotImplementedException();
            //if (Regex.IsMatch(pNewName, @"^\d")) // cannot start with a digit
            //    return new ValidationResult("Cannot start with a digit", new List<string> { "CategoryName" });
            //return ValidationResult.Success;
        }
        #endregion
    }
}
