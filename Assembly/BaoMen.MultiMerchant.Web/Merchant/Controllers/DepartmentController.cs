using AutoMapper;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using BaoMen.MultiMerchant.Web.Util;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;

namespace BaoMen.MultiMerchant.Web.Merchant.Controllers
{
    /// <summary>
    /// 商户部门
    /// </summary>
    public abstract class DepartmentController : MerchantBaseHierarchicalController<string, Entity.Department, Entity.DepartmentFilter, Models.Department, Models.CreateDepartment, Models.UpdateDepartment, Models.DeleteDepartment, IDepartmentManager>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="manager">业务逻辑实例</param>
        /// <param name="mapper">AutoMapper实例</param>
        /// <param name="merchantService">商户服务实例</param>
        public DepartmentController(IDepartmentManager manager, IMapper mapper, MultiMerchant.Util.IMerchantService merchantService) : base(manager, mapper, merchantService)
        {
        }

        ///// <summary>
        ///// 取得嵌套的列表（包含子模块)
        ///// </summary>
        ///// <param name="filter">过滤器</param>
        ///// <param name="sort">排序规则</param>
        ///// <returns></returns>
        //[HttpGet]
        //public ResponseData<ICollection<Model.Department>> GetNestedList([FromQuery]Entity.DepartmentFilter filter, string sort)
        //{
        //    ResponseData<ICollection<Model.Department>> responseData = new ResponseData<ICollection<Model.Department>>();
        //    try
        //    {
        //        filter.MerchantId = merchantService.MerchantId;
        //        ICollection<Entity.Department> entityDepartments = manager.GetList(filter, sort);
        //        if (entityDepartments?.Count > 0)
        //        {
        //            ICollection<Model.Department> departments = mapper.Map<ICollection<Model.Department>>(entityDepartments);
        //            ICollection<Model.Department> nestedDepartments = new List<Model.Department>();
        //            foreach (Model.Department department in departments)
        //            {
        //                if (!departments.Any(p => p.Id == department.ParentId))
        //                {
        //                    nestedDepartments.Add(department);
        //                }
        //            }
        //            foreach (Model.Department module in nestedDepartments)
        //            {
        //                AppendChildren(module, departments);
        //            }
        //            responseData.Data = nestedDepartments;
        //        }
        //        else
        //        {
        //            responseData.Data = new List<Model.Department>();
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        responseData.Exception = exception;
        //        responseData.ErrorNumber = 1000;
        //        responseData.ErrorMessage = Properties.Resources.Error_1000;
        //        logger.Error(exception);
        //    }
        //    return responseData;
        //}

        //private void AppendChildren(Model.Department module, ICollection<Model.Department> modules)
        //{
        //    foreach (Model.Department item in modules)
        //    {
        //        if (item.ParentId == module.Id)
        //        {
        //            if (module.Children == null)
        //            {
        //                module.Children = new List<Model.Department>();
        //            }
        //            module.Children.Add(item);
        //            AppendChildren(item, modules);
        //        }
        //    }
        //}
    }
}
