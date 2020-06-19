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
            CreateMap<Entity.Merchant, Model.Merchant>();
            CreateMap<Entity.Merchant, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateMerchant, Entity.Merchant>();
            CreateMap<Model.UpdateMerchant, Entity.Merchant>();
            CreateMap<Model.DeleteMerchant, Entity.Merchant>();

            CreateMap<Entity.Parameter, Model.Parameter>();
            CreateMap<Model.CreateParameter, Entity.Parameter>();
            CreateMap<Model.UpdateParameter, Entity.Parameter>();
            CreateMap<Model.DeleteParameter, Entity.Parameter>();

            CreateMap<Entity.User, Model.User>()
                .ForMember(dest => dest.MerchantName, opt => opt.ConvertUsing<KeyToNameConverter<string, IMerchantManager>, string>(src => src.MerchantId));
            CreateMap<Entity.User, Model.UserDetail>()
                .IncludeBase<Entity.User, Model.User>()
                //.ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles.Select(p => p.Id)));
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.DepartmentIds, opt => opt.MapFrom(src => src.Departments.Select(p => p.Id).ToList()))
                .ForMember(dest => dest.ModuleIds, opt => opt.MapFrom(src => src.Roles.SelectMany(role => role.Modules, (p, q) => q.Id).Distinct().ToList()));
            CreateMap<Model.CreateUser, Entity.User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds))
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DepartmentIds.Select(p => new Entity.Department { Id = p })));
            CreateMap<Model.UpdateUser, Entity.User>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds))
                .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DepartmentIds.Select(p => new Entity.Department { Id = p })));
            CreateMap<Model.UpdateUserPersonalSetting, Entity.User>();

            CreateMap<Model.DeleteUser, Entity.User>();
            CreateMap<Entity.User, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<Entity.Role, Model.Role>();
            CreateMap<Entity.Role, Model.RoleDetail>().ForMember(dest => dest.ModuleIds, opt => opt.MapFrom(src => src.Modules));
            CreateMap<Entity.Role, string>().ConvertUsing(src => src.Id);
            CreateMap<string, Entity.Role>().ConvertUsing(src => new Entity.Role { Id = src });
            CreateMap<Entity.Role, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Model.UpdateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Model.DeleteRole, Entity.Role>();

            CreateMap<Entity.Department, Model.Department>();
            CreateMap<Model.CreateDepartment, Entity.Department>();
            CreateMap<Model.UpdateDepartment, Entity.Department>();
            CreateMap<Model.DeleteDepartment, Entity.Department>();


            CreateMap<Entity.DownloadFile, Model.DownloadFile>().ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02020501", src.Type)));

            CreateMap<Entity.UploadFile, Model.UploadFile>().ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02020401", src.Type))).ForMember(dest => dest.CreateUserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.CreateUserId));

            CreateMap<Entity.OperateHistory, Model.OperateHistory>().ForMember(dest => dest.UserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.UserId)); ;

            CreateMap<Entity.UserLoginHistory, Model.UserLoginHistory>()
                .ForMember(dest => dest.MerchantName, opt => opt.ConvertUsing<KeyToNameConverter<string, IMerchantManager>, string>(src => src.MerchantId))
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010101", src.Type)))
                .ForMember(dest => dest.ResultName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010102", src.Result)));
        }

    }
}
