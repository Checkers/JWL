using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWL.Service.DTO
{
    public class QueryTrendDTO
    {
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string SrcAddress { get; set; }
        public string DestAddress { get; set; }
        public string LorryNo { get; set; }
        public string LorryTypeName { get; set; }
        public double? LorryLength { get; set; }
        public double? CarryWeight { get; set; }
        public string CurrentLocation { get; set; }
    }
}
