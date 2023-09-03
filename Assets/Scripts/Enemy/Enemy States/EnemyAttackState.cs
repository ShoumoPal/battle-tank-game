using System.Diagnostics;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float TimeElapsed { get; set; } = 0f;

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
        if(Tank != null && EnemyView)
        {
            transform.LookAt(Tank.TankView.transform);

            if (TimeElapsed > 1.5f)
            {
                EnemyView.EnemyController.Fire();
                TimeElapsed = 0f;
            }
            if (TimeElapsed <= 1.5f)
            {
                TimeElapsed += Time.deltaTime;
            }
            if (GetDistanceFromPlayer() > 10f)
            {
                EnemyView.ChangeState(EnemyView.ChaseState);
            }
        }
    }
}

