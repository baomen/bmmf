using Client = BaoMen.WeChat.Pub.Client;

namespace BaoMen.MultiMerchant.Web.WeChat.Pub.Mapper
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
            CreateMap<Client.Sns.AccessTokenResponse, Models.AccessTokenResponse>();
            CreateMap<Client.Sns.UserInfoResponse, Models.UserInfoResponse>();
        }

    }
}
