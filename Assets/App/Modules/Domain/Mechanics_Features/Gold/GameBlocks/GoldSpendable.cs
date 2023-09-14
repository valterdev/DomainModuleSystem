using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class GoldSpendable : ISpendable
    {
        public int gold;

        public void Execute()
        {
            GoldManager.Instance().Gold -= gold;
        }

        public bool Check()
        {
            return GoldManager.Instance().Gold >= gold;
        }
    }
}