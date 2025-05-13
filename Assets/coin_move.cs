using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyZ = -15f; //destroy when off screen
    public int coinValue = 1; //coin value

    // Update is called once per frame
    void Update()
    { 

        if (Time.timeScale > 0) // Only move when the game is not paused
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime; //scrolling around the screen
        }
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Coin collected!"); //debug

            Score scoreManager = FindObjectOfType<Score>();
            if (scoreManager != null)
            {
                Debug.Log("Adding score...");
                Debug.Log("Adding score...");
                scoreManager.AddScore(coinValue);
            }

            Destroy(gameObject);

        }
    }

}
