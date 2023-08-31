using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyState
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
        if (EnemyView.agent.remainingDistance <= EnemyView.agent.stoppingDistance) //done with path
        {
            if (RandomPoint(transform.position, EnemyView.EnemyModel.Range, out Vector3 point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                EnemyView.agent.SetDestination(point);
            }
        }
    }

    // Random point for AI
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}