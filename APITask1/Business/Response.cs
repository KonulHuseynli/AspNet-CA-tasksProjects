using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Response
    {
        public Response()
        {
            Errors = new List<string>();
        }
        public StatusCode Status { get; set; } = StatusCode.Success;
        public List<string> Errors { get; set; }
    }

    public class Response<T>
    {
        public Response()
        {
            Errors = new List<string>();
        }
        public StatusCode Status { get; set; } = StatusCode.Success;
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 200,
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401
    }
}
