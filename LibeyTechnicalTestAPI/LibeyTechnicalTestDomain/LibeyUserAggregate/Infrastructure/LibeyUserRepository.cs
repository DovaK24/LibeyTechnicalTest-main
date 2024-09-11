using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

		public void Delete(string documentNumber)
		{
			var user = _context.LibeyUsers.SingleOrDefault(u => u.DocumentNumber == documentNumber);
			if (user != null)
			{
				_context.LibeyUsers.Remove(user);
				_context.SaveChanges();
			}
		}

		public LibeyUserResponse FindResponse(string documentNumber)
        {
			var userQuery = from libeyUser in _context.LibeyUsers
							where libeyUser.DocumentNumber.Equals(documentNumber)
							select new
							{
								libeyUser.DocumentNumber,
								libeyUser.Active,
								libeyUser.Address,
								libeyUser.DocumentTypeId,
								libeyUser.Email,
								libeyUser.FathersLastName,
								libeyUser.MothersLastName,
								libeyUser.Name,
								libeyUser.Password,
								libeyUser.Phone,
								libeyUser.UbigeoCode // Asegúrate de que esta propiedad esté disponible en tu entidad
							};

			var userResult = userQuery.FirstOrDefault();

			if (userResult != null)
			{
				var ubigeoCodes = _context.Ubigeos
					.Where(ubigeo => ubigeo.UbigeoCode == userResult.UbigeoCode)
					.FirstOrDefault();

				return new LibeyUserResponse
				{
					DocumentNumber = userResult.DocumentNumber,
					Active = userResult.Active,
					Address = userResult.Address,
					DocumentTypeId = userResult.DocumentTypeId,
					Email = userResult.Email,
					FathersLastName = userResult.FathersLastName,
					MothersLastName = userResult.MothersLastName,
					Name = userResult.Name,
					Password = userResult.Password,
					Phone = userResult.Phone,
					UbigeoCode = ubigeoCodes.UbigeoCode,
					ProvinceCode = ubigeoCodes.ProvinceCode,
					RegionCode = ubigeoCodes.RegionCode
				};
			}
			else
			{
				return new LibeyUserResponse();
			}
		}

		public void Update(LibeyUser libeyUser)
		{
			_context.LibeyUsers.Update(libeyUser);
			_context.SaveChanges();
		}
	}
}