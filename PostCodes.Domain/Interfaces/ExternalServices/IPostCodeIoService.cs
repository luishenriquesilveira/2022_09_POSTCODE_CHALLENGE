using PostCodes.Domain.Responses;

namespace PostCodes.Domain.Interfaces
{
    public interface IPostCodeIoService
    {
        Task<CommonResponse<PostCodeResponse>> GetPostCode(string postCodeNumber);
    }
}
