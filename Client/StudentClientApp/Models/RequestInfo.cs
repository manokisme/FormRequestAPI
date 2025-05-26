using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClientApp.Models
{
    public class RequestInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string StudentId { get; set; }
        public string Program { get; set; }
        public string FormRequested { get; set; }
        public string PurposeOfRequest { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
