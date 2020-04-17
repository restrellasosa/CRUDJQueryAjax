﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JQueryAjax.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        [Column(TypeName="nvarchar(12)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(12)")]
        public string BeneficiaryName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string BankName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string SWIFTCode { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public int Amount { get; set; }
    }
}
