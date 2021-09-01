using System;

namespace ObligatorioDA2.Domain.Exceptions
{
    public class GuardClauseException : Exception
    {
        public GuardClauseException(string msg) : base(msg)
        {
        }
    }
}