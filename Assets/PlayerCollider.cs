using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var hits = collision.gameObject.GetComponent<HitsPlayer>();
        if (hits != null)
        {
            hits.Hit();
        }
    }
}
