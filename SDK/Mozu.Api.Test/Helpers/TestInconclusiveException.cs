using System;
using System.Diagnostics;

namespace Mozu.Api.Test.Helpers
{
    public class TestInconclusiveException : TestException
    {
        /// <summary>
        /// Default constructor for generating TestInconclusiveException.
        /// </summary>
        /// <param name="actualCode"></param>
        /// <param name="methodName"></param>
        /// <param name="expectedCode"></param>
        /// <param name="msg"></param>
        public TestInconclusiveException(int actualCode, string methodName, int? expectedCode, string msg = "")
            : base(actualCode, methodName, expectedCode, msg)
        {
            Debug.WriteLine(ToString());
        }


        /// <summary>
        /// Retrun a string containing the client method call inconclusive failure exception information.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (ExpectedReturnCode == null)
                return String.Format("Test Inconclusive - {0}", Message);
            return String.Format("Test Inconclusive - [{0}:expected {1}] but the actual return code is {2}. {3}", ClientMethodName, ExpectedReturnCode, ActualReturnCode, Message);
        }
    }
}
