using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego Instance;
    [SerializeField] private GameObject[] puntosDeControl;
    [SerializeField] private GameObject jugador;
    private int indexPuntosControl;
    private GameObject jugadorActual;
    public CinemachineVirtualCamera virtualCamera;

private void Start() {
    PlayerPrefs.SetInt("puntosIndex", 0);
}
    private void Awake()
    {
        Instance = this;

        if (indexPuntosControl >= puntosDeControl.Length)
        {
            PlayerPrefs.SetInt("puntosIndex", 0);
            indexPuntosControl = 0;
        }

        indexPuntosControl = PlayerPrefs.GetInt("puntosIndex");
        jugadorActual = Instantiate(jugador, puntosDeControl[indexPuntosControl].transform.position, Quaternion.identity);

        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        virtualCamera.Follow = jugadorActual.transform;
    }
    public void UltimoPuntoControl (GameObject puntoControl) {
        for(int i = 0; i < puntosDeControl.Length; i++) {
            if(puntosDeControl[i] == puntoControl && i>indexPuntosControl) {
                PlayerPrefs.SetInt("puntosIndex", i);
            }
        }
    }
}
