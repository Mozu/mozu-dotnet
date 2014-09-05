using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace Mozu.Api
{
   
    [Serializable]
    public class ApiException : Exception
    {
        private string _message;

        public ApiException(string message) : base(message)
        {
            _message = message;
        }
        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
            _message = message;
        }

        public ApiException(SerializationInfo info, StreamingContext context)
        {
            
            try
            {
                ExceptionDetail = (ExceptionDetail) info.GetValue("exceptionDetail", typeof (ExceptionDetail));
            }
            catch (Exception)
            {
                try
                {
                    ExceptionDetail = (ExceptionDetail)info.GetValue("ExceptionDetail", typeof(ExceptionDetail));
                }
                catch (Exception) { }
            }



            if (ExceptionDetail != null)
            {
                _message = ExceptionDetail.Message;
            }
            else
            {
                try
                {
                    _message = (string) info.GetValue("message", typeof (string));
                }
                catch (Exception){}

            }

            try
            {
                ApplicationName = (string)info.GetValue("applicationName", typeof(string));
            }
            catch (Exception) { }

            try
            {
                ErrorCode = (string)info.GetValue("errorCode", typeof(string));
            }
            catch (Exception) { }


            try
            {
                Items = (List<Item>) info.GetValue("items", typeof (List<Item>));
            }
            catch (Exception)
            {

                try
                {
                    Items = (List<Item>)info.GetValue("Items", typeof(List<Item>));
                }
                catch (Exception) { }
                
            }

            try
            {
                AdditionalErrorData = (List<AdditionalErrorData>) info.GetValue("additionalErroData", typeof (List<AdditionalErrorData>));
            }
            catch (Exception){}


        }

        public override string Message
        {
            get { return _message; }
        }
        public string ApplicationName { get; private set; }
        public string ErrorCode { get; private set; }
        public IApiContext ApiContext { get; set; }
        public String CorrelationId { get; set; }
        public ExceptionDetail ExceptionDetail;
        public List<Item> Items;
        public List<AdditionalErrorData> AdditionalErrorData { get; private set; } 
        public HttpStatusCode HttpStatusCode;

    }

    [Serializable]
    public class AdditionalErrorData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [Serializable]
    public class ApplicationErrorData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [Serializable]
    public class Item
    {
        public List<ApplicationErrorData> ApplicationErrorData { get; set; } 
        public String ApplicationName;
        public String ErrorCode;
        public String Message;
    }

    [Serializable]
    public class ExceptionDetail
    {
        public String Message;
        public String Source;
        public String StackTrace;
        public String TargetSite;
        public String Type;
    }

}
