namespace PostCodes.Domain.Responses
{
    public class CommonResponse<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static CommonResponse<T> Fail(string errorMessage)
        {
            return new CommonResponse<T> { Succeeded = false, Message = errorMessage };
        }

        public static CommonResponse<T> FailEmpty()
        {
            return new CommonResponse<T> { Succeeded = false, Message = "The list is empty." };
        }

        public static CommonResponse<T> Success(T data)
        {
            return new CommonResponse<T> { Succeeded = true, Data = data, Message = "" };
        }
    }
}
