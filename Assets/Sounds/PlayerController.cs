using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speedX = 5f;
    public float speedY = 5f;
    public float spaceBarSpeedIncrease = 5f;
    public float ySpeedDecrease = 2f;
    private bool isFrozen = false;
    private Rigidbody2D rb;
     [SerializeField] private AudioClip Explosion;
     public event EventHandler MuerteJugador;
     private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = speedX;

        // Aumentar la velocidad en el eje Y cuando se presiona la barra espaciadora
        float moveVertical = Input.GetKeyUp(KeyCode.Space) ? speedY + spaceBarSpeedIncrease : Mathf.Max(rb.velocity.y - ySpeedDecrease, 0);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isFrozen)
        {
            animator.SetTrigger("Muerte");
            Explode();
            FreezePlayer();
            StartCoroutine(Muelto());
        }
    }
 public void  MuerteJugadorEvento() {
    MuerteJugador?.Invoke(this, EventArgs.Empty);
    }
     private IEnumerator Muelto() {
        yield return new WaitForSeconds(5f);
        MuerteJugadorEvento();
    }
    private void Explode()
    {
        ControladorSonido.Instance.EjecutarSonido(Explosion);
        // Instantiate the explosion prefab at the player's position

        // Destroy the player object
        Destroy(gameObject, 5f);
    }

    private void FreezePlayer()
    {
        // Disable the player's Rigidbody component to freeze its movement
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        // Set the isFrozen flag to true
        isFrozen = true;
    }
    
}
