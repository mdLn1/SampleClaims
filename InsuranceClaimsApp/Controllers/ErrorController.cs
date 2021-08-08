using InsuranceClaimsApp.Models.Error;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InsuranceClaimsApp.Controllers
{
    public class ErrorController : Controller
    {
        #region Private

        private readonly ILogger<ErrorController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Private

        #region Public

        public ErrorController(ILogger<ErrorController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                _logger.LogInformation(exceptionFeature.Path + exceptionFeature.Error.Message);
                // TODO: log the error? or send email or something
            }
            return View();
        }

        public async Task<IActionResult> StatusCode(HttpStatusCode code)
        {
            var exceptionFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var responseData = new CustomPageViewModel();

            if (exceptionFeature != null)
            {
                responseData.SoughtPath =
                    exceptionFeature.OriginalPathBase
                    + exceptionFeature.OriginalPath
                    + exceptionFeature.OriginalQueryString;
            }

            responseData.StatusCode = (int)code;
            responseData.StatusCodeText = code.ToString();

            return View("CustomPage", responseData);
        }

        #endregion Public
    }
}