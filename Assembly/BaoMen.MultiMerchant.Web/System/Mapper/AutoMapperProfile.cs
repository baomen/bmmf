using BaoMen.Common.Model;
using BaoMen.MultiMerchant.System.BusinessLogic;
using BaoMen.MultiMerchant.Web.Converter;
using Entity = BaoMen.MultiMerchant.System.Entity;

namespace BaoMen.MultiMerchant.Web.System.Mapper
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
            //CreateMap<Entity.User, Model.User>().ForMember(dest => dest.StatusName, opt => opt.ConvertUsing<StatusValueToNameConverter, string>(src => src.Status.ToString()));
            CreateMap<Entity.User, Model.User>();
            CreateMap<Model.CreateUser, Entity.User>().ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds));
            CreateMap<Model.UpdateUser, Entity.User>().ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.RoleIds));
            CreateMap<Model.UpdateUserPersonalSetting, Entity.User>();
            CreateMap<Model.DeleteUser, Entity.User>();
            CreateMap<Entity.User, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<Entity.Role, Model.Role>().ForMember(dest => dest.ModuleIds, opt => opt.MapFrom(src => src.Modules));
            CreateMap<Model.CreateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Model.UpdateRole, Entity.Role>().ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src.ModuleIds));
            CreateMap<Model.DeleteRole, Entity.Role>();
            CreateMap<Entity.Role, string>().ConvertUsing(src => src.Id);
            CreateMap<string, Entity.Role>().ConvertUsing(src => new Entity.Role { Id = src });
            CreateMap<Entity.Role, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<Entity.Module, Model.Module>();
            CreateMap<Model.CreateModule, Entity.Module>();
            CreateMap<Model.UpdateModule, Entity.Module>();
            CreateMap<Model.DeleteModule, Entity.Module>();
            CreateMap<Entity.Module, string>().ConvertUsing(src => src.Id);
            CreateMap<string, Entity.Module>().ConvertUsing(src => new Entity.Module { Id = src });

            CreateMap<Entity.Parameter, Model.Parameter>();
            CreateMap<Model.CreateParameter, Entity.Parameter>();
            CreateMap<Model.UpdateParameter, Entity.Parameter>();
            CreateMap<Model.DeleteParameter, Entity.Parameter>();

            CreateMap<Entity.OperateHistory, Model.OperateHistory>().ForMember(dest => dest.UserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.UserId));

            CreateMap<Entity.Version, Model.Version>();
            CreateMap<Entity.Version, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateVersion, Entity.Version>();
            CreateMap<Model.UpdateVersion, Entity.Version>();
            CreateMap<Model.DeleteVersion, Entity.Version>();

            CreateMap<Entity.Province, Model.Province>();
            CreateMap<Entity.Province, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateProvince, Entity.Province>();
            CreateMap<Model.UpdateProvince, Entity.Province>();
            CreateMap<Model.DeleteProvince, Entity.Province>();

            CreateMap<Entity.City, Model.City>();
            CreateMap<Entity.City, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateCity, Entity.City>();
            CreateMap<Model.UpdateCity, Entity.City>();
            CreateMap<Model.DeleteCity, Entity.City>();

            CreateMap<Entity.District, Model.District>();
            CreateMap<Entity.District, TextValue<string>>().ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name)).ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Model.CreateDistrict, Entity.District>();
            CreateMap<Model.UpdateDistrict, Entity.District>();
            CreateMap<Model.DeleteDistrict, Entity.District>();

            CreateMap<Entity.UserLoginHistory, Model.UserLoginHistory>()
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010101", src.Type)))
                .ForMember(dest => dest.ResultName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010102", src.Result)));
            CreateMap<Model.CreateUserLoginHistory, Entity.UserLoginHistory>();
            CreateMap<Model.UpdateUserLoginHistory, Entity.UserLoginHistory>();
            CreateMap<Model.DeleteUserLoginHistory, Entity.UserLoginHistory>();

            CreateMap<Entity.DownloadFile, Model.DownloadFile>()
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010301", src.Type)));

            CreateMap<Entity.UploadFile, Model.UploadFile>()
                .ForMember(dest => dest.TypeName, opt => opt.ConvertUsing<ParameterValueToNameConverter, ParameterSourceMember>(src => new ParameterSourceMember("02010201", src.Type)))
                .ForMember(dest => dest.CreateUserName, opt => opt.ConvertUsing<KeyToNameConverter<string, IUserManager>, string>(src => src.CreateUserId));
        }

    }
}
