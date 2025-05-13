using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyZ = -15f; //destroy when off screen

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }

}