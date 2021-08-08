using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceClaimsApp.Interfaces.Services;
using InsuranceClaimsApp.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace InsuranceClaimsApp.Controllers
{
    [Authorize]
    public class LossTypesController : Controller
    {
        private readonly ILossTypeService _lossTypeService;

        public LossTypesController(ILossTypeService lossTypeService)
        {
            _lossTypeService = lossTypeService;
        }

        // GET: LossTypes
        public async Task<IActionResult> Index()
        {
            return View(await _lossTypeService.GetAllLossTypesAsync());
        }

        // GET: LossTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                return View(await _lossTypeService.GetLossTypeByIdAsync((int)id));
            }
            catch (LossTypeNotFoundException lossTypeNotFoundException)
            {
                return NotFound();
            }
        }
    }
}