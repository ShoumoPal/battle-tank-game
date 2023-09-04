using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour 
{
    private BulletPool bulletPool;
    [SerializeField] private BulletScriptableObjectList bulletList;

    private void Start()
    {
        bulletPool = TankSpawner.Instance.Player.TankView.GetBulletSpawner().GetComponent<BulletPool>();
        Debug.Log("Bullet pool: " + bulletPool.gameObject.name);
        //for(int i = 0; i < 5; i++)
        //{
        //    //Creating Pool
        //    SpawnBullet(gameObject.transform);
        //}
    }
    public void SpawnBullet(Transform spawn)
    {
        Debug.Log("Bullet Pool: " + bulletPool);
        int randomNumber = (int)Random.Range(0f, bulletList.bullets.Length - 1);
        BulletScriptableObject obj = bulletList.bullets[randomNumber];
        BulletModel model = new BulletModel(obj);
        BulletController bulletController = bulletPool.GetBullet(obj.bulletView, model, spawn);

        bulletController.Fly();
        bulletController.SetTransform(transform);
        bulletController.Enable();

        bulletController.SetParent(gameObject.transform);
    }
}
