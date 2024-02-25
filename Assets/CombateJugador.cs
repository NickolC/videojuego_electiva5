using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] public float vida;
    private MovimientoJugador movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;
    public event EventHandler MuerteJugador;
    private Rigidbody2D rb2D;
    [SerializeField] private AudioClip JHurt;
    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
       movimientoJugador = GetComponent<MovimientoJugador>(); 
       animator = GetComponent<Animator>();
    }

    public void TomarDaño (float daño, Vector2 posicion) {
        vida -= daño;
        if(vida > 0) {
            ControladorSonido.Instance.EjecutarSonido(JHurt);
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl()); 
        StartCoroutine(DesactivarColisión()); 
        movimientoJugador.ReboteX(posicion);
        }
        else{
            animator.SetTrigger("Muerte");
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            Physics2D.IgnoreLayerCollision(7, 8, true);
            StartCoroutine(Muelto()); 
        }
    
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
      
       if(collision.CompareTag("Pinchos")) {
        TomarDaño(10f, Vector2.zero);
       } 
       if(collision.CompareTag("Bullet")) {
        TomarDaño(10f, Vector2.zero);
       }
    
    }
     private void Update()
    {
        if (transform.position.y < -10f)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(Muelto());
        }
    }
    public void  MuerteJugadorEvento() {
    MuerteJugador?.Invoke(this, EventArgs.Empty);
    }
     private IEnumerator Muelto() {
        yield return new WaitForSeconds(0.2f);
        MuerteJugadorEvento();
    }
     private IEnumerator DesactivarColisión() {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
      Physics2D.IgnoreLayerCollision(7, 8, false);
    }
    private IEnumerator PerderControl() {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }
    public void AumentarVida(float cantidad)
{
    vida += cantidad;
}
}
