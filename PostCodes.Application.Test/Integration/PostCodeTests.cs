using FluentAssertions;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Responses;
using System.Net.Http.Json;
using Xunit;

namespace PostCodes.Application.Test.Integration
{
    public class PostCodeTests
    {
        #region GetPostCode
        [Theory]
        [InlineData("N76RS")]
        [InlineData("SW46TA")]
        [InlineData("W1B3AG")]
        public async Task GetPostCode_WithValidPostCode(string postcode)
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, false);

            var client = application.CreateClient();

            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<PostCode>>($"/postcode/GetPostCode/{postcode}");

            //Assert
            result.Should().BeOfType<CommonResponse<PostCode>>();
            result.Succeeded.Should().BeTrue();
            result.Message.Should().BeNullOrEmpty();
            result.Data.Should().BeOfType<PostCode>().Which.Should().NotBeNull();
        }

        [Theory]
        [InlineData("AAAAAAAAAAA")]
        public async Task GetPostCode_WithInvalidPostCode(string postcode)
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, false);

            var client = application.CreateClient();
            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<PostCode>>($"/postcode/GetPostCode/{postcode}");

            //Assert
            result.Should().BeOfType<CommonResponse<PostCode>>();
            result.Succeeded.Should().BeFalse();
            result.Message.Should().NotBeNullOrEmpty();
            result.Data.Should().BeNull();
        }
        #endregion

        #region GetSearchHistory
        [Fact]
        public async Task GetSearchHistory_WithRecordsNumber3_WithPostCodeData()
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, true);

            var client = application.CreateClient();

            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<IEnumerable<PostCode>>>($"/postcode/GetSearchHistory/3");

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
            result.Succeeded.Should().BeTrue();
            result.Message.Should().BeNullOrEmpty();
            result.Data.Should().NotBeNull();
            result.Data.Count().Should().BeLessThanOrEqualTo(3);
        }

        [Fact]
        public async Task GetSearchHistory_WithoutRecordsNumber_WithPostCodeData()
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, true);

            var client = application.CreateClient();

            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<IEnumerable<PostCode>>>($"/postcode/GetSearchHistory/");

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
            result.Succeeded.Should().BeTrue();
            result.Message.Should().BeNullOrEmpty();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetSearchHistory_WithoutPostCodeData()
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, false);

            var client = application.CreateClient();
            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<IEnumerable<PostCode>>>($"/postcode/GetSearchHistory/");

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
            result.Succeeded.Should().BeFalse();
            result.Message.Should().NotBeNullOrEmpty();
            result.Data.Should().BeNull();
        }
        #endregion

        #region GetFullSearchHistoryByDateLimit
        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_FilterYesterday_WithPostCodeData()
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, true);

            var client = application.CreateClient();

            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<IEnumerable<PostCode>>>("/postcode/GetFullSearchHistoryByDateLimit/");

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
            result.Succeeded.Should().BeTrue();
            result.Message.Should().BeNullOrEmpty();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_WithoutPostCodeData()
        {
            //Arrange
            await using var application = new ApplicationTest();
            await PostCodeMockData.CreatePostCodes(application, false);

            var client = application.CreateClient();
            //Act
            var result = await client.GetFromJsonAsync<CommonResponse<IEnumerable<PostCode>>>("/postcode/GetFullSearchHistoryByDateLimit/");

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
            result.Succeeded.Should().BeFalse();
            result.Message.Should().NotBeNullOrEmpty();
            result.Data.Should().BeNull();
        }

        #endregion
    }
}
