using Client = BaoMen.WeChat.MiniProgram.Client;
using Models = BaoMen.MultiMerchant.WeChat.MiniProgram.Models;

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
            CreateMap<Client.Sns.CodeToSessionResponse, Models.CodeToSessionResponse>();
        }

    }
}
