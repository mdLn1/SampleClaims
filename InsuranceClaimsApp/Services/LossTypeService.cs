using InsuranceClaimsApp.ContextData;
using InsuranceClaimsApp.Exceptions;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Services
{
    public class LossTypeService : ILossTypeService
    {
        #region Private

        private readonly InterviewContext _interviewContext;

        #endregion Private

        #region Public

        public LossTypeService(InterviewContext interviewContext)
        {
            _interviewContext = interviewContext;
        }

        public async Task<List<LossTypeDTO>> GetAllLossTypesAsync()
        {
            return await _interviewContext.LossTypes.Select(x => new LossTypeDTO(x)).ToListAsync();
        }

        public async Task<LossTypeDTO> GetLossTypeByIdAsync(int lossTypeId)
        {
            if (lossTypeId < 1)
            {
                throw new LossTypeNotFoundException($"Couldn't find loss type {lossTypeId}");
            }

            var foundLossType = await _interviewContext.LossTypes.FirstOrDefaultAsync(x => x.LossTypeId == lossTypeId);

            if (foundLossType == null)
            {
                throw new LossTypeNotFoundException($"Couldn't find loss type {lossTypeId}");
            }

            return new LossTypeDTO(foundLossType);
        }

        #endregion Public
    }
}