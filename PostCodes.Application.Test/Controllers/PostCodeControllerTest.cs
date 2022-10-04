using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PostCodes.Application.Controllers;
using PostCodes.Application.Test.Shared;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Interfaces;
using PostCodes.Domain.Responses;
using Xunit;

namespace PostCodes.Application.Test.Controllers
{
    public class PostCodeControllerTest
    {
        private readonly Mock<IPostCodeService> serviceStub = new();

        #region GetPostCode
        [Fact]
        public async Task GetPostCode_WithValidPostCode_ReturnCommonResponse_Succeded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetPostCode(It.IsAny<string>()))
                .ReturnsAsync(CommonResponse<PostCode>.Success(Utils.FactoryPostCode()));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<PostCode> result = await controller.GetPostCode(Utils.GenerateRandomString(10));

            //Assert
            result.Should().BeOfType<CommonResponse<PostCode>>();
        }

        [Fact]
        public async Task GetPostCode_WithInvalidPostCode_ReturnCommonResponse_Succeded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetPostCode(It.IsAny<string>()))
                .ReturnsAsync(CommonResponse<PostCode>.Fail(Utils.GenerateRandomString(10)));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<PostCode> result = await controller.GetPostCode(Utils.GenerateRandomString(10));

            //Assert
            result.Should().BeOfType<CommonResponse<PostCode>>();
        }
        #endregion

        #region GetSearchHistory
        [Fact]
        public async Task GetSearchHistory_WithPostCodeData_ReturnCommonResponse_Succeded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetSearchHistory(It.IsAny<int?>()))
                .ReturnsAsync(CommonResponse<IEnumerable<PostCode>>.Success(new[] { Utils.FactoryPostCode() }));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<IEnumerable<PostCode>> result = await controller.GetSearchHistory(null);

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
        }

        [Fact]
        public async Task GetSearchHistory_WithoutPostCodeData_ReturnCommonResponse_Unsucceded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetSearchHistory(It.IsAny<int?>()))
                .ReturnsAsync(CommonResponse<IEnumerable<PostCode>>.Fail(Utils.GenerateRandomString(10)));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<IEnumerable<PostCode>> result = await controller.GetSearchHistory(null);

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
        }
        #endregion

        #region GetFullSearchHistoryByDateLimit
        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_WithPostCodeData_ReturnCommonResponse_Succeded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetFullSearchHistoryByDateLimit())
                .ReturnsAsync(CommonResponse<IEnumerable<PostCode>>.Success(new[] { Utils.FactoryPostCode() }));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<IEnumerable<PostCode>> result = await controller.GetFullSearchHistoryByDateLimit();

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
        }

        [Fact]
        public async Task GetFullSearchHistoryByDateLimit_WithoutPostCodeData_ReturnCommonResponse_Unsucceded()
        {
            //Arrange
            serviceStub.Setup(service => service.GetFullSearchHistoryByDateLimit())
                .ReturnsAsync(CommonResponse<IEnumerable<PostCode>>.Fail(Utils.GenerateRandomString(10)));

            HomeController controller = new HomeController(serviceStub.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = Utils.mockContext("GET")
                }
            };

            //Act
            CommonResponse<IEnumerable<PostCode>> result = await controller.GetFullSearchHistoryByDateLimit();

            //Assert
            result.Should().BeOfType<CommonResponse<IEnumerable<PostCode>>>();
        }
        #endregion
    }
}
