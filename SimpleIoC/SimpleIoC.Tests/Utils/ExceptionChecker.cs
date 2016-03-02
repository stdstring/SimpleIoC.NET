using System;
using NUnit.Framework;

namespace SimpleIoC.Tests.Utils
{
    public static class ExceptionChecker
    {
        public static void Throws<TException>(Action action, String exceptionMessage) where TException : Exception
        {
            try
            {
                action();
                Assert.Fail("Expect exception, but was not");
            }
            catch (Exception exc)
            {
                Assert.IsInstanceOf<TException>(exc);
                Assert.That(exc.Message, Is.EqualTo(exceptionMessage));
            }
        }
    }
}
