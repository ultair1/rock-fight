using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Rigidbody2D theRB;



    // Start is called before the first frame update
    void Start()
    {
        waveTime = 30;
    }
//    IEnumerator Wait()//so i don't have to create a new private string or int for waiting time
//    {
//        yield return new WaitForSeconds(30f);
//    }
    // Update is called once per frame
    void Update()
    {
        theRB = GetComponent<Rigidbody2D>();
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnEnemies();
            theCountdown = waitingForNextSpawn;
        }
        waveTime -= Time.deltaTime;
        if (waveTime <= 0)//if this was == 0 the wave would likely never change as it's highly unlikely to get exactly 0 when counting down in Time.DeltaTime
        {
            WaveIncrease();
        }
    }
    private void WaveIncrease()
    {
        waitingForNextSpawn = waitingForNextSpawn -.5f;
        waveTime = 30;
    }

    //Array of objects to spawn (note I've removed the private goods variable)
    public GameObject[] theEnemies;

    //Time it takes to spawn theGoodies
    [Space(3)]
    public float waitingForNextSpawn = 10;
    public float theCountdown = 10;
    public float waveTime;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;




    void SpawnEnemies()
    {
        // Defines the min and max ranges for x and y
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

        // Choose a new goods to spawn from the array (note I specifically call it a 'prefab' to avoid confusing myself!)
        GameObject enemiesPrefab = theEnemies[Random.Range(0, theEnemies.Length)];

        // Creates the random object at the random 2D position.
        Instantiate(enemiesPrefab, pos, transform.rotation);

        // If I wanted to get the result of instantiate and fiddle with it, I might do this instead:
        //GameObject newGoods = (GameObject)Instantiate(goodsPrefab, pos)
        //newgoods.something = somethingelse;
    }
}
