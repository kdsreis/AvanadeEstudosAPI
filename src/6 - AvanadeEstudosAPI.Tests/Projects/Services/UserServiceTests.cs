using AutoMapper;
using AvanadeEstudosAPI.Domain.Entities;
using AvanadeEstudosAPI.Domain.Interfaces;
using AvanadeEstudosAPI.Services.DTO;
using AvanadeEstudosAPI.Services.Interfaces;
using AvanadeEstudosAPI.Services.Services;
using AvanadeEstudosAPI.Tests.Configurations;
using FluentAssertions;
using Moq;
using Xunit;

namespace AvanadeEstudosAPI.Tests.Projects.Services
{
    public class UserServiceTests
    {
        // Subject Under Test
        private readonly IUserService _sut;
        
        // Map
        private readonly IMapper _mapper;

        //Mock
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _userRepositoryMock = new Mock<IUserRepository>();

            _sut = new UserService(
                mapper: _mapper,
                userRepository: _userRepositoryMock.Object);
        }

        [Fact(DisplayName = "Create Valid User")] // NomeMetodo Condição ResultadoEsperado
        public async Task Create_WhenUserIsValid_ReturnsUserDTO()
        {
            // Arrange => arruma os dados e configurações para o teste acontecer
            var userToCreate = new UserDTO { Name = "Kleber", Email = "kleber.reis@teste.com", Password = "Teste@3testes"};
            var userCreated = _mapper.Map<User>(userToCreate);

            _userRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(() => userCreated);

            // Act => chama a função que se quer testar
            var result = await _sut.CreateAsync(userToCreate);

            // Assert => verificar o resultado
            result.Should()
                .BeEquivalentTo(_mapper.Map<UserDTO>(userCreated));

        }

    }
}
