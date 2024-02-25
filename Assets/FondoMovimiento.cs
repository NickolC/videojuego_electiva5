using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
[SerializeField] private Vector2 velocidadMovimiento;
private Vector2 offset;
private Material material;
private Rigidbody2D jugadorRB;
  private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        FindPlayerObject();
    }

    private void FindPlayerObject()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            jugadorRB = jugador.GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador con la etiqueta 'Player'");
        }
    }

private void Update() {
    offset = (jugadorRB.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
    material.mainTextureOffset += offset;
}
}
