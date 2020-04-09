using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin picked!");
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        Destroy(gameObject);
    }
}
