using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyModel EnemyModel { get; set; }
    private EnemyController EnemyController { get; set; }
    public NavMeshAgent agent;

    //States
    private EnemyState currentState;
    public EnemyIdleState IdleState;
    public EnemyPatrolState PatrolState;

    private void Start()
    {
        EnemyModel = EnemyController.GetEnemyModel();
        //Setting Idle as default
        currentState = IdleState;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        currentState.Tick();
    }
    public void ChangeState(EnemyState newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }

        Debug.Log("Changing state to : " + newState);
        currentState = newState;
        currentState.OnEnterState();
    }

    public void SetEnemyController(EnemyController enemyController)
    {
        EnemyController = enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyTank();
        }
    }

    public void DestroyTank()
    {
        GameObject explosion = Instantiate(EnemyModel.Explosion, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
        Destroy(explosion, 1.5f);
    }
}
