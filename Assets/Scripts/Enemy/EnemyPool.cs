using CosmicCuration.Bullets;
using System.Collections.Generic;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private EnemyData enemyData;
        public EnemyPool(EnemyView eview,EnemyData edata)
        {
           enemyPrefab = eview;
           enemyData = edata;
        }
        public EnemyController GetEnemy() => GetItem();
        protected override EnemyController CreateItemT() => new EnemyController(enemyPrefab,enemyData);
    }
}
