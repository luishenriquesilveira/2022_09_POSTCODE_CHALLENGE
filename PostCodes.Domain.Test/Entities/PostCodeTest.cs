using FluentAssertions;
using PostCodes.Domain.Entities;
using Xunit;

namespace PostCodes.Domain.Test.Entities
{
    public class PostCodeTest
    {
        private readonly DateTime? _date;
        private readonly PostCode _sut;

        public PostCodeTest()
        {
            // Arrange
            _date = DateTime.Now;
            _sut = new PostCode();
        }

        [Theory]
        [InlineData()]
        public void Test_SetDate()
        {
            _sut.SetDate();
            var expectedDate = _sut.Date;

            expectedDate.Should().NotBeNull();

        }

        [Theory]
        [InlineData(null)]
        public void Test_DistanceToAirport_Null(double? distanceToAirport)
        {
            _sut.DistanceToAirport = distanceToAirport;

            var expectedDistanceToAirportKm = _sut.DistanceToAirportKm;
            var expectedDistanceToAirportMi = _sut.DistanceToAirportMi;

            expectedDistanceToAirportKm.Should().BeNull();
            expectedDistanceToAirportMi.Should().BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(100.99)]
        public void Test_DistanceToAirport_NotNull(double? distanceToAirport)
        {
            _sut.DistanceToAirport = distanceToAirport;

            var expectedDistanceToAirportKm = _sut.DistanceToAirportKm;
            var expectedDistanceToAirportMi = _sut.DistanceToAirportMi;

            expectedDistanceToAirportKm.Should().NotBeNull();
            expectedDistanceToAirportMi.Should().NotBeNull();
        }
    }
}