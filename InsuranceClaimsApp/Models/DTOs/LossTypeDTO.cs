using InsuranceClaimsApp.ContextData;

namespace InsuranceClaimsApp.Models.DTOs
{
    public class LossTypeDTO
    {
        public LossTypeDTO(LossType lossTypes)
        {
            LossTypeId = lossTypes.LossTypeId;
            LossTypeCode = lossTypes.LossTypeCode;
            LossTypeDescription = lossTypes.LossTypeDescription;
            
        }

        public int LossTypeId { get; set; }

        public string LossTypeCode { get; set; }

        public string LossTypeDescription { get; set; }
    }
}