using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//-----------------
// Shredder.cs
// Allows to destroy the enemies that are off screen
//-----------------

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        FindObjectOfType<Level>().showGameOver();
    }
}
