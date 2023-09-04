using System.Numerics;
using UnityEngine;

public class BulletPool : ServicePool<BulletController>
{
    private BulletModel model;
    private BulletView view;
    private Transform spawn;

    public BulletController GetBullet(BulletView view, BulletModel model, Transform spawn)
    {
        this.model = model;
        this.view = view;
        this.spawn = spawn;
        return GetItem();
    }
    protected override BulletController CreateItem()
    {
        return new BulletController(view, model, spawn);
    }

    public override void ReturnItem(BulletController bulletController)
    {
        PooledItem<BulletController> pooledItem = pooledList.Find(i => i.Item == bulletController);
        if (pooledItem != null)
        {
            bulletController.SetTransform(spawn);
            pooledItem.isUsed = false;
            bulletController.Disable();
        }
    }
}
