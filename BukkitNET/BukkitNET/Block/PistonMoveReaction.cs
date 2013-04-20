using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET.Block
{

    public enum PistonMoveReaction
    {

        [PistonMoveReactionInfo(0)]
        Move,

        [PistonMoveReactionInfo(1)]
        Break,

        [PistonMoveReactionInfo(2)]
        Block

    }

    public static class PistonMoveReactionHelper
    {

        public static PistonMoveReaction GetById(int id)
        {

            foreach (PistonMoveReaction val in Enum.GetValues(typeof(PistonMoveReaction)))
            {

                var attrib = val.GetAttribute<PistonMoveReactionInfoAttribute>();

                if (attrib.Id == id)
                    return val;

            }

        }

    }

}
