using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Helpers.Responses
{
    public class ServiceResponseBase
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string? Message { get; set; }
    }

    public class ServiceResponse : ServiceResponseBase { }

    public class ServiceResponse<T> : ServiceResponseBase
    {
        public T? Data { get; set; }
    }

    public class ServiceResponseException<T> : ServiceResponse<T>
    {
        public Exception? Exception { get; set; }
    }

    public class ServiceResponseException<T, TException> : ServiceResponse<T> where TException : class
    {
        public TException? Exception { get; set; }
    }

}
