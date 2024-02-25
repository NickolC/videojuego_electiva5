using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
  [SerializeField] private GameObject menu;
  [SerializeField] private GameObject hud;
  [SerializeField] private GameObject menuPausa;
  private CombateJugador combateJugador;
  private PlayerController playerController;
  [SerializeField] private bool Jugadores;
  private bool juegoPausado = false;
  private void Start() {
    if(Jugadores) {
    combateJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<CombateJugador>();
    combateJugador.MuerteJugador += AbrirMenu;
    } else {
    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    playerController.MuerteJugador += AbrirMenu;
    }
    
   
  }
  private void AbrirMenu (object sender, EventArgs e) {
    menu.SetActive(true);
    hud.SetActive(false);
  }
  public void Reiniciar () {
    juegoPausado= false;
    menu.SetActive(false);
    hud.SetActive(true);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    Physics2D.IgnoreLayerCollision(7, 8, false); 
  }
  public void Pausa() {
    juegoPausado = true;
    Time.timeScale = 0f;
    hud.SetActive(false);
    menuPausa.SetActive(true);
  }
  public void Reanudar(){
    juegoPausado= false;
   Time.timeScale = 1f;
    hud.SetActive(true);
    menuPausa.SetActive(false);
}
public void Quit(){
Application.Quit();
}
 private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)) {
      if(juegoPausado) {
        Reanudar();
      } else {
        Pausa();
      }
       }
       
    }
    public void IrAlMenuInicial()
    {
        SceneManager.LoadScene(0);
        Physics2D.IgnoreLayerCollision(7, 8, false); 
    }
}