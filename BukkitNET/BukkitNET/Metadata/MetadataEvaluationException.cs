using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Metadata
{
    public class MetadataEvaluationException : Exception
    {

        public MetadataEvaluationException()
            : base()
        {
        }

        public MetadataEvaluationException(Exception inner)
            : base("", inner)
        {
        }

    }
}
