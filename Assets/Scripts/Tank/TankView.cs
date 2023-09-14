using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/* TankView for MVC */

public class TankView : Subject, IDamagable
{
    private TankController TankController { get; set; }
    private Vector3 _prevLoc;
    private float _totalDistance;
    private bool isRunning;
    private float rotation;
    private float forward;
    private TankModel model;
    [SerializeField] private Joystick joystick;
    [SerializeField] private BulletSpawner spawner;
    [SerializeField] private Button shootButton;
    [SerializeField] private HealthBar healthBar;

    private void Start()
    {
        //shootButton.onClick.AddListener(Shoot);
        model = TankController.GetTankModel();
        isRunning = true;
    }
    private void FixedUpdate()
    {
        if (isRunning)
            RecordDistance();
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
    private void RecordDistance()
    {
        _totalDistance = Vector3.Distance(transform.position, _prevLoc);
        NotifyDistanceTravelled(_totalDistance, out isRunning);
        _prevLoc = transform.position;
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
    public HealthBar GetHealthBar()
    {
        return healthBar;
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
        NotifyBulletObservers();
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
    public void DestroyTank()
    {
        StartCoroutine(LevelDestroyer.Instance.DestroyLevel());
        GameObject explosion = null;
        if(TankController != null)
        {
            explosion = Instantiate(model.explosion, gameObject.transform.position, Quaternion.identity);

            Destroy(gameObject);
            Destroy(explosion, 1.5f);
        }
    }
    public void TakeDamage(int damage)
    {
        TankController.ApplyDamage(damage);
    }
    private void OnDisable()
    {
        RemoveObserver(AchievementSystem.Instance);
    }
}
