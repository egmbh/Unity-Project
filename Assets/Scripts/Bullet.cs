using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, pos.y + speed * Time.deltaTime, pos.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.name != "LePlayeur") 
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
