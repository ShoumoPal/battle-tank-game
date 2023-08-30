using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    public override void Tick()
    {
        if(EnemyView != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, EnemyView.EnemyModel.Speed * Time.deltaTime * 0.25f);
            transform.LookAt(player.transform);
        }
    }
}
