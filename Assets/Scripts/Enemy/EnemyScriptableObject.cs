using UnityEngine;

/* Scriptable object for enemy */

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/NewEnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyView enemyView;
    public float speed;
    public float range;
    public GameObject deathExplosion;
    public AudioClip shootClip;
}
