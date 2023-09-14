using System;
using OpenGameFramework;
using OpenGameFramework.Interfaces;

namespace App.Modules.Domain.Mechanics_Features.Gold
{
    [Serializable]
    public class RatingReward : IReward
    {
        public int rating;
        
        public void Execute()
        {
            RatingManager.Instance().Rating += rating;
        }
    }
}