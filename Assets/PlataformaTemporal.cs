using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTemporal : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    [SerializeField] float velocidadRotacion;
    private Rigidbody2D rb;
    private Animator animator;
    private bool caida = false;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if(caida) {
        transform.Rotate(new Vector3(0,0, -velocidadRotacion * Time.deltaTime));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")) {
            StartCoroutine(Caida(other));
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Piso")) {
            Destroy(gameObject);
        }
    }
    private IEnumerator Caida(Collision2D other)
    {
        animator.SetTrigger("Desactivar");
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(new Vector2(0.1f, 0));
    }
}
