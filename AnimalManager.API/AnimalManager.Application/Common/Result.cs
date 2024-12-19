namespace AnimalManager.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Result(bool isSuccess, T data, List<string> errors)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null);
        }

        public static Result<T> Fail(List<string> errors)
        {
            return new Result<T>(false, default, errors);
        }

        public static Result<T> Fail(string error)
        {
            return new Result<T>(false, default, new List<string> { error });
        }

    }
}
