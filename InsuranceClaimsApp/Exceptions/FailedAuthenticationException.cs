using System;

namespace InsuranceClaimsApp.Exceptions
{
    public class FailedAuthenticationException : Exception
    {
        public FailedAuthenticationException(string message) : base(message)
        {
        }
    }
}