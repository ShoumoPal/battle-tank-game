using UnityEngine;

[RequireComponent(typeof(EnemyView))]
public abstract class EnemyState : MonoBehaviour
{
    protected EnemyView EnemyView { set; get; }
    protected GameObject Player { get; set; }

    private void Start()
    {
        EnemyView = GetComponent<EnemyView>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void OnEnterState()
    {
        this.enabled = true;
    }
    public virtual void OnExitState()
    {
        this.enabled = false;
    }
    public abstract void Tick();

    public float GetDistanceFromPlayer()
    {
        if (Player)
            return Vector3.Distance(transform.position, Player.transform.position);
        else
            return 0f;
    }
}
