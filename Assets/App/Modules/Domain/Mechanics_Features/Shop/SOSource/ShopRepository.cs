using System;
using OpenGameFramework.Interfaces;
using UnityEngine;

namespace App.Modules.Domain.Mechanics_Features.Shop
{
    public class ShopRepository : ScriptableObject
    {
        public ShopBundle[] Bundles;
        
        [Serializable]
        public class ShopBundle
        {
            private Guid _guid;
            public string BundleName;
            
            [SerializeReference, SelectImplementation(typeof(ISpendable))]
            public ISpendable[] Cost;
            
            [SerializeReference, SelectImplementation(typeof(IReward))]
            public IReward[] Reward;

            public ShopBundle()
            {
                _guid = Guid.NewGuid();
            }
        }
    }

    
}