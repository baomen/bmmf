using BaoMen.Common.Model;
using BaoMen.MultiMerchant.Merchant.BusinessLogic;
using BaoMen.MultiMerchant.Web.Converter;
using BaoMen.MultiMerchant.Web.System.Mapper;
using System.Linq;
using Entity = BaoMen.MultiMerchant.Merchant.Entity;

namespace BaoMen.MultiMerchant.Web.Merchant.Mapper
{
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public class AutoMapperProfile : AutoMapper.Profile
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<Entity.Merchant, Models.Merchant>();
            CreateMap<Entity.Merchant, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Models.CreateMerchant, Entity.Merchant>();
            CreateMap<Models.UpdateMerchant, Entity.Merchant>();
            CreateMap<Models.DeleteMerchant, Entity.Merchant>();

            CreateMap<Entity.Parameter, Models.Parameter>();
            CreateMap<Models.CreateParameter, Entity.Parameter>();
            CreateMap<Models.UpdateParameter, Entity.Parameter>();
            CreateMap<Models.DeleteParameter, Entity.Parameter>();

            CreateMap<Entity.User, Models.User>()
                .ForMember(dest => dest.MerchantName, opt => opt.ConvertUsing<KeyToNameConverter<string, IMerchantManager>, string>(src => src.MerchantId))
                .ForMember(dest => dest.ModuleIds, opt => opt.MapFrom(src => src.Roles.SelectMany(role => role.Modules, (p, q) => q.Id).Distinct().ToList()));
            CreateMap<Entity.User, Models.UserDetail>()
                .IncludeBase<Entity.User, Models.User>()
                //.ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(p => p.Id)));
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.DepartmentIds, opt => opt.MapFrom(src => src.Departments.Select(p => p.Id).ToList()));
            CreateMap<Models.CreateUser, Entity.User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds))
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DepartmentIds.Select(p => new Entity.Department { Id = p })));
            CreateMap<Models.UpdateUser, Entity.User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds))
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DepartmentIds.Select(p => new Entity.Department { Id = p })));
            CreateMap<Models.UpdateUserPersonalSetting, Entity.User>();

            CreateMap<Models.DeleteUser, Entity.User>();
            CreateMap<Entity.User, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<Entity.Role, Models.Role>();
            CreateMap<Entity.Role, Models.RoleDetail>().ForMember(dest => dest.ModuleIds, opt => opt.MapFrom(src => src.Modules));
            CreateMap<Entity.Role, string>().ConvertUsing(src => src.Id);
            CreateMap<string, Entity.Role>().ConvertUsing(src => new Entity.Role { Id = src });
            CreateMap<Entity.Role, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Models.CreateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Models.UpdateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Models.DeleteRole, Entity.Role>();

            CreateMap<Entity.Department, Models.Department>();
            CreateMap<Models.CreateDepartment, Entity.Department>();
            CreateMap<Models.UpdateDepartment, Entity.Department>();
            CreateMap<Models.DeleteDepartment, Entity.Department>();


            CreateMap<Entity.DownloadFile, Models.DownloadFile>()
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02020102", src.Type)));

            CreateMap<Entity.UploadFile, Models.UploadFile>()
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02020101", src.Type)))
                .ForMember(dest => dest.CreateUserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.CreateUserId));

            CreateMap<Entity.OperateHistory, Models.OperateHistory>().ForMember(dest => dest.UserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.UserId)); ;

            CreateMap<Entity.UserLoginHistory, Models.UserLoginHistory>()
                .ForMember(dest => dest.MerchantName, opt => opt.ConvertUsing<KeyToNameConverter<string, IMerchantManager>, string>(src => src.MerchantId))
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010101", src.Type)))
                .ForMember(dest => dest.ResultName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010102", src.Result)));
        }

    }
}
