using System;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController TankController { get; set; }
    private float horizontal;
    private float vertical;
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        Movement();
        if(horizontal != 0 || vertical != 0)
        {
            Debug.Log("Tank moving");
            TankController.Move(horizontal, vertical);
        }
    }

    private void Movement()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
    }

    public void SetTankController(TankController _tankController)
    {
        TankController = _tankController;
    }
}
