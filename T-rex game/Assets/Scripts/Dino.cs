using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    Vector2 yVelocity;

    float maxHeight = 2f;
    float timeToPeak = 0.5f;
    float jumpSpeed;
    float gravity;
    float groundPosition = 0f;

    bool isGrounded = false;
    
     private void Awake()
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
    void Start()
    {
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak,2);
        jumpSpeed = gravity * timeToPeak;
        groundPosition = transform.position.y;
        InvokeRepeating(nameof(AnimatedSprite), 0.15f, 0.15f);
    }

    void Update()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if(transform.position.y <= groundPosition){
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            yVelocity = jumpSpeed * Vector2.up;
        }
        transform.position += (Vector3)yVelocity * Time.deltaTime;
    }

    private void AnimatedSprite()
   {
     spriteIndex++;

     if(spriteIndex >= sprites.Length) {
        spriteIndex = 0;
     }
     spriteRenderer.sprite = sprites[spriteIndex];
   }
}
