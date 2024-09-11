using Moq;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestTest
{
	[TestClass]
	public class LibeyUserAggregateTests
	{
		private Mock<ILibeyUserRepository> _mockRepository;
		private LibeyUserAggregate _userAggregate;

		[TestInitialize]
		public void Setup()
		{
			_mockRepository = new Mock<ILibeyUserRepository>();
			_userAggregate = new LibeyUserAggregate(_mockRepository.Object);
		}

		[TestMethod]
		public void Create_ShouldCallRepositoryCreate()
		{
			var command = new UserUpdateorCreateCommand
			{
				DocumentNumber = "123456",
				DocumentTypeId = 1,
				Name = "John",
				FathersLastName = "Doe",
				MothersLastName = "Smith",
				Address = "123 Main St",
				UbigeoCode = "150101",
				Phone = "555-1234",
				Email = "john@example.com",
				Password = "Password123!"
			};

			_userAggregate.Create(command);

			_mockRepository.Verify(repo => repo.Create(It.IsAny<LibeyUser>()), Times.Once);
		}

		[TestMethod]
		public void FindResponse_ShouldReturnCorrectResponse()
		{
			var documentNumber = "12345678";
			var expectedUser = new LibeyUserResponse
			{
				DocumentNumber = documentNumber,
				DocumentTypeId = 1,
				Name = "John",
				FathersLastName = "Doe",
				MothersLastName = "Smith",
				Address = "123 Main St",
				UbigeoCode = "150101",
				Phone = "555-1234",
				Email = "john@example.com",
				Password = "Password123!"
			};

			_mockRepository.Setup(repo => repo.FindResponse(documentNumber)).Returns(expectedUser);
			var result = _userAggregate.FindResponse(documentNumber);
			Assert.AreEqual(expectedUser, result);
		}
		[TestMethod]
		public void Delete_ShouldRemoveExistingUser()
		{
			var documentNumber = "123456789";

			_userAggregate.Delete(documentNumber);

			_mockRepository.Verify(r => r.Delete(documentNumber), Times.Once);
		}
		[TestMethod]
		public void Update_ShouldUpdateExistingUser()
		{
			var command = new UserUpdateorCreateCommand
			{
				DocumentNumber = "123456789",
				DocumentTypeId = 1,
				Name = "John Doe",
				FathersLastName = "Doe",
				MothersLastName = "Smith",
				Address = "123 Main St",
				UbigeoCode = "001",
				Phone = "1234567890",
				Email = "johndoe@example.com",
				Password = "password"
			};

			_userAggregate.Update(command);

			_mockRepository.Verify(r => r.Update(It.IsAny<LibeyUser>()), Times.Once);
		}
	}
}
