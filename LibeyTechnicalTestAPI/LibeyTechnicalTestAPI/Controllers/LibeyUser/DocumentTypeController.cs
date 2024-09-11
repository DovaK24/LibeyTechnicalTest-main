using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
	[ApiController]
	[Route("[controller]")]
	public class DocumentTypeController : ControllerBase
	{
		private readonly IDocumentTypeService _documentTypeService;

		public DocumentTypeController(IDocumentTypeService documentTypeService)
		{
			_documentTypeService = documentTypeService;
		}

		[HttpGet]
		public IActionResult GetDocumentTypes()
		{
			var documentTypes = _documentTypeService.GetDocumentType();
			return Ok(documentTypes);
		}
	}
}
