using UnityEngine;

public class BulletModel
{
    public BulletController BulletController { get; set; }
    public float Speed { get; }
    public GameObject explosionType;

    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        Speed = bulletScriptableObject.speed;
        explosionType = bulletScriptableObject.explosionType;
    }
    public void SetBulletController(BulletController bulletController)
    {
        BulletController = bulletController;
    }
}
