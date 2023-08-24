using System;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController TankController { get; set; }
    private float rotation;
    private float forward;
    [SerializeField] private Joystick joystick;

    private void FixedUpdate()
    {
        Movement();
        if(rotation != 0 || forward != 0)
        {
            TankController.Move(rotation, forward);
        }
    }
    private void LateUpdate()
    {
        Camera.main.transform.position = transform.position + new Vector3(-40f, 40f, -25f);
    }
    private void Movement()
    {
        rotation = joystick.Horizontal;
        forward = joystick.Vertical;
    }

    public void SetTankController(TankController _tankController)
    {
        TankController = _tankController;
    }

    public Rigidbody GetRigidbody()
    {
        return GetComponent<Rigidbody>();
    }
}
