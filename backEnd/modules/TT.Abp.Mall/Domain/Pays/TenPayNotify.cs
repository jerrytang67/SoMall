using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.Mall.Domain.Pays
{
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