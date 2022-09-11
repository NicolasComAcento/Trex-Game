using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 3;
   void Update()
   {
    transform.position += Vector3.left * speed * Time.deltaTime;
    if(transform.position.x <= -10){
        Destroy(gameObject);
    }
   }
}
