using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class GoldReward : IReward
    {
        public int gold;
        
        public void Execute()
        {
            GoldManager.Instance().Gold += gold;
        }
    }
}