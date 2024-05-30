using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;

namespace CosmicCuration.Bullets
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;       
        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }
        public BulletController GetBullet() => GetItem();
        protected override BulletController CreateItemT() => new BulletController(bulletPrefab, bulletSO);
              
    }
}