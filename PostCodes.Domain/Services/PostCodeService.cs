using AutoMapper;
using GeoCoordinatePortable;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Interfaces;
using PostCodes.Domain.Responses;

namespace PostCodes.Domain.Services
{
    public class PostCodeService : IPostCodeService
    {
        private readonly GeoCoordinate airport = new GeoCoordinate(51.4700223, -0.4542955);
        private readonly IPostCodeRepository _postCodeRepository;
        private readonly IPostCodeIoService _postCodeIoService; 
        private readonly IMapper _mapper;

        public PostCodeService(IPostCodeRepository postCodeRepository, IPostCodeIoService postCodeIoService, IMapper mapper)
        {
            _postCodeRepository = postCodeRepository;
            _postCodeIoService = postCodeIoService;
            _mapper = mapper;
        }

        public async Task<CommonResponse<PostCode>> GetPostCode(string postCodeNumber)
        {
            var response = _mapper.Map<CommonResponse<PostCode>>(await _postCodeIoService.GetPostCode(postCodeNumber));

            if (response.Succeeded)
            {
                CalculateDistanceToAirport(ref response);
                await AddPostCodeSearch(response.Data);
            }

            return response;
        }

        public async Task<CommonResponse<IEnumerable<PostCode>>> GetSearchHistory(int? recordsNumber)
        {
            var response = await _postCodeRepository.GetSearchHistory(recordsNumber);

            if (!response.Any())
                return CommonResponse<IEnumerable<PostCode>>.FailEmpty();

            return CommonResponse<IEnumerable<PostCode>>.Success(response);
        }

        public async Task<CommonResponse<IEnumerable<PostCode>>> GetFullSearchHistoryByDateLimit()
        {
            //[Last 24h] example
            DateTime filterDate = DateTime.Now;
            filterDate = filterDate.AddDays(-1);

            var response = await _postCodeRepository.GetFullSearchHistoryByDateLimit(filterDate);

            if (!response.Any())
                return CommonResponse<IEnumerable<PostCode>>.FailEmpty();

            return CommonResponse<IEnumerable<PostCode>>.Success(response);
        }

        public async Task AddPostCodeSearch(PostCode postCode)
        {
            postCode.SetDate();
            await _postCodeRepository.AddPostCodeSearch(postCode);
        }

        private void CalculateDistanceToAirport(ref CommonResponse<PostCode> response)
        {
            if (response.Data.Latitude.HasValue && response.Data.Longitude.HasValue)
                response.Data.DistanceToAirport = airport.GetDistanceTo(new GeoCoordinate((double)response.Data.Latitude, (double)response.Data.Longitude));
        }
    }
}
