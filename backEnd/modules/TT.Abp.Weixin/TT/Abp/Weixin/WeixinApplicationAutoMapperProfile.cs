using AutoMapper;
using TT.Abp.Weixin.Domain;
using TT.HttpClient.Weixin.WeixiinResult;

namespace TT.Abp.Weixin
{
    public class WeixinApplicationAutoMapperProfile : Profile
    {
        public WeixinApplicationAutoMapperProfile()
        {
            CreateMap<MiniUserInfoResult, WechatUserinfo>()
                .ForMember(x => x.appid, opt => opt.Ignore())
                .ForMember(x => x.openid, opt => opt.Ignore())
                .ForMember(x => x.unionid, opt => opt.MapFrom(x => x.unionid))
                .ForMember(x => x.nickname, opt => opt.MapFrom(x => x.nickName))
                .ForMember(x => x.headimgurl, opt => opt.MapFrom(x => x.avatarUrl))
                .ForMember(x => x.country, opt => opt.MapFrom(x => x.country))
                .ForMember(x => x.province, opt => opt.MapFrom(x => x.province))
                .ForMember(x => x.city, opt => opt.MapFrom(x => x.city))
                .ForMember(x => x.sex, opt => opt.MapFrom(x => x.gender))
                .ForMember(x => x.FromClient, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore())
                .ForMember(x => x.CreatorId, opt => opt.Ignore())
                .ForMember(x => x.AppName, opt => opt.MapFrom(b => b.AppName))
                ;
        }
    }
}