using UnityEngine;

public class TankModel
{
    private float Speed { get; }
    private int Health { get; }
    private TankTypes Type { get; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        Type = tankScriptableObject.type;
    }

    public float GetSpeed()
    {
        return Speed;
    }
}
