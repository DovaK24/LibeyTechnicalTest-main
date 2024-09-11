using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
	public class DocumentTypeRepository : IDocumentTypeRepository
	{
		private readonly Context _context;
		public DocumentTypeRepository(Context context)
		{
			_context = context;
		}

		public IEnumerable<DocumentType> GetDocumentType()
		{
			var documentType = _context.DocumentTypes.ToList();
			return documentType;
		}
	}
}
