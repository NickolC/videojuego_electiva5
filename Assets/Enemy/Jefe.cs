using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Jefe : MonoBehaviour
{
    private Animator animator;
    private int vidas = 3;
    private Transform target;
    private Rigidbody2D rb;
   [SerializeField] private List<GameObject> enemigosPrefabs; // Prefab del enemigo a generar
    [SerializeField] private int cantidadEnemigos; // Cantidad de enemigos a generar al caer
         [SerializeField] private float tiempoGeneracion = 3f;
         [SerializeField] private AudioClip Hurt;
    private void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
         StartCoroutine(GenerarEnemigos());
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.GetContact(0).normal.y < 0)
            {
                //Trigger Golpe
                animator.SetTrigger("Golpe");
                ControladorSonido.Instance.EjecutarSonido(Hurt);
                other.gameObject.GetComponent<MovimientoJugador>().Rebote();
                Physics2D.IgnoreLayerCollision(7, 8, true);
                vidas--;
               Physics2D.IgnoreLayerCollision(7, 8, false);
                if (vidas <= 0)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    animator.SetTrigger("Muerte");
                    Destroy(gameObject, 1f);
                    StartCoroutine(FinalNivel());
                }
            }
            else
            {
                other.gameObject.GetComponent<CombateJugador>().TomarDaño(20, other.GetContact(0).normal);
            }
        }
    }


 private IEnumerator FinalNivel()
 {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    yield return new WaitForSeconds(15f);
    
 }

    private IEnumerator GenerarEnemigos()
    {
        while (true)
        {
             Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-2f, 2f), 10f, 0f);
            GameObject enemigoPrefab = enemigosPrefabs[Random.Range(0, enemigosPrefabs.Count)];
            Instantiate(enemigoPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(tiempoGeneracion);
        }
    }
    
}

