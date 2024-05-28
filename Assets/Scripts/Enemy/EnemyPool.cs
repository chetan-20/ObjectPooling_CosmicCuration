using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool 
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private List<PooledEnemy> enemyPool = new List <PooledEnemy>();

        public EnemyPool(EnemyView eview,EnemyScriptableObject eScriptableObj) 
        {        
            enemyView = eview;
            enemyScriptableObject = eScriptableObj;
        }
        public EnemyController GetEnemy()
        {
            if (enemyPool.Count > 0)
            {
                PooledEnemy poolEnemy = enemyPool.Find(item => !item.isused);
                if(poolEnemy != null)
                {
                    poolEnemy.isused = true;
                    return poolEnemy.enemyController;
                }                        
            }
            return CreateNewEnemy();
        }
        private EnemyController CreateNewEnemy()
        {
            PooledEnemy poolEnemy = new PooledEnemy();
            poolEnemy.enemyController = new EnemyController(enemyView,enemyScriptableObject.enemyData);
            poolEnemy.isused = true;
            enemyPool.Add(poolEnemy);
            return poolEnemy.enemyController;
        }
        public void ReturnEnemyToPool(EnemyController enemyCont)
        {
            PooledEnemy enemyP = enemyPool.Find(item=>item.enemyController==enemyCont);
            enemyP.isused = false;
        }
        public class PooledEnemy
        {
            public EnemyController enemyController;
            public bool isused;
        }
    }
}
