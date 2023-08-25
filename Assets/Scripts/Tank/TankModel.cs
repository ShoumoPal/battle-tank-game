using UnityEngine;

public class TankModel
{
    private float Speed { get; }
    private int Health { get; }
    private TankTypes Type { get; }
    public AudioClip shootClip;

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        Type = tankScriptableObject.type;
        shootClip = tankScriptableObject.shootClip;
    }

    public float GetSpeed()
    {
        return Speed;
    }
}
