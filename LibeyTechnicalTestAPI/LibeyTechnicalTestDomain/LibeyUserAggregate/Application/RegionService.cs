using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
	public class RegionService : IRegionService
	{
		public IRegionRepository _repository;
		public RegionService(IRegionRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<Region> GetRegion()
		{
			var regions = _repository.GetRegion();
			return regions;
		}
	}
}
