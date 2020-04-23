using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Mall.Domain.Pays
{
    [Serializable]
    public class TenPayNotifyDto : EntityDto<Guid>
    {
        public string out_trade_no { get; set; }
        public string result_code { get; set; }
        public string fee_type { get; set; }
        public string return_code { get; set; }
        public string total_fee { get; set; }
        public string mch_id { get; set; }
        public string cash_fee { get; set; }
        public string openid { get; set; }
        public string transaction_id { get; set; }
        public string sign { get; set; }
        public string bank_type { get; set; }
        public string appid { get; set; }
        public string time_end { get; set; }
        public string trade_type { get; set; }
        public string nonce_str { get; set; }
        public string is_subscribe { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }

    public class TenPayNotify : AggregateRoot<Guid>
    {
        [StringLength(40)] public string out_trade_no { get; set; }
        [StringLength(40)] public string result_code { get; set; }
        [StringLength(40)] public string fee_type { get; set; }
        [StringLength(40)] public string return_code { get; set; }
        [StringLength(40)] public string total_fee { get; set; }
        [StringLength(40)] public string mch_id { get; set; }
        [StringLength(40)] public string cash_fee { get; set; }
        [StringLength(40)] public string openid { get; set; }
        [StringLength(40)] public string transaction_id { get; set; }
        [StringLength(40)] public string sign { get; set; }
        [StringLength(40)] public string bank_type { get; set; }
        [StringLength(40)] public string appid { get; set; }
        [StringLength(40)] public string time_end { get; set; }
        [StringLength(40)] public string trade_type { get; set; }
        [StringLength(40)] public string nonce_str { get; set; }
        [StringLength(40)] public string is_subscribe { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}