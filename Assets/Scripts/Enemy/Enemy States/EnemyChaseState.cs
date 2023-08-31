using UnityEngine;

public class EnemyChaseState : EnemyState
{ 
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
        if(EnemyView && Player)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, EnemyView.EnemyModel.Speed * Time.deltaTime * 0.25f);
            transform.LookAt(Player.transform);

            if(GetDistanceFromPlayer() <= 10f)
            {
                EnemyView.ChangeState(EnemyView.AttackState);
            }
        }
    }
}
