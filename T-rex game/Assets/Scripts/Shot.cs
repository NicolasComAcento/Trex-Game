using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    float speed = 20f;
    private void Update()
    {
      transform.position += transform.right * speed * Time.deltaTime;
      if (transform.position.x >= 6){
        Destroy(gameObject);
      }
    }
}
