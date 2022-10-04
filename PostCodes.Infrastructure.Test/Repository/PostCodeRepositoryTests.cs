using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Responses;
using PostCodes.Infrastructure.Context;
using PostCodes.Infrastructure.Repository;
using PostCodes.Infrastructure.Test.Shared;
using Xunit;

namespace PostCodes.Infrastructure.Test.Repository
{
    public class PostCodeRepositoryTests
    {
        #region GetSearchHistory
        [Fact]
        public async Task GetSearchHistory_RecordsNumberNull_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCode expectedToReturn = Utils.FactoryPostCode();
            context.PostCodes.Add(expectedToReturn);
            context.SaveChanges();

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetSearchHistory(null);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().ContainEquivalentOf(expectedToReturn);
        }

        [Fact]
        public async Task GetSearchHistory_RecordsNumber0_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            context.PostCodes.Add(Utils.FactoryPostCode());
            context.SaveChanges();

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetSearchHistory(0);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task GetSearchHistory_RecordsNumber3_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            context.PostCodes.Add(Utils.FactoryPostCode());
            context.PostCodes.Add(Utils.FactoryPostCode());
            context.PostCodes.Add(Utils.FactoryPostCode());
            context.PostCodes.Add(Utils.FactoryPostCode());
            context.SaveChanges();

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetSearchHistory(3);

            //Assert
            result.Count().Should().BeLessThanOrEqualTo(3);
        }

        [Fact]
        public async Task GetSearchHistory_Return_FailEmpty()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetSearchHistory(null);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().BeNullOrEmpty();
        }
        #endregion

        #region GetSearchHistory
        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_DateYesterday_Return_Success()
        {
            // Arrange
            DateTime date = DateTime.Now;
            date = date.AddDays(-1);

            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCode expectedToReturn = Utils.FactoryPostCode();
            context.PostCodes.Add(expectedToReturn);
            context.SaveChanges();

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetFullSearchHistoryByDateLimit(date);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().ContainEquivalentOf(expectedToReturn);
        }

        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_DateFuture_Return_Success()
        {
            // Arrange
            DateTime date = DateTime.Now;
            date = date.AddDays(1);

            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCode expectedToReturn = Utils.FactoryPostCode();
            context.PostCodes.Add(expectedToReturn);
            context.SaveChanges();

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetFullSearchHistoryByDateLimit(date);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().BeNullOrEmpty();
        }


        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_Return_FailEmpty()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCodeRepository postCodeRepository = new PostCodeRepository(context);

            // Act
            IEnumerable<PostCode> result = await postCodeRepository.GetFullSearchHistoryByDateLimit(DateTime.Now);

            //Assert
            result.Should().AllBeOfType<PostCode>().Which.Should().BeNullOrEmpty();
        }
        #endregion
    }
}
