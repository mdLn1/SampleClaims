using InsuranceClaimsApp.Exceptions;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Services;
using InsuranceClaimsApp.Tests.Helpers;
using System.Threading.Tasks;
using Xunit;

namespace InsuranceClaimsApp.Tests.Services
{
    public class LossTypeServiceTests
    {

        [Theory]
        [InlineData(0)]
        [InlineData(1110)]
        public async Task GetLossTypeById_LosstypeIdsDontExist_ThrowLossTypeNotFoundException(int lossTypeId)
        {
            // Arrange
            ILossTypeService lossTypeService = new LossTypeService(DatabaseHelper.GetInterviewContext());

            // Act
            LossTypeNotFoundException exception = await Assert.ThrowsAsync<LossTypeNotFoundException>(async () => await lossTypeService.GetLossTypeByIdAsync(lossTypeId));

            // Assert
            Assert.Equal($"Couldn't find loss type {lossTypeId}", exception.Message);
        }

        [Fact]
        public async Task GetLossTypeById_LosstypeIdExists_ReturnFoundLossType()
        {
            // Arrange
            ILossTypeService lossTypeService = new LossTypeService(DatabaseHelper.GetInterviewContext());

            // Act
            var result = await lossTypeService.GetLossTypeByIdAsync(1);

            // Assert
            Assert.Equal(1, result.LossTypeId);
        }
    }
}