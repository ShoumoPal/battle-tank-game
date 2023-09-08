using UnityEngine;

/* Tank SO List */

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}