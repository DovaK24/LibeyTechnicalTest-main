using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
	public class ProvinceService : IProvinceService
	{
		public IProvinceRepository _repository;
		public ProvinceService(IProvinceRepository repository)
		{
			_repository = repository;
		}

		public List<ProvinceResponses> GetProvince(string regionCode)
		{
			var province = _repository.GetProvince(regionCode);
			return province;
		}
	}
}
