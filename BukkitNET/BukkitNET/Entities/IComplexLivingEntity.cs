using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IComplexLivingEntity : ILivingEntity
    {

        HashSet<IComplexEntityPart> GetParts();

    }
}
