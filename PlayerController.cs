using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Vitesse de déplacement
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    private bool isGrounded = true;
    private int timeBeforeJump ;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * inputX, speed.y * inputY);
        //definir le tire au click
        bool shoot = Input.GetButtonDown("Fire1");
        if (shoot)
        {
            WeaponController weapon = GetComponent<WeaponController>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;
        topBorder = -4;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );
   
    }

    void FixedUpdate()
    {
        Rigidbody2D player = GetComponent<Rigidbody2D>();
        
        Jump(player);
        player.velocity = movement;
    }

    void OnDestroy()
    {
        // Game Over.
        // Ajouter un nouveau script au parent
        // Car cet objet va être détruit sous peu
        transform.parent.gameObject.AddComponent<GameOverController>();
    }
    
    void Jump(Rigidbody2D player)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeBeforeJump != (int)Time.time)
            {
                player.AddForce(transform.up * 500);
                timeBeforeJump =(int) Time.time;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ennemi")  // or if(gameObject.CompareTag("YourWallTag"))
        {
           // transform.parent.gameObject.AddComponent<GameOverController>();
        }
    }
}
