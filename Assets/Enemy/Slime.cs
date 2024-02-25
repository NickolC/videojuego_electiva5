using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    private Animator animator;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    [SerializeField] private AudioClip Dead;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.GetContact(0).normal.y < 0) {
                ControladorSonido.Instance.EjecutarSonido(Dead);
                animator.SetTrigger("Golpe");
                other.gameObject.GetComponent<MovimientoJugador>().Rebote();
                puntaje.SumarPuntos(cantidadPuntos);
                
            } else {
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(20, other.GetContact(0).normal);
            }
           
        }
    }
    public void Golpe() {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        Instantiate(efecto, transform.position, transform.rotation);
        Destroy(gameObject); 
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}

