using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour 
{
    [SerializeField] private BulletScriptableObjectList bulletList;

    public void SpawnBullet(Transform spawn)
    {
        int randomNumber = (int)Random.Range(0f, bulletList.bullets.Length);
        BulletScriptableObject obj = bulletList.bullets[randomNumber];
        BulletModel model = new BulletModel(obj);
        BulletController bulletController = new BulletController(obj.bulletView, model, spawn);
    }
}
