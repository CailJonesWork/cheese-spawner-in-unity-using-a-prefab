using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    //cheese prefab ise used due to it haveing collision
    public GameObject cheesePrefab;
    public Vector2 spawnAreaCenter;
    public Vector2 spawnAreaSize;
    public int initialCheeseCount = 10; 
    public int minCheeseCount = 20; 
    void Start()
    {
        SpawnCheese(initialCheeseCount);
    }

    void Update()
    {
        // use game object with teh tag chese as the object the player picks up
        int currentCheeseCount = GameObject.FindGameObjectsWithTag("Cheese").Length;

       //minimum cheese count is compaired to current cheese count
        if (currentCheeseCount < minCheeseCount)
        {
            int cheeseToSpawn = minCheeseCount - currentCheeseCount;
            SpawnCheese(cheeseToSpawn);
        }
    }

    void SpawnCheese(int count)
    {
        //spawns a cheese in the area in game in a random position
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPosition = spawnAreaCenter + new Vector2(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                                                                   Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f));

           
            Instantiate(cheesePrefab, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}