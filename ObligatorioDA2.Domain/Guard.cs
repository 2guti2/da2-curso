using System;
using ObligatorioDA2.Domain.Exceptions;

namespace ObligatorioDA2.Domain
{
    public static class Guard
    {
        public static void Requires(Func<bool> predicate, string message)
        {
            if (predicate()) return;
            throw new GuardClauseException(message);
        }
    }
}