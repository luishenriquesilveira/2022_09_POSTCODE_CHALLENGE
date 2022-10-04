using Microsoft.AspNetCore.Mvc;
using PostCodes.Domain.Entities;
using PostCodes.Domain.Interfaces;
using PostCodes.Domain.Responses;

namespace PostCodes.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostCodeController : ControllerBase
    {
        private readonly IPostCodeService _postCodeService;
        public PostCodeController(IPostCodeService postCodeService)
        {
            _postCodeService = postCodeService;
        }

        [HttpGet]
        [Route("GetPostCode/{postCodeNumber}")]
        public async Task<CommonResponse<PostCode>> GetPostCode(string postCodeNumber)
        {
            return await _postCodeService.GetPostCode(postCodeNumber);
        }

        [HttpGet]
        [Route("GetSearchHistory/{recordsNumber?}")]
        public async Task<CommonResponse<IEnumerable<PostCode>>> GetSearchHistory(int? recordsNumber)
        {
            return await _postCodeService.GetSearchHistory(recordsNumber);        
        }

        [HttpGet]
        [Route("GetFullSearchHistoryByDateLimit")]
        public async Task<CommonResponse<IEnumerable<PostCode>>> GetFullSearchHistoryByDateLimit()
        {
            return await _postCodeService.GetFullSearchHistoryByDateLimit();
        }

        
    }
}
