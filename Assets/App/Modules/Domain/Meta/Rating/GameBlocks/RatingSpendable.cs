using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;
using UnityEngine.Serialization;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class RatingSpendable : ISpendable
    {
        public int rating;

        public void Execute()
        {
            RatingManager.Instance().Rating -= rating;
        }

        public bool Check()
        {
            return RatingManager.Instance().Rating >= rating;
        }
    }
}