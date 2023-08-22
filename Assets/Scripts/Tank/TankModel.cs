using UnityEngine;

public class TankModel
{
    private float speed;

    public TankModel(float _speed)
    {
        speed = _speed;
    }
    public float GetSpeed()
    {
        return speed;
    }
}
