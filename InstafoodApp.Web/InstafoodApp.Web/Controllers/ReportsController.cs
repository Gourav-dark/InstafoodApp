using AspNetCore.Reporting;
using InstafoodApp.BusinessLogic.Repositories.Abstract;
using InstafoodApp.Web.WebHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Mime;

namespace InstafoodApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ProductRPT()
        {
            var products = await _unitOfWork.product.GetAllAsync();
            DataTable productDataTable=ConvertListToDataTable.ToDataTable(products.ToList());
            string wwwRootFolder=_webHostEnvironment.WebRootPath;
            string reportPath = Path.Combine(wwwRootFolder, @"Reports\ProductRPT.rdlc");

            var localReport = new LocalReport(reportPath);

            localReport.AddDataSource("dsProduct", productDataTable);
            var reportResult = localReport.Execute(RenderType.Pdf, 1, null);
            return File(reportResult.MainStream, MediaTypeNames.Application.Octet, "ProductPpt.pdf");
        }
    }
}
