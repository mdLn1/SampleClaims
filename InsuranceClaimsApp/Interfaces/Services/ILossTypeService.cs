using InsuranceClaimsApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Interfaces.Services
{
    public interface ILossTypeService
    {
        public Task<List<LossTypeDTO>> GetAllLossTypesAsync();

        public Task<LossTypeDTO> GetLossTypeByIdAsync(int lossTypeId);
    }
}