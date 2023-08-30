using UnityEngine;

[RequireComponent(typeof(EnemyView))]
public abstract class EnemyState : MonoBehaviour
{
    protected EnemyView EnemyView { set; get; }

    private void Awake()
    {
        EnemyView = GetComponent<EnemyView>();
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
}
