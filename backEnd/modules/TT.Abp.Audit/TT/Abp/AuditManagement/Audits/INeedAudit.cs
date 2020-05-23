using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TT.Abp.AuditManagement.Audits
{
    public interface INeedAudit : INeedAuditBase
    {
        //需要审批的状态 Audit >0为正常开始审核状态,-1为被拒绝,null为未提交审核
        public int? Audit { get; set; }

        //现在审批的状态
        public int? AuditStatus { get; set; }

        [NotMapped]
        bool IsAudited
        {
            get
            {
                if (!Audit.HasValue) //未初始化
                {
                    return false;
                }

                if (Audit == -1)
                {
                    return false;
                }

                return Audit == AuditStatus;
            }
        }
    }

    public interface INeedAuditBase
    {
        public Guid? AuditFlowId { get; set; }
    }
}