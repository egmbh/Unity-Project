using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    public float screenWidth;

    private float timer = 0;
    public float spawnTime;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow) && pos.x > -screenWidth/2)
        {
            transform.position = new Vector3(pos.x - speed * Time.deltaTime, pos.y, pos.z);
        }
        if (Input.GetKey(KeyCode.RightArrow) && pos.x < screenWidth / 2)
        {
            transform.position = new Vector3(pos.x + speed * Time.deltaTime, pos.y, pos.z);
        }

        timer += Time.deltaTime;
        if(timer >= spawnTime)
        {
            Instantiate(bulletPrefab, pos, Quaternion.identity);
            timer = 0;
        }
    }

    public void Die()
    {
        // Spieler stirbt
        Destroy(gameObject);
        // Spiel wird beendet
    }
}
