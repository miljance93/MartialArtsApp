using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuditLogs
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }
    }
}
