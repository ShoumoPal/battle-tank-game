using UnityEngine;

public class TankController
{
    private TankModel TankModel { get; }
    private TankView TankView { get; }

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        TankModel = _tankModel;
        TankView = GameObject.Instantiate<TankView>(_tankView);
        TankView.SetTankController(this);
        Debug.Log("Tank View created", _tankView);
    }
    public void Move(float x, float y)
    {
        Vector3 tankPos = TankView.gameObject.transform.position;
        tankPos = new Vector3(tankPos.x + x * TankModel.GetSpeed() * Time.deltaTime,
                              0,
                              tankPos.z + y * TankModel.GetSpeed() * Time.deltaTime);
        TankView.gameObject.transform.position = tankPos;
    }
}
