using PostCodes.Domain.Entities;

namespace PostCodes.Domain.Interfaces
{
    public interface IPostCodeRepository
    {
        Task AddPostCodeSearch(PostCode postCode);
        Task<IEnumerable<PostCode>> GetSearchHistory(int? recordsNumber);
        Task<IEnumerable<PostCode>> GetFullSearchHistoryByDateLimit(DateTime date);
    }
}
