
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
 
  float speed = 4;

  int score;
  public Manager manager;

  private void Start()
  {
    manager = FindObjectOfType<Manager>();
  }
  private void Update()
  {

    transform.position += Vector3.left * speed * Time.deltaTime;
    
    Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 1f, 0, LayerMask.GetMask("Shot"));
    if(box != null){
      Destroy(box.gameObject);
      Destroy(gameObject);
      score += 100;
     
      
      manager.IncreaseScore();
      
    }
    if (transform.position.x <= -10){
        Destroy(gameObject);
    }
  } 
}
