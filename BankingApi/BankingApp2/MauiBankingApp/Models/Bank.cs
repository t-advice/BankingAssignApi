using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingApp.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BranchCode { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string OperatingHours { get; set; }  


    }
}
