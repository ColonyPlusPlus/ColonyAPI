using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ColonyAPI.Exceptions
{
    public class ModNotInstalledException : Exception
    {
        public ModNotInstalledException()
        {
        }

        public ModNotInstalledException(string message)
            : base(message)
        {
        }

        public ModNotInstalledException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
