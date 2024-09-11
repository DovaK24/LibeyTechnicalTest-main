using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
	[ApiController]
	[Route("[controller]")]
	public class ProvinceController : ControllerBase
	{
		private readonly IProvinceService _provinceService;
		public ProvinceController(IProvinceService provinceService)
		{
			_provinceService = provinceService;
		}
		[HttpGet]
		[Route("{regionCode}")]
		public IActionResult GetProvince(string regionCode)
		{
			var documentTypes = _provinceService.GetProvince(regionCode);
			return Ok(documentTypes);
		}
	}
}
