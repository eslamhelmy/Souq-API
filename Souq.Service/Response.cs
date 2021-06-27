using System;
using System.Collections.Generic;
using System.Text;

namespace Souq.Service
{
    public abstract class Response<T>
    {
        public T Data { get; protected set; }
        public bool Status { get; protected set; }
        public string Code { get;protected set; }

    }

    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse(T data)
        {
            Data = data;
            Status = true;
        }
    }

    public class FailureResponse<T> : Response<T>
    {
        public FailureResponse(string code)
        {
            Code = code;
            Status = false;
        }
    }
}
