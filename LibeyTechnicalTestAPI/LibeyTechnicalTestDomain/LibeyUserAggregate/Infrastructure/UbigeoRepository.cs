﻿using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
	public class UbigeoRepository : IUbigeoRepository
	{
		private readonly Context _context;
		public UbigeoRepository(Context context)
		{
			_context = context;
		}

		public List<UbigeoResponses> GetUbigeo(string provinceCode, string regionCode)
		{
			var q = from ubigeo in _context.Ubigeos.Where(x => x.ProvinceCode.Equals(provinceCode) && x.RegionCode.Equals(regionCode))
					select new UbigeoResponses()
					{
						UbigeoCode = ubigeo.UbigeoCode,
						UbigeoDescription = ubigeo.UbigeoDescription
					};
			var list = q.ToList();
			if (list.Any()) return list;
			else return new List<UbigeoResponses>();
		}
	}
}
