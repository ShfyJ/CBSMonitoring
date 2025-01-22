using CBSMonitoring.DTOs;
using System.Net;

namespace ERPBlazor.Shared.Wrappers
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public Result(int statusCode, List<ValidationError> validationErrors, bool succeeded, List<string> messages)
        {
            StatusCode = statusCode;
            ValidationErrors = validationErrors;
            Succeeded = succeeded;
            Messages = messages;
        }

        public List<ValidationError> ValidationErrors { get; set; } = new();
        public List<string> Messages { get; set; } = new();
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }

        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        public static IResult Fail(List<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }

        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static Task<IResult> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }
    }

    public class Result<T> : Result, IResult<T>
    {

        public Result() { }

        public Result(int statusCode, T data, List<ValidationError> validationErrors, bool succeeded, List<string> messages)
        {
            StatusCode = statusCode;
            ValidationErrors = validationErrors;
            Succeeded = succeeded;
            Messages = messages;
            Data = data;
        }

        public T? Data { get; set; }

        public static Result<T> Fail(int statusCode)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode };
        }

        public static Result<T> Fail(int statusCode, string message)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode, Messages = new List<string> { message } };
        }

        //public static Result<T> Fail(int statusCode, IEnumerable<object> errors, string message)
        //{
        //    return new Result<T> { Succeeded = false, StatusCode = statusCode, Errors = errors, Messages = new List<string> { message } };
        //}

        public static Result<T> Fail(int statusCode, T data)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode, Data = data };
        }

        public static Result<T> Fail(int statusCode, List<ValidationError> validationErrors, string message)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode, 
                ValidationErrors = validationErrors, Messages = new List<string> { message } };
        }

        public static Result<T> Fail(int statusCode, T data, string message)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode, Data = data, Messages = new List<string> { message } };
        }

        public static Result<T > Fail(int statusCode, List<string> messages)
        {
            return new Result<T> { Succeeded = false, StatusCode = statusCode, Messages = messages };
        }

        public static Task<Result<T>> FailAsync(int statusCode)
        {
            return Task.FromResult(Fail(statusCode));
        }

        public static Task<Result<T>> FailAsync(int statusCode, string message)
        {
            return Task.FromResult(Fail(statusCode, message));
        }

        public static Task<Result<T>> FailAsync(int statusCode, T data, string message)
        {
            return Task.FromResult(Fail(statusCode, data, message));
        }

        public static Task<Result<T>> FailAsync(int statusCode, List<ValidationError> validationErrors, string message)
        {
            return Task.FromResult(Fail(statusCode, validationErrors, message));
        }

        //public static Task<Result<T>> FailAsync(int statusCode, IEnumerable<object> errors, string message)
        //{
        //    return Task.FromResult(Fail(statusCode, errors, message));
        //}

        public static Task<Result<T>> FailAsync(int statusCode, List<string> messages)
        {
            return Task.FromResult(Fail(statusCode, messages));
        }

        public static Task<Result<T>> FailAsync(int statusCode, T Data)
        {
            return Task.FromResult(Fail(statusCode, Data));
        }

        public static Result<T> Success(int statusCode)
        {
            return new Result<T> { Succeeded = true, StatusCode = statusCode };
        }   

        public static Result<T> Success(int statusCode, string message)
        {
            return new Result<T> { Succeeded = true, StatusCode = statusCode, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        public static Result<T> Success(int statusCode, T data)
        {
            return new Result<T> { Succeeded = true, StatusCode = statusCode, Data = data };
        }

        public static Result<T> Success(int statusCode, T data, string message)
        {
            return new Result<T> { Succeeded = true, StatusCode = statusCode, Data = data, Messages = new List<string> { message } };
        }

        public static Result<T> Success(int statusCode, T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, StatusCode = statusCode, Data = data, Messages = messages };
        }

        public static Task<Result<T>> SuccessAsync(int statusCode)
        {
            return Task.FromResult(Success(statusCode));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(int statusCode, string message)
        {
            return Task.FromResult(Success(statusCode, message));
        }

        public static Task<Result<T>> SuccessAsync(int statusCode, T data)
        {
            return Task.FromResult(Success(statusCode, data));
        }

        public static Task<Result<T>> SuccessAsync(int statusCode, T data, string message)
        {
            return Task.FromResult(Success(statusCode, data, message));
        }
    }
}
