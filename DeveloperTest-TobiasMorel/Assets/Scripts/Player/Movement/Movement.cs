using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento horizontal
    public float fuerzaSalto = 10f; // Fuerza del salto

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;

    private bool enSuelo = false;

    bool moviendoIzquierda;
    bool moviendoDerecha;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        float movimientoHorizontal = 0f;
        if (moviendoIzquierda)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("Walk", true);
            movimientoHorizontal = -1f;
        }
        if (moviendoDerecha)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("Walk", true);
            movimientoHorizontal = 1f;
        }

        transform.Translate(new Vector3(movimientoHorizontal * velocidadMovimiento * Time.deltaTime, 0f, 0f));
    }

    public void JumpPlayer()
    {
        // Salto si está en el suelo y se presiona la tecla de salto
        if (enSuelo)
        {
            enSuelo = false;
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verificar si está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si ha dejado de estar en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = false;
        }
    }

    public void OnLeftButtonDown()
    {
        moviendoIzquierda = true;
    }

    public void OnLeftButtonUp()
    {
        moviendoIzquierda = false;
        anim.SetBool("Walk", false);
    }

    public void OnRightButtonDown()
    {
        moviendoDerecha = true;
    }

    public void OnRightButtonUp()
    {
        moviendoDerecha = false;
        anim.SetBool("Walk", false);
    }


}
