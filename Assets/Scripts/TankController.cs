using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        float h = joystick.Horizontal;
        float z = joystick.Vertical;

        transform.position = new Vector3(transform.position.x + h * speed * Time.deltaTime, 0, transform.position.z + z * speed * Time.deltaTime);
    }
}
