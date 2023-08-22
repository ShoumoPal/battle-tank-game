using System;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankView tankView;

    private void Start()
    {
        CreateTank();
    }

    private TankController CreateTank()
    {
        TankModel model = new TankModel(20);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
}
