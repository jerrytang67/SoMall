using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TT.Abp.VisitorManagement.Domain;

namespace TT.Abp.VisitorManagement.Application.Dtos
{
    /// <summary>
    /// <see cref="VisitorLog"/>
    /// </summary>
    public class VisitorLogDto
    {
        public Guid Id { get; set; }
        public Guid FormId { get; set; }
        public List<FormItemDto> FormJson { get; set; }
        public Guid? CredentialId { get; set; }
        public CredentialDto Credential { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public DateTimeOffset? LeaveTime { get; set; }

        public string Html { get; set; }
    }
}