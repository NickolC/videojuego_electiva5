using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Vida : MonoBehaviour
{
    public TextMeshProUGUI vidaText;
    private CombateJugador combateJugador;

    private void Start()
    {
        combateJugador = FindObjectOfType<CombateJugador>();
        ActualizarVidaHUD();
    }

    private void Update()
    {
        ActualizarVidaHUD();
    }

    private void ActualizarVidaHUD()
    {
        vidaText.text = combateJugador.vida.ToString();
    }
}