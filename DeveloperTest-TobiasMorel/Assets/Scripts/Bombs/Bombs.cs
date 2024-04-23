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

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó es el jugador
        if (other.CompareTag("Player"))
        {
            print("Toque Player");

            // Obtener el componente de salud del jugador
            PlayerLife playerHealth = other.GetComponent<PlayerLife>();

            // Verificar si el componente de salud existe en el jugador
            if (playerHealth != null)
            {
                // Reducir la vida del jugador
                playerHealth.TakeDamage(damageAmount);
            }

            objectPool.ReturnObjectToPool(this.gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            objectPool.ReturnObjectToPool(this.gameObject);
        }
    }
}
