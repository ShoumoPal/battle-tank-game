using UnityEngine;

public class BulletController
{
    private BulletView BulletView { get; }
    private BulletModel BulletModel { get; }
    private Rigidbody bulletRb;
    private Transform spawn;

    public BulletController(BulletView bulletView, BulletModel bulletModel, Transform spawnTransform)
    {
        spawn = spawnTransform; 
        BulletView = GameObject.Instantiate<BulletView>(bulletView, spawn.position, spawn.rotation);
        BulletModel = bulletModel;
        BulletView.SetBulletController(this);
        bulletRb = BulletView.GetRigidbody();
    }
    public void Fly()
    {
        bulletRb.velocity = spawn.forward * BulletModel.Speed;
    }
    public BulletModel GetBulletModel()
    {
        return BulletModel;
    }
}
