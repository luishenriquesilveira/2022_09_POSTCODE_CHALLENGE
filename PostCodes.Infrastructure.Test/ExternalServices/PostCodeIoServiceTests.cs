using FluentAssertions;
using PostCodes.Domain.Responses;
using PostCodes.Infrastructure.ExternalServices;
using Xunit;

namespace PostCodes.Infrastructure.Test.ExternalServices
{
    public class PostCodeIoServiceTests
    {
        private readonly HttpClient _httpClient = new();

        #region GetPostCode
        [Theory]
        [InlineData("N76RS")]
        [InlineData("SW46TA")]
        [InlineData("W1B3AG")]
        public async Task GetPostCode_ValidPostCodes_Return_Success(string postcode)
        {
            // Arrange
            PostCodeIoService postCodeService = new PostCodeIoService(_httpClient);

            // Act
            CommonResponse<PostCodeResponse> result = await postCodeService.GetPostCode(postcode);

            // Assert
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Succeeded.Should().BeTrue();
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Message.Should().BeEmpty();
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Data.Should().NotBeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("AAAAAAAAAAA")]
        public async Task GetPostCode_InvalidPostCodes_Return_Failure(string postcode)
        {
            // Arrange
            PostCodeIoService postCodeService = new PostCodeIoService(_httpClient);

            // Act
            CommonResponse<PostCodeResponse> result = await postCodeService.GetPostCode(postcode);

            // Assert
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Succeeded.Should().BeFalse();
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Message.Should().NotBeNullOrEmpty();
            result.Should().BeOfType<CommonResponse<PostCodeResponse>>().Which.Data.Should().BeNull();
        }
        #endregion
    }
}
