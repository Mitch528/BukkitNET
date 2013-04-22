using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Commands
{
    public class CommandException : Exception
    {

        public CommandException()
            : base()
        {
        }

        public CommandException(string message)
            : base(message)
        {
        }

        public CommandException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }

    }
}
