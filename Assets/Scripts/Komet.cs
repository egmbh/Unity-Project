using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Komet : MonoBehaviour
{

    public GameObject explosion;

    private float speed = 0;

    //public GameObject explosionPrefab;

    // Update is called once per frame (Methode von Unity)
    void Update()
    {
        transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
    }

    // Set the speed of the meteor
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    // Zerstört den Meteor, wenn er aus dem Bildschirm fliegt (Methode von Unity)
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Wird aufgerufen, wenn ein Objekt mit einem Collider, der auf "Trigger" gesetzt ist,
    // also andere Objekte nur registriert, aber trotzdem durch sie durchgehen kann, auf ein Objekt stößt (Methode von Unity)
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Man kann Objekten eigene Tags zuweisen, an denen sie erkannt werden können
        if (col.gameObject.CompareTag("Bullet"))
        {
            // Wenn es sich um eine Kugel handelt, werden sie und der Meteor zerstört und ein Explosions-Objekt wird erzeugt
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            // Wenn es hingegen ein Spieler ist, wird die Methode "Die" im Spieler aufgerufen
            col.gameObject.GetComponent<Player>().Die();
        }
    }
}
