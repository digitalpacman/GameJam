using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossBehavior : MonoBehaviour
{
    public Vector2 target;

    private ConstantLerper lerper;

    private void OnEnable()
    {
        lerper = new ConstantLerper(transform.position, target, 3.0f);
    }

    private void Update()
    {
        transform.Rotate(Vector3.back, 1);
        if (lerper.Lerp())
        {
            transform.position = lerper.Next;
        }
        else
        {
            Destroy(gameObject, 1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player damaged");
        }
    }
}

public class ConstantLerper
{
    private float speed;
    private float startTime;
    private float journeyLength;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    public ConstantLerper(Vector2 startPosition, Vector2 targetPosition, float speed)
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(startPosition, targetPosition);
        this.startPosition = startPosition;
        this.targetPosition = targetPosition;
        this.speed = speed;
    }

    public bool Lerp()
    {
        if (Next == targetPosition) return false;

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        Next = Vector2.Lerp(startPosition, targetPosition, fracJourney);
        return true;
    }

    public Vector2 Next { get; private set; }
}
