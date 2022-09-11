using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
   Camera cam;
   public GameObject shotSpawn;
   public GameObject shot;

   float shotInterval = 0.4f;
   float shotInstantiateTime = 0;
    
    private void Start()
   {
    cam = Camera.main;
   }

   
    private void Update()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.right = (mousePosition - (Vector2)transform.position).normalized;

        if(Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > shotInstantiateTime)
            {

            Instantiate(shot, shotSpawn.transform.position, transform.rotation);
            shotInstantiateTime = Time.time + shotInterval;


            }
        }
    }
}
