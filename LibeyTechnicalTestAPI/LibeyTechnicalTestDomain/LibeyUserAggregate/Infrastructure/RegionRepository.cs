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
	public class RegionRepository : IRegionRepository
	{
		private readonly Context _context;
		public RegionRepository(Context context)
		{
			_context = context;
		}

		public IEnumerable<Region> GetRegion()
		{
			var regions = _context.Regions.ToList();
			return regions;
		}
	}
}
