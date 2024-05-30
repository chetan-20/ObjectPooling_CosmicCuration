
using System.Collections.Generic;
using static CosmicCuration.Bullets.BulletPool;


public class GenericObjectPool<T> where T : class
{
    private List<PooledItem<T>> pool = new List<PooledItem<T>>();

    protected T GetItem()
    {
        if (pool.Count > 0)
        {
            PooledItem<T> item = pool.Find(item => !item.isUsed);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPoolItem();
    }

    private T CreateNewPoolItem()
    {
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.Item = CreateItemT();
        newItem.isUsed = true;
        pool.Add(newItem);
        return newItem.Item;
    }
    public void ReturnItem(T item)
    {
        PooledItem<T> poolItem = pool.Find(i => i.Item.Equals(item));
        poolItem.isUsed = false;
    }
    protected virtual T CreateItemT()
    {
       throw new System.Exception("Not Implemented in Child Class");
    }
    public class PooledItem<T>
    {
        public T Item;
        public bool isUsed;
    }
}
