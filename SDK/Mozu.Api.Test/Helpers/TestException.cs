using System;
using System.Diagnostics;
using System.Text;

namespace Mozu.Api.Test.Helpers
{
    public class TestException : Exception
    {
        /// <summary>
        /// Generates a new TestException object using <see cref="TestException" /> class.
        /// </summary>
        /// <param name="actualCode"></param>
        /// <param name="methodName"></param>
        /// <param name="expectedCode"></param>
        /// <param name="msg"></param>
        protected TestException(int actualCode, string methodName, int? expectedCode, string msg = "")
        {
            ExpectedReturnCode = expectedCode;
            ActualReturnCode = actualCode;
            Message = msg;
            ClientMethodName = methodName;

            var sb = new StringBuilder();
            sb.Insert(0, "Method Name: ");
            sb.Append(methodName);
            sb.Append(", Expected Code: ");
            sb.Append(expectedCode);
            sb.Append(", Actual Code: ");
            sb.Append(actualCode);
            sb.Append(", Message: ");
            sb.Append(msg);

            Debug.WriteLine(sb.ToString());
            sb = null;
        }

        protected TestException(string methodName, string msg)
        {
            Message = msg;
            ClientMethodName = methodName;
        }

        protected int? ExpectedReturnCode { get; set; }
        public int ActualReturnCode { get; set; }
        protected string Message { get; set; }
        protected string ClientMethodName { get; set; }


        /// <summary>
        /// Retrun a string containing the general test exception information.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[{0}:expected {1}] but the actual return code is {2}. {3}", ClientMethodName, ExpectedReturnCode, ActualReturnCode, Message);
        }
    }
}
