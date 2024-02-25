using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    [SerializeField] private AudioClip collected;
    private void Start() {
        animator = GetComponent<Animator>();
    }
 private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")) {
        puntaje.SumarPuntos(cantidadPuntos);
       animator.SetTrigger("Collected");
       ControladorSonido.Instance.EjecutarSonido(collected);
        Destroy(gameObject, 0.6f);
    }
} 
    
}
