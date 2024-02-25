using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float fireRate = 2f;

    private bool movingToB = true;
    private float fireTimer = 0f;

    private void Update()
    {
        if (movingToB)
        {
            MoveToPoint(pointB.position);
        }
        else
        {
            MoveToPoint(pointA.position);
        }

        fireTimer += Time.deltaTime;
        if (fireTimer >= 1f / fireRate)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    private void MoveToPoint(Vector2 targetPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        // Si ha llegado al punto B, cambia la dirección
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            movingToB = !movingToB;
        }

        // Cambia la dirección hacia la que está mirando
        if (targetPoint.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (targetPoint.x > transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Establece la velocidad de la bala en la dirección hacia la que está mirando
        bulletRb.velocity = transform.right * moveSpeed;
    }
}
