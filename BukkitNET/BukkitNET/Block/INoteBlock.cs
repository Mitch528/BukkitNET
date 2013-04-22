using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface INoteBlock : IBlockState
    {

        Note GetNote();

        byte GetRawNote();

        void SetNote(Note note);

        void SetRawNote(byte note);

        bool Play();

        bool Play(byte instrument, byte note);

        bool Play(Instrument instrument, Note note);

    }
}
