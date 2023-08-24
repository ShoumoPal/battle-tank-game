using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankSpawner : MonoBehaviour
{
    [SerializeField] private TankScriptableObjectList TankScriptableObjectList;

    private void Start()
    {
        CreateTank();
    }

    private TankController CreateTank()
    {
        int randomNumber = (int)Random.Range(0, TankScriptableObjectList.tanks.Length);
        TankScriptableObject tankObject = TankScriptableObjectList.tanks[randomNumber];
        Debug.Log("Created tank of type: " + tankObject.name);
        TankModel model = new TankModel(tankObject);
        TankController tank = new TankController(model, tankObject.tankView);
        return tank;
    }
}
