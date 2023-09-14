using UnityEngine;
using UnityEngine.AI;

/* Enemy Controller for MVC */

public class EnemyController
{
    private EnemyModel EnemyModel { get; set; }
    private EnemyView EnemyView { get; set; }
    private NavMeshAgent NavMeshAgent { get; set; }
    private BulletSpawner BulletSpawner { get; set; }

    public EnemyController(EnemyModel model, EnemyView view, Vector3 spawnPoint)
    {
        EnemyModel = model;
        EnemyView = GameObject.Instantiate<EnemyView>(view, spawnPoint, Quaternion.identity);
        Debug.Log("Enemy created");
        EnemyView.SetEnemyController(this);
        BulletSpawner = EnemyView.GetBulletSpawner();
    }
    public EnemyModel GetEnemyModel()
    {
        return EnemyModel;
    }
    public void Fire()
    {
        EnemyView.GetAudioSource().PlayOneShot(EnemyModel.ShootClip);
        BulletSpawner.SpawnBullet(BulletSpawner.transform);
    }
    public void DestroyTank()
    {
        EnemyView.DestroyTank();
    }
}
