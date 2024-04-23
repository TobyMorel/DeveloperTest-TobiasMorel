using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int maxHealth = 3; // Salud máxima del jugador
    public int currentHealth; // Salud actual del jugador

    private void Start()
    {
        // Al iniciar, establecer la salud actual como la salud máxima
        currentHealth = maxHealth;
    }

    // Método para recibir daño
    public void TakeDamage(int damageAmount)
    {
        // Restar el daño recibido a la salud actual
        currentHealth -= damageAmount;

        // Verificar si la salud actual es menor o igual a 0
        if (currentHealth <= 0)
        {
            // Si la salud es igual o menor a 0, el jugador ha muerto
            Die();
        }
    }

    // Método para manejar la muerte del jugador
    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
    }
}