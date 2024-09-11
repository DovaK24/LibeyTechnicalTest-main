using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
	[ApiController]
	[Route("[controller]")]
	public class UbigeoController : ControllerBase
	{
		private readonly IUbigeoService _ubigeoService;
		public UbigeoController(IUbigeoService ubigeoService)
		{
			_ubigeoService = ubigeoService;
		}
		[HttpGet]
		[Route("{provinceCode}/{regionCode}")]
		public IActionResult GetUbigeo(string provinceCode, string regionCode)
		{
			var documentTypes = _ubigeoService.GetUbigeo(provinceCode, regionCode);
			return Ok(documentTypes);
		}
	}
}
