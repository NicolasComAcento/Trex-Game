using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   struct SpawnTime {
    public float instantiateTime;
    public float interval;
    public float variation;

   }
   public Sprite[] obstacleSprites;
   public GameObject obstaclePrefab;
   public GameObject enemyPrefab;
   
   public bool stopSpawn = false;

   SpawnTime obstacle;
   SpawnTime enemy;

   public float speed = 4;

   float flyingMax =3.14f;
   float flyingMin = -0.57f;
   
   private void Start()
   {
     obstacle.instantiateTime = 0;
     obstacle.interval = 2;
     obstacle.variation =0.5f;

     enemy.instantiateTime = 0;
     enemy.interval = 2;
     enemy.variation =0.5f;
   }
   private void Update(){
    if(Time.time > obstacle.instantiateTime && !stopSpawn){
        GameObject obj = Instantiate(obstaclePrefab, new Vector3(10,-3f, -7), Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().sprite = obstacleSprites[Random.Range(0, obstacleSprites.Length)];
        obj.AddComponent<BoxCollider2D>();
        obj.GetComponent<Obstacle>().speed = speed;
        obstacle.instantiateTime = Time.time + Random.Range(obstacle.interval - obstacle.variation, obstacle.interval + obstacle.variation);
    }
    if(Time.time > enemy.instantiateTime && !stopSpawn){
        GameObject obj = Instantiate(enemyPrefab, new Vector3(10, Random.Range(flyingMax, flyingMin), -7),Quaternion.identity);
        enemy.instantiateTime = Time.time + Random.Range(enemy.interval - enemy.variation, enemy.interval + enemy.variation);
   }
}
}
