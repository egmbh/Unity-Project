using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            // zufällige Pos. finden
            // Meteor erstellen
            Debug.Log("Meteor wird gespawnt (noch nicht wirklich)");
            timer = 0;
        }
    }
}
