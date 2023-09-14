using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class PercentHealthReward : IReward
    {
        public float healthPercentage;
        
        public void Execute()
        {
            HealthManager.Instance().Health += (int)(HealthManager.Instance().Health * healthPercentage);
        }
    }
}