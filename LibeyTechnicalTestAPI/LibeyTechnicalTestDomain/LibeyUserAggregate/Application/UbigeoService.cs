using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
	public class UbigeoService : IUbigeoService
	{
		public IUbigeoRepository _repository;
		public UbigeoService(IUbigeoRepository repository)
		{
			_repository = repository;
		}

		public List<UbigeoResponses> GetUbigeo(string provinceCode, string regionCode)
		{
			var ubigeos = _repository.GetUbigeo(provinceCode, regionCode);
			return ubigeos;
		}
	}
}
