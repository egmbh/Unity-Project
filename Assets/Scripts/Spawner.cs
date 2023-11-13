using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public float screenWidth;
    public GameObject meteorPrefab;

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
            Vector3 spawnPos = transform.position;
            float xSpawnPos = Random.Range(-screenWidth / 2, screenWidth / 2);
            spawnPos.x = xSpawnPos;
            // Meteor erstellen
            Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

            Debug.Log("Meteor wird gespawnt (jetzt gleich schon)");
            timer = 0;
        }
    }
}
