using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TankView : Subject, IDamagable
{
    private TankController TankController { get; set; }
    private float rotation;
    private float forward;
    [SerializeField] private Joystick joystick;
    [SerializeField] private BulletSpawner spawner;
    [SerializeField] private Button shootButton;
    [SerializeField] private LevelDestroyer destroyer;

    private void Start()
    {
        //shootButton.onClick.AddListener(Shoot);
        destroyer = GameObject.FindGameObjectWithTag("Destroyer").GetComponent<LevelDestroyer>();
    }
    private void Update()
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

    public BulletSpawner GetBulletSpawner()
    {
        return spawner;
    }

    public void Shoot()
    {
        NotifyObservers();
        AudioClip clip = TankController.GetTankModel().shootClip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        TankController.ShootBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyView>() || collision.gameObject.GetComponent<BulletView>())
        {
            TakeDamage(20);
            Debug.Log("Health: " + TankController.GetTankModel().Health);
        }
    }
    public void DestroyEverything()
    {
        StartCoroutine(destroyer.DestroyLevel());
    }
    public void TakeDamage(int damage)
    {
        TankController.ApplyDamage(damage);
    }
}
