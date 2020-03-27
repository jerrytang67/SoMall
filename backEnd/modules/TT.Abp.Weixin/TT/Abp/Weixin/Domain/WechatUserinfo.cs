using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Weixin.Domain
{
    public class WechatUserinfo : CreationAuditedEntity
    {
        private WechatUserinfo()
        {
        }

        public WechatUserinfo([NotNull] string appid, [NotNull] string openid, string unionid, string nickname, string headimgurl, WeixinEnums.ClientType fromClient = WeixinEnums.ClientType.Mini)
        {
            this.appid = appid;
            this.openid = openid;
            this.unionid = unionid;
            this.nickname = nickname;
            this.headimgurl = headimgurl;
            FromClient = fromClient;
        }

        [NotNull] public string appid { get; set; }
        [NotNull] public string openid { get; set; }

        public string unionid { get; set; }

        public string nickname { get; set; }

        public string headimgurl { get; set; }

        public string city { get; set; }

        public string province { get; set; }

        public string country { get; set; }

        public int sex { get; set; }

        public WeixinEnums.ClientType FromClient { get; set; }

        public override object[] GetKeys()
        {
            return new object[] {appid, openid};
        }
    }

    public class WeixinEnums
    {
        public enum ClientType
        {
            Default = 0,
            Mini = 1,
            Mp = 2,
            Qy = 4,
        }
    }


    public static class WeixinConsts
    {
        public const string DbTablePrefix = "Weixin_";
        public const string DbSchema = null;
        public const int MaxOpenidLength = 32;
        public const int MaxImageLength = 255;
    }
}