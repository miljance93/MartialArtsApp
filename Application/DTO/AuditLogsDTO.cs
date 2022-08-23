using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AuditLogsDTO
    {
        public string Method { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
    }
}
