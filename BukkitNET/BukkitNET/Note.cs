using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public class Note
    {

        public const byte TONES_COUNT = 12;

        private byte note;

        public Note(int note)
        {
            Debug.Assert(note >= 0 && note <= 24, "The note value has to be between 0 and 24.");

            this.note = (byte)note;
        }

        public Note(int octave, Tone tone, bool sharped)
        {
            if (sharped && !tone.IsSharpable())
            {

                var vals = Enum.GetValues(typeof(Tone)).Cast<Tone>().ToList();

                int index = -1;
                for (int i = 0; i < vals.Count; i++)
                {
                    if (vals[i] == tone)
                    {

                        index = i;

                        break;
                    
                    }
                }

                tone = vals[index + 1];
                sharped = false;
            
            }

            if (octave < 0 || octave > 2 || (octave == 2 && !(tone == Tone.F && sharped)))
            {
                throw new ArgumentException("Tone and octave have to be between F#0 and F#2");
            }

            this.note = (byte)(octave * Note.TONES_COUNT + tone.GetId(sharped));
        }

    }

    public static class ToneExtensions
    {

        public static bool IsSharpable(this Tone tone)
        {

            var attrib = tone.GetAttribute<ToneInfoAttribute>();

            return attrib.IsSharpable;

        }

        public static byte GetId(this Tone tone, bool sharped)
        {

            var attrib = tone.GetAttribute<ToneInfoAttribute>();

            byte id = (byte)(sharped && attrib.IsSharpable ? attrib.Id + 1 : attrib.Id);

            return (byte)(id % Note.TONES_COUNT);
        
        }

    }

    public enum Tone
    {

        [ToneInfo(0x1, true)]
        G,
        
        [ToneInfo(0x3, true)]
        A,
        
        [ToneInfo(0x5, false)]
        B,
        
        [ToneInfo(0x6, true)]
        C,
        
        [ToneInfo(0x8, true)]
        D,
        
        [ToneInfo(0xA, false)]
        E,
        
        [ToneInfo(0xB, true)]
        F

    }



}
