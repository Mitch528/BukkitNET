using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{
    public enum Rotation
    {
        None,

        Clockwise,

        Flipped,

        CounterClockwise

    }

    public static class Rotate
    {
        public static Rotation RotateClockwise(this Rotation rotation)
        {
            switch (rotation)
            {

                case Rotation.None:
                    return Rotation.Clockwise;
                case Rotation.Clockwise:
                    return Rotation.Flipped;
                case Rotation.Flipped:
                    return Rotation.CounterClockwise;
                case Rotation.CounterClockwise:
                    return Rotation.None;
            }


            return Rotation.None;
        }

        public static Rotation RotateCounterClockwise(this Rotation rotation)
        {
            switch (rotation)
            {
                case Rotation.None:
                    return Rotation.CounterClockwise;
                case Rotation.CounterClockwise:
                    return Rotation.Flipped;
                case Rotation.Flipped:
                    return Rotation.Clockwise;
                case Rotation.Clockwise:
                    return Rotation.None;
            }

            return Rotation.None;
        }
    }
}
