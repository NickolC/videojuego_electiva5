using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJefe : MonoBehaviour
{
[SerializeField] public float velocidadInicial;
[SerializeField] public float velocidadMaxima;
[SerializeField] public float tasaAumentoVelocidad;
[SerializeField] public float tasaDisminucionVelocidad;
[SerializeField] public float tiempoEspera;
[SerializeField] private Transform controladorSuelo;
[SerializeField] private float distancia;
[SerializeField] private bool moviendoDerecha;
private Rigidbody2D rb;
private float tiempoActualEspera;
private bool esperando;
private Animator animator;

private void Start()
{
     animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(velocidadInicial, rb.velocity.y);
}

private void Update() {
    animator.SetFloat("Velocidad", Mathf.Abs(velocidadMaxima));
}
private void FixedUpdate()
{
    RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
    if (!esperando)
    {
        if (rb.velocity.x < velocidadMaxima)
        {
            if(rb.velocity.x < 0) {
                rb.velocity = new Vector2(rb.velocity.x - tasaAumentoVelocidad, rb.velocity.y);
            } else { 
                 rb.velocity = new Vector2(rb.velocity.x + tasaAumentoVelocidad, rb.velocity.y);
            }
            
        }
    }
    else
    {
        if (tiempoActualEspera < tiempoEspera)
        {
            tiempoActualEspera += Time.deltaTime;
        }
        else
        {
            esperando = false;
            tiempoActualEspera = 0f;
        }
    }

    if (informacionSuelo == false)
    {
        Girar();
    }
}

private void Girar()
{
    moviendoDerecha = !moviendoDerecha;
    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    velocidadInicial *= -1;
    rb.velocity = new Vector2(velocidadInicial, rb.velocity.y);
    esperando = true;
    tiempoActualEspera = 0f;
}

private void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
}
}

