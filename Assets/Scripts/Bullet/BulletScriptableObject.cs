using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletView bulletView;
    public float speed;
    public GameObject explosionType;
    public AudioClip explosionClip;
    public AudioSource source;
}
