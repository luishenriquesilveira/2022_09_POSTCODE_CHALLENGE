using PostCodes.Domain.Test.Shared;
using Microsoft.EntityFrameworkCore;
using PostCodes.Infrastructure.Context;
using Xunit;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Services;
using PostCodes.Infrastructure.Repository;
using PostCodes.Domain.Responses;
using FluentAssertions;
using PostCodes.Domain.Interfaces;
using Moq;

namespace PostCodes.Domain.Test.Services
{
    public class PostCodeServiceTest
    {
        private readonly Mock<IPostCodeIoService> externalServiceStub = new();
        private readonly Mock<IPostCodeRepository> serviceStub = new();

        #region GetPostCode
        [Fact]
        public async Task GetPostCode_Return_Success()
        {
            // Arrange
            externalServiceStub.Setup(service => service.GetPostCode(It.IsAny<string>()))
                .ReturnsAsync(CommonResponse<PostCodeResponse>.Success(Utils.FactoryPostCodeResponse(true)));

            PostCodeService postCodeService = new PostCodeService(
                serviceStub.Object,
                externalServiceStub.Object,
                Utils.createMapperConfig());

            // Act
            CommonResponse<PostCode> result = await postCodeService.GetPostCode(Utils.GenerateRandomString(10));

            // Assert
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Succeeded.Should().BeTrue();
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Message.Should().BeEmpty();
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Data.Should().NotBeNull();
        }

        public async Task GetPostCode_Return_NotFound()
        {
            // Arrange
            externalServiceStub.Setup(service => service.GetPostCode(It.IsAny<string>()))
                .ReturnsAsync(CommonResponse<PostCodeResponse>.Fail(Utils.GenerateRandomString(10)));

            PostCodeService postCodeService = new PostCodeService(
                serviceStub.Object,
                externalServiceStub.Object,
                Utils.createMapperConfig());

            // Act
            CommonResponse<PostCode> result = await postCodeService.GetPostCode(Utils.GenerateRandomString(10));

            // Assert
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Succeeded.Should().BeFalse();
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Message.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<CommonResponse<PostCode>>().Which.Data.Should().BeNull();
        }
        #endregion

        #region GetSearchHistory
        [Fact]
        public async Task GetSearchHistory_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            context.PostCodes.Add(Utils.FactoryPostCode());
            context.SaveChanges();

            PostCodeService postCodeService = new PostCodeService(
                new PostCodeRepository(context),
                null,
                Utils.createMapperConfig());

            // Act
            CommonResponse<IEnumerable<PostCode>> result = await postCodeService.GetSearchHistory(null);

            // Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Succeeded.Should().BeTrue();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Message.Should().BeEmpty();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetSearchHistory_Return_Fail_Empty()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCodeService postCodeService = new PostCodeService(
                new PostCodeRepository(context),
                null,
                Utils.createMapperConfig());

            // Act
            CommonResponse<IEnumerable<PostCode>> result = await postCodeService.GetSearchHistory(null);

            // Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Succeeded.Should().BeFalse();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Message.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Data.Should().BeNullOrEmpty();
        }
        #endregion

        #region GetFullSearchHistoryByDateLimit
        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            context.PostCodes.Add(Utils.FactoryPostCode());
            context.SaveChanges();

            PostCodeService postCodeService = new PostCodeService(
                new PostCodeRepository(context),
                null,
                Utils.createMapperConfig());

            // Act
            CommonResponse<IEnumerable<PostCode>> result = await postCodeService.GetFullSearchHistoryByDateLimit();

            // Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Succeeded.Should().BeTrue();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Message.Should().BeEmpty();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_Return_Fail_Empty()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCodeService postCodeService = new PostCodeService(
                new PostCodeRepository(context),
                null,
                Utils.createMapperConfig());

            // Act
            CommonResponse<IEnumerable<PostCode>> result = await postCodeService.GetFullSearchHistoryByDateLimit();

            // Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Succeeded.Should().BeFalse();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Message.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Data.Should().BeNullOrEmpty();
        }
        #endregion

        #region AddPostCodeSearch
        [Fact]
        public async Task AddPostCodeSearch_Return_Success()
        {
            // Arrange
            AppDbContext context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Utils.GenerateRandomString(10)).Options);

            PostCode expectedToReturn = Utils.FactoryPostCode();

            PostCodeService postCodeService = new PostCodeService(
                new PostCodeRepository(context),
                null,
                Utils.createMapperConfig());

            // Act
            await postCodeService.AddPostCodeSearch(expectedToReturn);
            CommonResponse<IEnumerable<PostCode>> result = await postCodeService.GetSearchHistory(null);

            // Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>().Which.Data.Should().NotBeNull();
        }
        #endregion
    }
}
