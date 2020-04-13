using System.ComponentModel.DataAnnotations;

namespace TT.Abp.Mall.Domain
{
    public class MallEnums
    {
        public enum PartnerState
        {
            待审核 = 0,
            驳回 = -1,
            成功 = 10
        }

        public enum RealNameInfoType : byte
        {
            个人 = 0,
            企业 = 1
        }

        public enum RealNameInfoState : byte
        {
            未认证 = 0,
            个人认证 = 1,
            企业认证 = 2
        }

        public enum PayType
        {
            UnPay = 0,
            [Display(Name = "微信")] 微信 = 1,
            [Display(Name = "微信扫码")] 微信扫码 = 2,
            [Display(Name = "支付宝")] 支付宝 = 3,
            [Display(Name = "银联")] 银联 = 4,
            [Display(Name = "用户余额")] 用户余额 = 10
        }

        public enum OrderType
        {
            Default = 0,
            Product = 1
        }


        public enum OrderState : int
        {
            已取消 = -1,
            未完成 = 0,
            正在派送 = 2,
            派送完成 = 4,
            完成 = 9
        }

        public enum ProductOrderType : int
        {
            未标记 = 0,
            零售 = 1,
            外送 = 2,
            自提 = 3,
            跑腿 = 4,
            美团 = 5
        }

        public enum LocationType
        {
            bd09 = 0,
            gcj02 = 1,
            wgs84 = 2
        }
    }
}