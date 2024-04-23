using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento horizontal
    public float fuerzaSalto = 10f; // Fuerza del salto

    private Rigidbody2D rb;
    private bool enSuelo = false;

    bool moviendoIzquierda;
    bool moviendoDerecha;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        // Movimiento horizontal
        float movimientoHorizontal = 0f;
        if (moviendoIzquierda)
        {
            movimientoHorizontal = -1f;
        }
        if (moviendoDerecha)
        {
            movimientoHorizontal = 1f;
        }

        transform.Translate(new Vector3(movimientoHorizontal * velocidadMovimiento * Time.deltaTime, 0f, 0f));
    }

    public void JumpPlayer()
    {
        // Salto si est� en el suelo y se presiona la tecla de salto
        if (enSuelo)
        {
            enSuelo = false;
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verificar si est� en el suelo
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
    }

    public void OnRightButtonDown()
    {
        moviendoDerecha = true;
    }

    public void OnRightButtonUp()
    {
        moviendoDerecha = false;
    }


}
