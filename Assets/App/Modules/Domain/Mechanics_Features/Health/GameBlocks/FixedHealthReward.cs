using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class FixedHealthReward : IReward
    {
        public int health;
        
        public void Execute()
        {
            HealthManager.Instance().Health += health;
        }
    }
}