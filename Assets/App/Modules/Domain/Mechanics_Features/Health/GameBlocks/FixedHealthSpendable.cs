using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Health
{
    [Serializable]
    public class FixedHealthSpendable : ISpendable
    {
        public int health;
        
        public void Execute()
        {
            HealthManager.Instance().Health -= health;
        }

        public bool Check()
        {
            return HealthManager.Instance().Health >= health;
        }
    }
}