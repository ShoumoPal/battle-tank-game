using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyModel EnemyModel { get; set; }
    public EnemyController EnemyController { get; set; }
    public NavMeshAgent agent;

    //States
    private EnemyState currentState;
    public EnemyIdleState IdleState;
    public EnemyPatrolState PatrolState;
    public EnemyChaseState ChaseState;
    public EnemyAttackState AttackState;

    [SerializeField] private BulletSpawner bulletSpawner;

    private void Start()
    {
        EnemyModel = EnemyController.GetEnemyModel();
        //Setting Idle as default
        ChangeState(IdleState);
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

    public BulletSpawner GetBulletSpawner()
    {
        return bulletSpawner;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            ChangeState(ChaseState);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            ChangeState(PatrolState);
    }

    public void DestroyTank()
    {
        GameObject explosion = null;
        if (gameObject)
            explosion = Instantiate(EnemyModel.Explosion, gameObject.transform.position, Quaternion.identity);

        Destroy(gameObject);
        Destroy(explosion, 1.5f);
    }
}
