using System;
using System.Diagnostics;
using System.Net;

namespace Mozu.Api.Test.Helpers
{
    class TestFailException : TestException
    {
        public static Exception GetCustomTestException(ApiException apiException, string currentClassName, string currentMethodName, HttpStatusCode expectedCode)
        {
            var correlationId = apiException.CorrelationId;
            var printableError = string.Format("{0} || {1}.{2} {3} | Error: {4} | CorrelationId: {5}",
                apiException.HttpStatusCode.ToString(),
                currentClassName, currentMethodName,
                apiException.ApplicationName ?? "", apiException.Message ?? "",
                correlationId
                );
            Debug.WriteLine(printableError);
            switch (apiException.HttpStatusCode)
            {
                case HttpStatusCode.NotFound:
                    return null; // or use new Exception("No Item Found with API transaction.") ;
                case HttpStatusCode.NoContent:
                    return null; // or use new Exception("No Content was returned by the API") ;
                case HttpStatusCode.Unauthorized:
                    return new Exception("Unauthorized Access To this API, Please check your behaviors and possibly re-install the application to this store to pick up changes.");
                case HttpStatusCode.Forbidden:
                    return new Exception("Forbidden Access To this API, Please check your SiteId settings and possibly re-install the application to this store.");
                default:
                    return new Exception(String.Format("Test Fails - [{0}:expected {1}] but the actual return code is {2}. {3}",
                        currentMethodName,
                        expectedCode.ToString(),
                        apiException.HttpStatusCode,
                        printableError));
            }
        }
        /// <summary>
        /// Default constructor for generating TestFailException.
        /// </summary>
        /// <param name="actualCode"></param>
        /// <param name="methodName"></param>
        /// <param name="expectedCode"></param>
        /// <param name="msg"></param>
        public TestFailException(int actualCode, string methodName, int? expectedCode, string msg = "")
            : base(actualCode, methodName, expectedCode, msg)
        {
            Debug.WriteLine(ToString());
        }

        /// <summary>
        /// Default constructor for generating TestFailException.
        /// </summary>
        /// <param name="actualCode"></param>
        /// <param name="methodName"></param>
        /// <param name="expectedCode"></param>
        /// <param name="msg"></param>
        public TestFailException(HttpStatusCode actualCode, string methodName, int? expectedCode, string msg = "")
            : base((int)actualCode, methodName, expectedCode, msg)
        {
            Debug.WriteLine(ToString());
        }

        /// <summary>
        /// Default constructor for generating TestFailException.
        /// </summary>
        /// <param name="actualCode"></param>
        /// <param name="methodName"></param>
        /// <param name="expectedCode"></param>
        /// <param name="msg"></param>
        public TestFailException(HttpStatusCode actualCode, string methodName, HttpStatusCode? expectedCode, string msg = "")
            : base((int)actualCode, methodName, (int?)expectedCode, msg)
        {
            Debug.WriteLine(ToString());
        }

        /// <summary>
        /// Retrun a string containing the client method call failure exception information.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Test Fails - [{0}:expected {1}] but the actual return code is {2}. {3}", ClientMethodName, ExpectedReturnCode, ActualReturnCode, Message);
        }
    }
}
