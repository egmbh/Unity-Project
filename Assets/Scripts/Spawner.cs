using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float spawnWaitTime = 2;
    private float timeSinceLastSpawn = 0;
    public float waitDecreasePerMeteor = 0.1f;
    public float minWaitTime = 0.5f;

    public GameObject meteorPrefab;

    public float screenWidth = 10;

    public float meteorSpeed = 15;
    public float speedIncreasePerMeteor = 0.1f;
    public float maxSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnWaitTime)
        {
            //zufällige Pos für Meteor finden
            var pos = transform.position;
            pos.x = Random.Range(pos.x - screenWidth / 2, pos.x + screenWidth / 2);
            //Meteor spawnen
            GameObject meteor = Instantiate(meteorPrefab, pos, Quaternion.identity);
            meteor.GetComponent<Komet>().SetSpeed(meteorSpeed);
            //Timer zurücksetzen
            timeSinceLastSpawn = 0;
            //SpawnTime verringern
            spawnWaitTime = Mathf.Max(spawnWaitTime - waitDecreasePerMeteor, minWaitTime);

            //Speed erhöhen
            meteorSpeed = Mathf.Min(meteorSpeed + speedIncreasePerMeteor, maxSpeed);
        }
    }
}
