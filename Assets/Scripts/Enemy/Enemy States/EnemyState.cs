using UnityEngine;

[RequireComponent(typeof(EnemyView))]
public abstract class EnemyState : MonoBehaviour
{
    protected EnemyView EnemyView { set; get; }
    protected TankController Tank { set; get; } = null;

    private void Start()
    {
        EnemyView = GetComponent<EnemyView>();
        Tank = TankSpawner.Instance.GetTankController();
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
        if (Tank != null)
            return Vector3.Distance(transform.position, Tank.TankView.transform.position);
        else
            return 0f;
    }
}
