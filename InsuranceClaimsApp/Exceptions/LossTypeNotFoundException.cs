using System;

namespace InsuranceClaimsApp.Exceptions
{
    public class LossTypeNotFoundException : Exception
    {
        public LossTypeNotFoundException(string message) : base(message)
        {
        }
    }
}