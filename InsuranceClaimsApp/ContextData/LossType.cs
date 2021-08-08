using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InsuranceClaimsApp.ContextData
{
    [Table("LossTypes")]
    public class LossType
    {
        public LossType(string lossTypeCode, string lossTypeDescription)
        {
            LossTypeCode = lossTypeCode;
            LossTypeDescription = lossTypeDescription;
        }

        [Key]
        public int LossTypeId { get; private set; }
        public string LossTypeCode { get; private set; }
        public string LossTypeDescription { get; private set; }

        private LossType()
        {

        }
    }
}
