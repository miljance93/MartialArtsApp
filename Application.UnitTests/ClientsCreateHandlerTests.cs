using Application.Clients;
using Application.DTO;
using Application.Interfaces;
using AutoFixture;
using Moq;
using Persistence.Repository;
using System;
using System.Threading;
using Xunit;
using static Application.Clients.Create;

namespace Application.UnitTests
{
    public class ClientsCreateHandlerTests
    {
        [Fact]
        public async void Handle_ClientAlreadyExists_ReturnsFalseForIsSuccess()
        {
            //ARANGE
            var clientRepository = new Mock<IClientRepository>();
            var handler = new Handler(clientRepository.Object);
            var fixture = new Fixture();
            var clientDto = fixture.Create<ClientDTO>();
            var command = new Command(clientDto);
            var cancellationToken = new CancellationToken();

            //ACT
            var result = await handler.Handle(command, cancellationToken);

            //ASSERT
            Assert.True(result.IsSuccess);
        }


    }
}
