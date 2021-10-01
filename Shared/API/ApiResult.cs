using Microsoft.AspNetCore.Mvc;
using MyProject.Shared.Exceptions;
using MyProject.Shared.Extentions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace MyProject.Shared.API
{
    public class ApiResult
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        public ApiResult(bool isSuccess, HttpStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        #region Implicit Operators
        public static implicit operator ApiResult(bool result)
        {
            if (result)
            {
                return new ApiResult(true, HttpStatusCode.OK, "The Operation Was Completed Successfully");
            }
            else
            {
                return new ApiResult(false, HttpStatusCode.InternalServerError, "The Operation Encountered an Error");
            }
        }

        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, HttpStatusCode.OK);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, HttpStatusCode.BadRequest);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult(false, HttpStatusCode.BadRequest, message);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(true, HttpStatusCode.OK, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, HttpStatusCode.NotFound);
        }
        #endregion

        //*****************************************************************************************************

        public static ApiResult Ok(string msg = "The Operation Was Completed Successfully")
        {
            return new ApiResult(true, HttpStatusCode.OK, msg);
        }
        public static ApiResult OkCreate(string msg = "Data created successfully")
        {
            return new ApiResult(true, HttpStatusCode.Created, msg);
        }
        public static ApiResult OkUpdate(string msg = "Data updated successfully")
        {
            return new ApiResult(true, HttpStatusCode.OK, msg);
        }
        public static ApiResult OkDelete(string msg = "Data deleted successfully")
        {
            return new ApiResult(true, HttpStatusCode.NoContent, msg);
        }
        public static ApiResult Conflict(string msg = "Some logical error has occurred !")
        {
            return new ApiResult(false, HttpStatusCode.Conflict, msg);
        }
        public static ApiResult ServerError(string msg = "Server error has occured!")
        {
            return new ApiResult(false, HttpStatusCode.Conflict, msg);
        }
        public static ApiResult DataNotFound(string msg = "Your requested data not found")
        {
            return new ApiResult(false, HttpStatusCode.NotFound, msg);
        }

        //************************* Throw ************************ 

        public static AppException ThrowServerError(string msg = "Server error has occured!!")
        {
            return new AppException(HttpStatusCode.InternalServerError, msg);
        }
    }

    public class ApiResult<TData> : ApiResult where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, HttpStatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators

        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, data);
        }

        public static implicit operator ApiResult<TData>(OkResult result)
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, null);
        }

        public static implicit operator ApiResult<TData>(OkObjectResult result)
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, (TData)result.Value);
        }

        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, HttpStatusCode.BadRequest, null);
        }

        public static implicit operator ApiResult<TData>(BadRequestObjectResult result)
        {
            var message = result.Value?.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            return new ApiResult<TData>(false, HttpStatusCode.BadRequest, null, message);
        }

        public static implicit operator ApiResult<TData>(ContentResult result)
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, null, result.Content);
        }

        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, HttpStatusCode.NotFound, null);
        }

        public static implicit operator ApiResult<TData>(NotFoundObjectResult result)
        {
            return new ApiResult<TData>(false, HttpStatusCode.NotFound, (TData)result.Value);
        }
        #endregion

        //***********************************************************
        public static ApiResult<TData> OkObject(TData data, string msg = "The Operation Was Completed Successfully")
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, data, msg);
        }
        public static ApiResult<TData> OkCreateObject(TData data, string msg = "Data created successfully")
        {
            return new ApiResult<TData>(true, HttpStatusCode.Created, data, msg);
        }
        public static ApiResult<TData> OkUpdatObjecte(TData data, string msg = "Data updated successfully")
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, data, msg);
        }
        public static ApiResult<TData> OkDeleteObjecte(TData data, string msg = "Data deleted successfully")
        {
            return new ApiResult<TData>(true, HttpStatusCode.OK, data, msg);
        }
        public static ApiResult<TData> ConflictObject(string msg = "Some logical error has occurred !")
        {
            return new ApiResult<TData>(false, HttpStatusCode.Conflict, null, msg);
        }
        public static ApiResult<TData> ServerErrorObject(string msg = "Server error has occured!")
        {
            return new ApiResult<TData>(false, HttpStatusCode.Conflict, null, msg);
        }
        public static ApiResult<TData> DataNotFoundObject(string msg = "Your requested data not found")
        {
            return new ApiResult<TData>(false, HttpStatusCode.NotFound, null, msg);
        }
    }
}