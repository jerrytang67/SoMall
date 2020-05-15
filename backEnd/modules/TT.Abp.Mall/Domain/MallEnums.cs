using System.ComponentModel.DataAnnotations;

namespace TT.Abp.Mall.Domain
{
    public class MallEnums
    {
        public enum PayState
        {
            取消 = -1,
            未支付 = 0,
            已支付 = 1,
            待退款 = 2,
            已退款 = 3,
            部分退款 = 4
        }

        public enum PartnerState
        {
            待审核 = 0,
            驳回 = -1,
            成功 = 10
        }


        public enum PayType
        {
            未支付 = 0,
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
            完成 = 9,
            售后 = 11,
            退款中 = 12,
            退款完成 = 13
        }

        public enum ProductOrderType : int
        {
            未标记 = 0,
            零售 = 1,
            外送 = 2,
            自提 = 3,
            跑腿 = 4,
            美团 = 5,
            快递 = 6
        }

        public enum LocationType
        {
            bd09 = 0,
            gcj02 = 1,
            wgs84 = 2
        }

        public enum UseType
        {
            全场通用 = 0,
            指定分类 = 1,
            指定商品 = 2
        }
    }
}