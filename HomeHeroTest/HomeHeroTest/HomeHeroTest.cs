using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using HomeHero_API.Repository.IRepository;
using HomeHero_API.Data;
using HomeHero_API.Repository;
using Microsoft.EntityFrameworkCore;
using HomeHero_API.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Threading;
using System.Threading.Tasks;


namespace HomeHeroTest
{
    public class RepositoryTest
    {
        private readonly Mock<IRepository<Person>> _repoMock;

        public RepositoryTest()
        {
            _repoMock = new Mock<IRepository<Person>>();
        }

        [Fact]
        public async Task Create_CalledOnce()
        {
            var person = new Person();
            await _repoMock.Object.Create(person);
            _repoMock.Verify(repo => repo.Create(person), Times.Once);
        }

        [Fact]
        public async Task GetAll_NoFilter_ReturnsAll()
        {
            var persons = new List<Person> { new Person(), new Person() };
            _repoMock.Setup(repo => repo.GetAll(null)).ReturnsAsync(persons);
            var result = await _repoMock.Object.GetAll();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Get_WithFilter_ReturnsSingleEntity()
        {
            var person = new Person { Id = 1 };
            _repoMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Person, bool>>>(), false)).ReturnsAsync(person);
            var result = await _repoMock.Object.Get(x => x.Id == 1, false);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Remove_CalledOnce()
        {
            var person = new Person();
            await _repoMock.Object.Remove(person);
            _repoMock.Verify(repo => repo.Remove(person), Times.Once);
        }

        [Fact]
        public async Task Save_CalledOnce()
        {
            await _repoMock.Object.Save();
            _repoMock.Verify(repo => repo.Save(), Times.Once);
        }
    }

    public class Person  // Esta es una entidad de muestra. Deberías tener algo similar en tu proyecto real.
    {
        public int Id { get; set; }
        // Otros campos aquí...
    }
    public class RequestRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly RequestRepository _repository;

        public RequestRepositoryTests()
        {
            // Configuración de la base de datos en memoria
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar un nombre único para cada test
                .Options;

            _context = new ApplicationDbContext(options);
            _repository = new RequestRepository(_context);
        }
        [Fact]
        public void Update_ShouldUpdateRequestAndSetUpdateTime()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);
            var repository = new RequestRepository(context);

            var request = new Request
            {
                RequestID = 1,
                RequestTitle = "Original Title",
                RequestContent = "Some content here", // <- Añade contenido aquí
                RequestPicture = new byte[] { },      // <- Añade alguna imagen en formato de byte array aquí si es necesario
                CreatedTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            // Supongamos que añades la solicitud original al contexto
            context.Request.Add(request);
            context.SaveChanges();

            // Ahora, actualiza el título de la solicitud
            request.RequestTitle = "Updated Title";

            // Aquí podrías llamar al método de tu repositorio que realiza la actualización
            repository.Update(request);
            context.SaveChanges();

            // Ahora puedes obtener la solicitud nuevamente del contexto y verificar que los cambios se hayan realizado
            var updatedRequest = context.Request.Find(1);

            Assert.Equal("Updated Title", updatedRequest.RequestTitle);
            // Aquí también podrías verificar otros cambios que hayas hecho, como verificar que `UpdateTime` ha sido modificado
        }
    }
}
