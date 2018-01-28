using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using trturino.GerenciadorGames.Services.API.Controllers;
using trturino.GerenciadorGames.Services.API.Model;
using Xunit;

namespace UnitTest.Amigo.App
{
    public class AmigoControllerTest
    {
        private readonly Mock<IAmigoRespository> _repoMock;

        public AmigoControllerTest()
        {
            _repoMock = new Mock<IAmigoRespository>();
        }

        [Fact]
        public async Task GetAmigoTeste()
        {
            var amigoFake = GetAmigo();

            _repoMock.Setup(x => x.GetAmigoAsync
                (
                    It.IsAny<int>()
                ))
                .Returns(Task.FromResult(amigoFake));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Get(1);

            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task GetNenhumAmigoTeste()
        {
            _repoMock.Setup(x => x.GetAmigoAsync
                (
                    It.IsAny<int>()
                ))
                .Returns(Task.FromResult(default(trturino.GerenciadorGames.Services.API.Model.Amigo)));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Get(1);

            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task GetTodosAmigosTeste()
        {
            _repoMock.Setup(x => x.GetTodosAmigosAsync())
                .Returns(Task.FromResult(GetAmigos()));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Get();

            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public async Task PostTeste()
        {
            var amigo = GetAmigo();

            _repoMock.Setup(x => x.AddAmigoAsync
                (
                    It.IsAny<trturino.GerenciadorGames.Services.API.Model.Amigo>()
                ))
                .Returns(Task.FromResult(amigo));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Post(amigo);

            Assert.IsType<AcceptedResult>(actionResult);
        }

        [Fact]
        public async Task PostNullTeste()
        {

            _repoMock.Setup(x => x.AddAmigoAsync
                (
                    It.IsAny<trturino.GerenciadorGames.Services.API.Model.Amigo>()
                ))
                .Returns(Task.FromResult(default(trturino.GerenciadorGames.Services.API.Model.Amigo)));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Post(null);

            Assert.IsType<BadRequestResult>(actionResult);
        }

        [Fact]
        public async Task PutTeste()
        {
            var amigo = GetAmigo();

            _repoMock.Setup(x => x.AddAmigoAsync
                (
                    It.IsAny<trturino.GerenciadorGames.Services.API.Model.Amigo>()
                ))
                .Returns(Task.FromResult(amigo));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Put(amigo);

            Assert.IsType<AcceptedResult>(actionResult);
        }

        [Fact]
        public async Task PutNullTeste()
        {

            _repoMock.Setup(x => x.AddAmigoAsync
                (
                    It.IsAny<trturino.GerenciadorGames.Services.API.Model.Amigo>()
                ))
                .Returns(Task.FromResult(default(trturino.GerenciadorGames.Services.API.Model.Amigo)));

            var amigoController = new AmigoController(_repoMock.Object);
            var actionResult = await amigoController.Put(null);

            Assert.IsType<BadRequestResult>(actionResult);
        }

        private trturino.GerenciadorGames.Services.API.Model.Amigo GetAmigo()
        {
            return  new trturino.GerenciadorGames.Services.API.Model.Amigo(1, "Amigo 1", "1111");
        }

        private IEnumerable<trturino.GerenciadorGames.Services.API.Model.Amigo> GetAmigos()
        {
            return new[]
            {
                new trturino.GerenciadorGames.Services.API.Model.Amigo(1, "Amigo 1", "1111"),
                new trturino.GerenciadorGames.Services.API.Model.Amigo(2, "Amigo 2", "2222"),
                new trturino.GerenciadorGames.Services.API.Model.Amigo(3, "Amigo 3", "3333"),
                new trturino.GerenciadorGames.Services.API.Model.Amigo(4, "Amigo 4", "4444")
            };
        }
    }
}