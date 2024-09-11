using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
	[ApiController]
	[Route("[controller]")]
	public class RegionController : ControllerBase
	{
		private readonly IRegionService _regionService;

		public RegionController(IRegionService regionService)
		{
			_regionService = regionService;
		}

		[HttpGet]
		public IActionResult GetDocumentTypes()
		{
			var regions = _regionService.GetRegion();
			return Ok(regions);
		}
	}
}
