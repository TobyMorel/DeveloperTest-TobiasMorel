using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    public int damageAmount = 1; // Cantidad de daño que la bomba le hará al jugador
    ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindAnyObjectByType<ObjectPool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Toque Player");

            // Obtener el componente de salud del jugador
            PlayerLife playerHealth = collision.gameObject.GetComponent<PlayerLife>();

            // Verificar si el componente de salud existe en el jugador
            if (playerHealth != null)
            {
                // Reducir la vida del jugador
                playerHealth.TakeDamage(damageAmount);
            }

            objectPool.ReturnObjectToPool(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            objectPool.ReturnObjectToPool(this.gameObject);
        }
    }
}
