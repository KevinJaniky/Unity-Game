using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {



    public int WavesTime = 5;

    public Transform EnemyType;

    private int Customtime;

    private float Timer;

    private int count = 0;
    // Use this for initialization
    void Start () {
        
    }

    private void Awake()
    {
        Timer = Time.time + WavesTime;
    }

    // Update is called once per frame
    void Update () {
        Vector3 v3Left = new Vector3(-0.15f, .5f, 10); //10 is the distance from the camera
        v3Left = Camera.main.ViewportToWorldPoint(v3Left);



        int spawnPointX = (int)v3Left.x+9;
        int spawnPointY = -1;
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);
        if (Timer < Time.time)
        { 
           Instantiate(EnemyType, spawnPosition, Quaternion.identity); 
            Timer = Time.time + WavesTime; 
        }
    }

}
