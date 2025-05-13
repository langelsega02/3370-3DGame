using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float fallThreshold = -5f;
    public float leftThreshold = -10f;
    public GameObject losePanel;
    public GameObject cameraStart;
    public GameObject cameraEnd;

    private Score scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<Score>();
        cameraStart.SetActive(true);
        cameraEnd.SetActive(false);
    }

    void Update()
    {
        // Optional: check if player falls below map
        if (transform.position.y < fallThreshold || transform.position.x < leftThreshold)
        {
            Die("Fell off the map");
        }

        /* Game-over by timer
         if (scoreManager != null && scoreManager.GetTimeLeft() <= 0f)
        {
             Die("Time ran out");
        }*/
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Die("Hit enemy");
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Die("Entered death zone");
        }
    }

    void Die(string reason)
    {
        Debug.Log("Player died: " + reason);
        if (losePanel != null)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        cameraStart.SetActive(false);
        cameraEnd.SetActive(true);

        Destroy(this.gameObject);
    }
}
