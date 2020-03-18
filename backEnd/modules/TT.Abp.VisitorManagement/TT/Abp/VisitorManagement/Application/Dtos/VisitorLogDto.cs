using System;
using TT.Abp.VisitorManagement.Domain;

namespace TT.Abp.VisitorManagement.Application.Dtos
{
    /// <summary>
    /// <see cref="VisitorLog"/>
    /// </summary>
    public class VisitorLogDto
    {
        public Guid FormId { get; set; }
        public string FormJson { get; set; }
        public Guid? CredentialId { get; set; }
        public CredentialDto Credential { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public DateTimeOffset? LeaveTime { get; set; }

    }
}