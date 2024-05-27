
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{ 
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public BulletPool(BulletView bView,BulletScriptableObject bScriptableObject)
        {
            bulletView = bView;
            bulletScriptableObject = bScriptableObject;
        }
        public class PooledBullet
        {
            public bool isused;
            public BulletController bullet;
        }
    }
}
