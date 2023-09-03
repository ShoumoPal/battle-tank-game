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
        if(EnemyView && Tank != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Tank.TankView.transform.position, EnemyView.EnemyModel.Speed * Time.deltaTime * 0.25f);
            transform.LookAt(Tank.TankView.transform);

            if(GetDistanceFromPlayer() <= 10f)
            {
                EnemyView.ChangeState(EnemyView.AttackState);
            }
        }
    }
}
