using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Potions
{
    public class PotionEffectTypeWrapper : PotionEffectType
    {

        public PotionEffectTypeWrapper(int id)
            : base(id)
        {
        }

        public override double GetDurationModifier()
        {
            return GetEffectType().GetDurationModifier();
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }

        public override bool IsInstant()
        {
            throw new NotImplementedException();
        }

        public PotionEffectType GetEffectType()
        {
            return PotionEffectType.GetById(this.Id);
        }

    }
}
