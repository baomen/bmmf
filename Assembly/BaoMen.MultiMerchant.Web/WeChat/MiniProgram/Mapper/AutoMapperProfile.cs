using Client = BaoMen.WeChat.MiniProgram.Client;

namespace BaoMen.MultiMerchant.Web.WeChat.MiniProgram.Mapper
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
            CreateMap<Client.Basic.CodeToSessionResponse, Models.CodeToSessionResponse>();
            CreateMap<Client.Basic.GetPaidUnionIdReponse, Models.GetPaidUnionIdReponse>();
            CreateMap<Client.Basic.DecryptDataResponse, Models.DecryptDataResponse>();
        }

    }
}
