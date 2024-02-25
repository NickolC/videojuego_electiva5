using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
[SerializeField] private Transform[] puntosMovimientos;
[SerializeField] private float  velocidadMovimiento;
private int siguientePlataforma = 1;
private bool ordenPlataformas = true;
private void Update() {
    if(ordenPlataformas && siguientePlataforma + 1 >= puntosMovimientos.Length) {
        ordenPlataformas = false;
    }
    if(!ordenPlataformas && siguientePlataforma  <= 0) {
        ordenPlataformas = true;
    }
    if(Vector2.Distance(transform.position, puntosMovimientos[siguientePlataforma].position) < 0.1f) {
        if(ordenPlataformas) {
            siguientePlataforma +=1;
        } else {
            siguientePlataforma -=1;
        }
        
    }
    transform.position = Vector2.MoveTowards(transform.position, puntosMovimientos[siguientePlataforma].position, velocidadMovimiento * Time.deltaTime);
}
private void OnCollisionEnter2D(Collision2D other)
{
    if(other.gameObject.CompareTag("Player")) {
        other.transform.SetParent(this.transform); 
    }
}
private void OnCollisionExit2D(Collision2D other)
{
     if(other.gameObject.CompareTag("Player")) {
        other.transform.SetParent(null);
    }
}
}

