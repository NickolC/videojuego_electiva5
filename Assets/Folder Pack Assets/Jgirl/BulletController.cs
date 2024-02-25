using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   public float bulletSpeed = 10f;
    public float damage = 10f;

    private void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
         if (transform.position.x <= -30f || transform.position.x >= 30f )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CombateJugador jugador = collision.GetComponent<CombateJugador>();
            if (jugador != null)
            {
                jugador.TomarDaño(damage, Vector2.zero);
            }

            Destroy(gameObject);
        }
    }
}