using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Mall.Domain.Shares
{
    public class QrDetail : CreationAuditedEntity<Guid>, IMultiTenant
    {
        private QrDetail()
        {
        }

        public QrDetail([NotNull] string appName, [NotNull] string eventName, string eventKey = null, Guid? tenantId = null)
        {
            AppName = appName;
            EventName = eventName;
            TenantId = tenantId;
            EventKey = eventKey;
        }

        [NotNull] public string AppName { get; protected set; }

        [NotNull] public string EventName { get; protected set; }

        [CanBeNull] public string EventKey { get; protected set; }

        /// <summary>
        /// Params must camelCase because api's jsonConvert not do it
        /// </summary>
        public Dictionary<string, string> Params { get; protected set; } = new Dictionary<string, string>();

        public int ViewCount { get; protected set; }

        public Guid? TenantId { get; protected set; }

        /// <summary>
        /// 微信小程序
        /// 必须是已经发布的小程序存在的页面（否则报错），例如 pages/index/index, 根路径前不要填加 /,不能携带参数（参数请放在scene字段里），如果不填写这个字段，默认跳主页面
        /// </summary>
        [CanBeNull]
        public string Path { get; protected set; }

        [CanBeNull] public string QrImageUrl { get; protected set; }

        public void Viewd()
        {
            ViewCount += 1;
        }

        public void SetQrUrl(string url)
        {
            QrImageUrl = url;
        }
    }
}