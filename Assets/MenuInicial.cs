using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update
   public void Jugar() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void Salir () {
    Application.Quit();
   }
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            SceneManager.LoadScene(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            SceneManager.LoadScene(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)) {
            SceneManager.LoadScene(8);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            SceneManager.LoadScene(10);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) {
            SceneManager.LoadScene(12);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)) {
            SceneManager.LoadScene(14);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)) {
            SceneManager.LoadScene(16);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            SceneManager.LoadScene(18);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
            SceneManager.LoadScene(20);
        }
        if(Input.GetKeyDown(KeyCode.O)) {
            SceneManager.LoadScene(26);
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene(28);
        }
    }
   
}
