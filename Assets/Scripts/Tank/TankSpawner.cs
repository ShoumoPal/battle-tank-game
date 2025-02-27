using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankSpawner : SingletonGeneric<TankSpawner>
{
    [SerializeField] private TankScriptableObjectList TankScriptableObjectList;
    public TankController Player { get; private set; }

    private void OnEnable()
    {
        CreateTank();
    }
    public TankController GetTankController()
    {
        return Player;
    }
    private TankController CreateTank()
    {
        int randomNumber = (int)Random.Range(0, TankScriptableObjectList.tanks.Length - 1);
        TankScriptableObject tankObject = TankScriptableObjectList.tanks[randomNumber];
        Debug.Log("Created tank of type: " + tankObject.name);
        TankModel model = new TankModel(tankObject);
        TankController tank = new TankController(model, tankObject.tankView);
        Player = tank;
        return tank;
    }
}
