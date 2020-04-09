using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    //---This is used in case the game is based on the number of enemies spawned - WIP
    [SerializeField] int spawnEnemyQty = 0;
    [Tooltip ("Amount in seconds for the new enemy to spawn in the same position as player")]
    [SerializeField] int waitForSpawn = 3;

    private GameObject player;
    public Vector2 playerPosition;
    public Vector2 enemyPosition;
    

    //---Array of enemies (if there is more than 1)
    [SerializeField] Enemy[] enemyPrefabArray;

    bool spawn = true;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player position is: " + player.transform.position);
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        //---Spawns the enemies in the same x position and randomly in y
        float xPos = 0;
        //---Screen size
        xPos = Random.Range(-9f, 9f);
        transform.position = new Vector2(xPos, 5.5f);
        var enemyIndex = UnityEngine.Random.Range(0, enemyPrefabArray.Length);
        Spawn(enemyPrefabArray[enemyIndex]);
        //StartCoroutine(SpawnInPlayerPosition(enemyPrefabArray[enemyIndex]));
    }

    private void Spawn(Enemy myEnemy)
    {
        playerPosition = player.transform.position;
        Enemy newEnemy =
        Instantiate(myEnemy, transform.position, transform.rotation) as Enemy;
        newEnemy.transform.parent = transform;
        //---WIP, each 5 seconds Instantiate a enemy in player position
        //StartCoroutine(SpawnInPlayerPosition(enemyPrefabArray[enemyIndex]));

    }


    //---This helps to prevent the player to stay in the same place in case
    //---the blocks are not falling in his position
    IEnumerator SpawnInPlayerPosition(Enemy myEnemy)
    {

        yield return new WaitForSeconds(waitForSpawn);

        playerPosition = player.transform.position;
        enemyPosition = new Vector2(playerPosition.x, 5.5f);
        Enemy newEnemy =
        Instantiate(myEnemy, enemyPosition , transform.rotation) as Enemy;
        newEnemy.transform.parent = transform;


    }

}
