using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class ServicePool<T> : SingletonGeneric<ServicePool<T>> where T: class
{
    [SerializeField] protected List<PooledItem<T>> pooledList = new List<PooledItem<T>>();

    public virtual T GetItem()
    {
        if(pooledList.Count > 0)
        {
            PooledItem<T> item = pooledList.Find(i => i.isUsed == false);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem();
    }
    private T CreateNewPooledItem()
    {
        PooledItem<T> pooledItem = new PooledItem<T>();
        pooledItem.Item = CreateItem();
        pooledItem.isUsed = false;
        pooledList.Add(pooledItem);
        return pooledItem.Item;
    }
    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledList.Find(i => i.Item.Equals(item));
        pooledItem.isUsed = false;
    }
    protected virtual T CreateItem()
    {
        return (T) null;
    }
}
[Serializable]
public class PooledItem<T>
{
    public T Item;
    public bool isUsed;
}
