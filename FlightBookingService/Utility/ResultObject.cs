using System;

namespace Utility
{
    public class ResultObject
    {
        public bool HasError
        {
            get
            {
                return (Status == StatusType.Error);
            }
            set { }
        }
        public bool HasSuccess
        {
            get {

                return (Status == StatusType.Success);
            }
            set { }
        }
        public StatusType Status { get; set; }
        public string Message { get; set; }
        public string MessageTitle { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public Exception ResultException { get; set; }
        public Object ResultData { get; set; }

        public ResultObject()
        {
            this.Status = StatusType.Success;
        }
        public ResultObject(string message)
        {
            this.Status = StatusType.Error;
            this.Message = message;
        }
        public ResultObject(string message , StatusType statusType)
        {
            this.Status = statusType;
            this.Message = message;
        }

        public ResultObject(string message, Exception exp)
        {
            this.Status = StatusType.Error;
            this.Message = message;
            if (null != exp)
            {
                this.ExceptionMessage = exp.Message;
                this.ExceptionStackTrace = exp.StackTrace;
            }
            this.ResultException = exp;
        }

    }
}

public enum StatusType
{
    Success = 200,
    Error = 500,
    UnprocessableEntity = 422,
    Unauthorized = 401,
    NotFound = 404
}
