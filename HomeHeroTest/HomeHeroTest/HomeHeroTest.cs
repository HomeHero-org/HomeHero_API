using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using HomeHero_API.Repository.IRepository;

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
}
