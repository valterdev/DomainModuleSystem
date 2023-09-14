using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace App.Modules.Domain.Mechanics_Features.Health
{
    [Serializable]
    public class PercentHealthSpendable : ISpendable
    {
        public float healthPercentage;
        
        public void Execute()
        {
            HealthManager.Instance().Health -= (int)(HealthManager.Instance().Health * healthPercentage);
        }

        public bool Check()
        {
            return HealthManager.Instance().Health >= (int)(HealthManager.Instance().Health * healthPercentage);
        }
    }
}