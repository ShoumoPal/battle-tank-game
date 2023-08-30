using System.Diagnostics;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float TimeElapsed { get; set; } = 0f;

    public override void OnEnterState()
    {

    }

    public override void OnExitState()
    {

    }

    public override void Tick()
    {
        if(TimeElapsed > 5f)
        {
            EnemyView.ChangeState(EnemyView.PatrolState);
        }
        TimeElapsed += Time.deltaTime;
    }
}
