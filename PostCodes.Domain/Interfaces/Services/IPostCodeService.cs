using PostCodes.Domain.Entities;
using PostCodes.Domain.Responses;

namespace PostCodes.Domain.Interfaces
{
    public interface IPostCodeService
    {
        Task<CommonResponse<IEnumerable<PostCode>>> GetSearchHistory(int? recordsNumber);
        Task<CommonResponse<IEnumerable<PostCode>>> GetFullSearchHistoryByDateLimit();
        Task<CommonResponse<PostCode>> GetPostCode(string postCodeNumber);
    }
}
