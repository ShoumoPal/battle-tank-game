using UnityEngine;

public class TankModel
{
    public float Speed { get; }
    public int Health { get; set;  }
    private TankTypes Type { get; set;  }
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
