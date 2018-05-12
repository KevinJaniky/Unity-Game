using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public int hp = 2;
    public bool isEnemy = true; 


    void OnTriggerEnter2D(Collider2D collider)
    {
        // Est-ce un tir ?
        PlayerShotController shot = collider.gameObject.GetComponent<PlayerShotController>();
        if (shot != null)
        {
            // Tir allié
            if (shot.isEnemyShot != isEnemy)
            {
                hp -= shot.damage;

                // Destruction du projectile
                // On détruit toujours le gameObject associé
                // sinon c'est le script qui serait détruit avec ""this""
                Destroy(shot.gameObject);

                if (hp <= 0)
                {
                    // Destruction !
                    Destroy(gameObject);
                }
            }
        }
    }
}
