using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
 private Rigidbody2D rb2D;
 public bool sePuedeMover = true;
 [SerializeField] private Vector2 velocidadReboteX;
 [Header("Movimiento")]
  private float movimientoHorizontal;
 [SerializeField] private float velocidadDeMovimiento;
 [SerializeField] private float suavizadoDeMovimiento;
 private Vector3 velocidad = Vector3.zero;
 private bool mirandoDerecha = true;
 
[Header("Salto")]
[SerializeField] private float fuerzaDeSalto;
[SerializeField] private LayerMask queEsSuelo;
[SerializeField] private Transform controladorSuelo;
[SerializeField] private Vector3 dimensionesCaja;
[SerializeField] private bool enSuelo;
private bool salto = false;
[Header("Animación")]
private Animator animator;
[Header("Salto Regulable")]
[Range(0,1)] [SerializeField] private float multiplicadorCancelarSalto;
[SerializeField] private float multiplicadorGravedad;
private float escalaGravedad;
private bool botonSaltoArriba = true;
[Header("Rebote")]
[SerializeField] private float velocidadRebote;
[Header("Sonido")]
[SerializeField] private AudioClip saltoSonido;





private void Start() {
    rb2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    escalaGravedad = rb2D.gravityScale;
 }


 private void Update() {
    movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
    animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
    if(Input.GetButton("jump") || Input.GetButton("Jump")) {
        salto = true;
    }
    if(Input.GetButtonDown("Jump") || Input.GetButtonDown("jump")) {

        if(enSuelo) {
            ControladorSonido.Instance.EjecutarSonido(saltoSonido);
        }
    }
    if(Input.GetButtonUp("Jump") || Input.GetButtonUp("jump")) {
        
        BotonSaltoArriba();
    }
 }


 private void FixedUpdate() {
    enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
    animator.SetBool("enSuelo", enSuelo);
    //Mover
    if(sePuedeMover) {
       Mover(movimientoHorizontal * Time.fixedDeltaTime, salto); 
    }
    
    salto = false;
    if(rb2D.velocity.y < 0 && !enSuelo) {
        rb2D.gravityScale = escalaGravedad * multiplicadorGravedad;
    }
    else {
        rb2D.gravityScale = escalaGravedad;
    }


 }




    private void Mover(float mover, bool saltar){
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);  
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);
        
        if(mover >0 && !mirandoDerecha)
        {
            //Girar
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            //Girar
            Girar();
        }
        if(enSuelo && saltar && botonSaltoArriba) {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
            salto = false;
            botonSaltoArriba = false;
            
        }
 }
 public void ReboteX (Vector2 puntoGolpe) {
rb2D.velocity = new Vector2(-velocidadReboteX.x * puntoGolpe.x, velocidadReboteX.y);    
 }
public void Rebote() {
    rb2D.velocity = new Vector2(rb2D.velocity.x, velocidadRebote);
 }
 private void Girar (){
    mirandoDerecha = !mirandoDerecha;
    Vector3 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
 }
 
 private void BotonSaltoArriba() {
    if(rb2D.velocity.y >0) {
        rb2D.AddForce(Vector2.down * rb2D.velocity.y * (1-multiplicadorCancelarSalto), ForceMode2D.Impulse);
    }
    botonSaltoArriba =true; 
    salto = false;
 }
 void OnDrawGizmos()
 {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
 }
}
