using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : SingletonGeneric<LevelDestroyer>
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private GameObject Level;
    public bool isDead { get; set; } = false;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Update()
    {
        if(isDead && !isRunning)
        {
            StartCoroutine(DestroyLevel());
        }
    }

    public IEnumerator DestroyLevel()
    {
        isRunning = true;
        Debug.Log("Coroutine started");
        //StartCoroutine(DestroyPlayer());
        StartCoroutine(DestroyEnemies());
        StartCoroutine(DestroyGround());
        yield return null;
    }
    
    private IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(3);
        Level.SetActive(false);
    }
    private IEnumerator DestroyEnemies()
    {
        yield return new WaitForSeconds(2);

        for(int i = 0; i < spawner.ListofEnemies.Count; i++)
        {
            if (spawner.ListofEnemies[i] != null)
            {
                Debug.Log("List count: " + spawner.ListofEnemies.Count);
                spawner.ListofEnemies[i].DestroyTank();
            }
               
        }
    }
    //private IEnumerator DestroyPlayer()
    //{
    //    yield return new WaitForSeconds(1);
    //    Destroy(player);
    //}


}
