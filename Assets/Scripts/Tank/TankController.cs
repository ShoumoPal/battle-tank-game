using UnityEngine;

public class TankController
{
    private TankModel TankModel { get; }
    public TankView TankView { get; }
    private Rigidbody tankRb;
    private BulletSpawner bulletSpawner;

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        TankModel = _tankModel;
        TankView = GameObject.Instantiate<TankView>(_tankView);
        TankView.SetTankController(this);
        Debug.Log("Tank View created", _tankView);
        tankRb = TankView.GetRigidbody();
        bulletSpawner = TankView.GetBulletSpawner();
    }
    public void Move(float rotation, float forward)
    {
        Vector3 newTankPos = TankView.transform.position + (TankView.transform.forward * TankModel.GetSpeed() * forward * Time.deltaTime);
        tankRb.MovePosition(newTankPos);

        Quaternion newTankRot = TankView.transform.rotation * Quaternion.Euler(Vector3.up * (rotation * 100 * Time.deltaTime));
        tankRb.MoveRotation(newTankRot);
    }
    public TankModel GetTankModel()
    {
        return TankModel;
    }
    public void ShootBullet()
    {
        bulletSpawner.SpawnBullet(bulletSpawner.transform);
    }
    public void ApplyDamage(int damage)
    {
        if (TankModel.Health - damage <= 0)
        {
            //death
            DestroyTank();
            //TankView.DestroyEverything();
        }
        else
        {
            TankModel.Health -= damage;
        }
    }
    public void DestroyTank()
    {
        TankView.DestroyTank();
    }
}
