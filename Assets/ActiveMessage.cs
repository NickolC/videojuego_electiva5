using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMessage : MonoBehaviour
{
    [SerializeField] private GameObject Mensaje;
    private void Start()
    {
        Mensaje.SetActive(false);
            }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.tag == "Player")
        {
        Mensaje.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Mensaje.SetActive(false);
        }
    }

}
