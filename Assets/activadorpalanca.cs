using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorpalanca : MonoBehaviour
{
     private Animator animator;
     [SerializeField] private GameObject[] pinchos;
        private void Start() {
            animator = GetComponent<Animator>();
            
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Activado");
            DesactivarPinchos();
        }
    }

    private void DesactivarPinchos()
    {
        foreach (GameObject pincho in pinchos)
        {
            pincho.SetActive(false);
        }
    }
}