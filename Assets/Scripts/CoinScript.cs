using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int amountOfCoinsPicked = 50;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CoinCollector")
        {
            Destroy(gameObject);

            FindObjectOfType<GameSession>().AddToScore(amountOfCoinsPicked);

            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        }

   



    }
}
