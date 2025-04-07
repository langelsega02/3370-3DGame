using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mech_movement : MonoBehaviour
{
    public float leftPosition = -5f;
    public float rightPosition = 5f;
    public float centerPosition = 0f;

    public float snapSpeed = 30f;

    public float forwardSpeed = 5f;

    private bool isMoving = false;

    private float currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = centerPosition;
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;

        if (!isMoving)
        {
            if (!isMoving)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    // Move left if not already in the left position
                    if (currentPosition == centerPosition)
                        StartCoroutine(SnapToPosition(leftPosition));
                    else if (currentPosition == rightPosition)
                        StartCoroutine(SnapToPosition(centerPosition));
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    // Move right if not already in the right position
                    if (currentPosition == centerPosition)
                        StartCoroutine(SnapToPosition(rightPosition));
                    else if (currentPosition == leftPosition)
                        StartCoroutine(SnapToPosition(centerPosition));
                }
            }
        }

    }

    private IEnumerator SnapToPosition(float targetPosition)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 target = new Vector3(targetPosition, transform.position.y, transform.position.z);

        float journeyLength = Vector3.Distance(startPosition, target);
        float startTime = Time.time;

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            float distanceCovered = (Time.time - startTime) * snapSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, target, fractionOfJourney);

            yield return null;
        }

        transform.position = target;  // Ensure the final position is exactly the target

        currentPosition = targetPosition;

        isMoving = false;
    }
}
