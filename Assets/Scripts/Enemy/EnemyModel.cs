using UnityEngine;

public class EnemyModel
{
    public EnemyController EnemyController { get; set; }
    public float Speed { get; set; }
    public float Range { get; set; }
    public  GameObject Explosion { get; set; }

    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        Speed = enemyScriptableObject.speed;
        Range = enemyScriptableObject.range;
        Explosion = enemyScriptableObject.deathExplosion;
    }
}
