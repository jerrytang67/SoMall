using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

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

    public class TenPayNotify : AggregateRoot<Guid>, IHasCreationTime
    {
        public virtual string out_trade_no { get; set; }
        public virtual string result_code { get; set; }
        public virtual string fee_type { get; set; }
        public virtual string return_code { get; set; }
        public virtual string total_fee { get; set; }
        public virtual string mch_id { get; set; }
        public virtual string cash_fee { get; set; }
        public virtual string openid { get; set; }
        public virtual string transaction_id { get; set; }
        public virtual string sign { get; set; }
        public virtual string bank_type { get; set; }
        public virtual string appid { get; set; }
        public virtual string time_end { get; set; }
        public virtual string trade_type { get; set; }
        public virtual string nonce_str { get; set; }
        public virtual string is_subscribe { get; set; }

        public virtual DateTime CreationTime { get; set; } = DateTime.Now;
    }
}