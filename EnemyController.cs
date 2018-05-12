using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private bool hasSpawn;
    private MoveController moveScript;
    private WeaponController[] weapons;

    void Awake()
    {
        // Récupération de toutes les armes de l'ennemi
        weapons = GetComponentsInChildren<WeaponController>();

        // Récupération du script de mouvement lié
        moveScript = GetComponent<MoveController>();

    }

    // Use this for initialization
    void Start () {
        hasSpawn = false;

        // On désactive tout
        // -- collider
        GetComponent<Collider2D>().enabled = false;
        // -- Mouvement
        moveScript.enabled = false;
        // -- Tir
        foreach (WeaponController weapon in weapons)
        {
            weapon.enabled = false;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (hasSpawn == false)
        {
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                Spawn();
            }
        }
        else
        {
            // On fait tirer toutes les armes automatiquement
            foreach (WeaponController weapon in weapons)
            {
                if (weapon != null && weapon.enabled && weapon.CanAttack)
                {
                    weapon.Attack(true);
                }
            }

            // 4 - L'ennemi n'a pas été détruit, il faut faire le ménage
            if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Spawn()
    {
        hasSpawn = true;

        // On active tout
        // -- Collider
        GetComponent<Collider2D>().enabled = true;
        // -- Mouvement
        moveScript.enabled = true;
        // -- Tir
        foreach (WeaponController weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
  
    


}
