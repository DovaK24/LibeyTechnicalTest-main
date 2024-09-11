using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
	public class DocumentTypeService : IDocumentTypeService
	{
		public IDocumentTypeRepository _repository;

		public DocumentTypeService(IDocumentTypeRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<DocumentType> GetDocumentType()
		{
			var documentType = _repository.GetDocumentType();
			return documentType;
		}
	}
}
