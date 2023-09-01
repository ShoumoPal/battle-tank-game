using UnityEngine;

public class AchievementSystem : MonoBehaviour, IObservers
{
    private TankView player;
    private int numberOfBullets;
    [SerializeField] private TextMesh text;
    [SerializeField] private Animator textAnim;

    public void OnNotify()
    {
        numberOfBullets++;

        if (numberOfBullets == 10)
        {
            text.text = "10 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
        if(numberOfBullets == 25)
        {
            text.text = "25 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
        if(numberOfBullets == 50)
        {
            text.text = "50 Bullets Fired!";
            textAnim.SetTrigger("ShowText");
        }
    }
    private void Start()
    {
        numberOfBullets = 0;
        player = GameObject.FindObjectOfType<TankView>();
        transform.SetParent(player.transform);
        player.AddObserver(this);
    }
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
    private void OnDisable()
    {
        player.RemoveObserver(this);
    }
}
