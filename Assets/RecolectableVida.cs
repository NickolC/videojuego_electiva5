using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectableVida : MonoBehaviour
{
    private Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CombateJugador combateJugador = collision.GetComponent<CombateJugador>();
            if (combateJugador != null)
            {
                combateJugador.AumentarVida(20f);
                animator.SetTrigger("Collected");
                Destroy(gameObject, 0.6f);
            }
        }
    }
}
