using UnityEngine;

public class BulletController
{
    public BulletView BulletView { get; }
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
    public void Fly(Transform spawn)
    {
        bulletRb.velocity = spawn.forward * BulletModel.Speed;
    }
    public void Enable()
    {
        BulletView.Enable();
    }
    public void Disable()
    {
        BulletView.Disable();
    }
    public void SetParent(Transform parent)
    {
        BulletView.SetParent(parent);
    }
    public BulletModel GetBulletModel()
    {
        return BulletModel;
    }
    public void SetTransform(Transform transform)
    {
        BulletView.SetTransform(transform);
    }
}
