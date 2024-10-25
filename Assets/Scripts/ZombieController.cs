using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2f;        // Velocidad del zombie
    private bool movingRight = false;  // Direcci�n del movimiento
    private SpriteRenderer spriteRenderer; // Para voltear el sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Aplica el movimiento seg�n la direcci�n
        if (movingRight)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;  // Voltea el sprite hacia la derecha
            
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = false; // Voltea el sprite hacia la izquierda   
        }
    }

    // Detecta las colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisi�n fue en los lados
        if (collision.contacts[0].normal.x != 0)
        {
            // Cambia la direcci�n
            movingRight = !movingRight;
        }
    }
}