using TMPro;
using UnityEngine;

/* This class contains all three Achievements, i.e-  Bullets fired, Enemies destroyed and Distance travelled */

public class AchievementSystem : SingletonGeneric<AchievementSystem>, IObservers
{
    private TankView player;
    private int _numberOfBullets;
    private int _enemiesKilled;
    private float _distanceTravelled;
    private bool firstCompleted;
    private bool secondCompleted;
    [SerializeField] private TextMesh text;
    [SerializeField] private Animator textAnim;

    // For tracking bullets spawned

    public void OnNotifyBullets()
    {
        _numberOfBullets++;

        if (_numberOfBullets == 10)
        {
            text.text = "10 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
        if(_numberOfBullets == 25)
        {
            text.text = "25 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
        if(_numberOfBullets == 50)
        {
            text.text = "50 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
    }
    private void Start()
    {
        firstCompleted = false;
        secondCompleted = false;
        _numberOfBullets = 0;
        _enemiesKilled = 0;
        _distanceTravelled = 0;
        player = TankSpawner.Instance.Player.TankView;
        transform.SetParent(player.transform);
        player.AddObserver(this);
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    // For tracking enemies killed

    public void OnNotifyEnemy()
    {
        _enemiesKilled++;

        if(_enemiesKilled == 1)
        {
            text.text = "1 Enemy Killed!";
            textAnim.SetTrigger("ShowText");
        }
        if(_enemiesKilled == 2)
        {
            text.text = "2 Enemies Killed!";
            textAnim.SetTrigger("ShowText");
        }
        if( _enemiesKilled == 3)
        {
            text.text = "3 Enemies Killed!";
            textAnim.SetTrigger("ShowText");
        }
    }

    // For tracking distance travelled

    public bool OnNotifyDistanceTravelled(float _distance)
    {
        _distanceTravelled += _distance;
        
        bool flag = true;

        if(_distanceTravelled >= 20 && !firstCompleted)
        {
            text.text = "20 Metres Travelled!";
            textAnim.SetTrigger("ShowText");
            firstCompleted = true;
            flag = true;
        }
        if (_distanceTravelled >= 30 && !secondCompleted)
        {
            text.text = "30 Metres Travelled!";
            textAnim.SetTrigger("ShowText");
            secondCompleted = true;
            flag = true;
        }
        if (_distanceTravelled >= 40)
        {
            text.text = "40 Metres Travelled!";
            textAnim.SetTrigger("ShowText");
            flag = false;
        }
        return flag;
    }
}
