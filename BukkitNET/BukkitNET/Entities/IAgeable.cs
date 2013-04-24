using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IAgeable : ICreature
    {

        int GetAge();

        void SetAge(int age);

        void SetAgeLock(bool ageLock);

        bool GetAgeLock();

        void SetBaby();

        void SetAdult();

        bool IsAdult();

        bool CanBreed();

        void SetBreed(bool breed);

    }
}
