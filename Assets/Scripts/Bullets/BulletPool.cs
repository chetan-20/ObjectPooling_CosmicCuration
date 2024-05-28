
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using static CosmicCuration.Bullets.BulletPool;

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
        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isused);
                if (pooledBullet != null)
                {                   
                    pooledBullet.isused = true;                  
                    return pooledBullet.bullet;
                }
            }
            return CreateNewPooledBullet();
        }
        private BulletController CreateNewPooledBullet()
        {
            PooledBullet poolBullet = new PooledBullet();
            poolBullet.bullet = new BulletController(bulletView,bulletScriptableObject);
            poolBullet.isused = true;
            pooledBullets.Add(poolBullet);
            return poolBullet.bullet;
        }
        public void ReturnBulletToPool(BulletController returnedBullet)
        {
            PooledBullet poolBullet = pooledBullets.Find(item=>item.bullet==returnedBullet);
            poolBullet.isused = false;
        }
        public class PooledBullet
        {
            public bool isused;
            public BulletController bullet;
        }
    }
}
