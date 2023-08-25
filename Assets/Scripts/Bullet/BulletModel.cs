using UnityEngine;

public class BulletModel
{
    public BulletController BulletController { get; set; }
    public float Speed { get; }
    public GameObject explosionType;
    public AudioClip explosionClip;
    public AudioSource explosionSource;

    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        Speed = bulletScriptableObject.speed;
        explosionType = bulletScriptableObject.explosionType;
        explosionClip = bulletScriptableObject.explosionClip;
        explosionSource = bulletScriptableObject.source;
    }
    public void SetBulletController(BulletController bulletController)
    {
        BulletController = bulletController;
    }
}
