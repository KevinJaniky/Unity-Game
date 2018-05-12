using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    //Vitesse de déplacement
    public Vector2 speed = new Vector2(1, 1);
    //  Direction
    public Vector2 direction = new Vector2(-1, 0);

    bool shouldMove = true;

    private Vector2 movement;


  

    // Update is called once per frame 
    void Update()
    {
        if (shouldMove)
        {
            movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
        }
    
               
    }

    void FixedUpdate()
    {
        if (shouldMove) 
        {
            GetComponent<Rigidbody2D>().velocity = movement;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            shouldMove = false;   ///Change shouldMove
        }
    }
    void OnTriggerEnter()
    {
        Debug.Log("Hit Player OnTriggerEnter");
    }
}
