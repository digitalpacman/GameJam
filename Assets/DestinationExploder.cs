using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationExploder : MonoBehaviour
{
    public Vector3 destination;
    public float explosionBullets = 8;
    public GameObject bullet;

    private float _elapsed;
    
    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;

        if (Vector2.Distance(transform.position, destination) < 0.5 || _elapsed > 5)
        {
            var distance = 2 * Mathf.PI / explosionBullets;
            var r = transform.localScale.x / 2;
            var angle = 0f;
            for (var i = 0; i < explosionBullets; i++)
            {
                var x = transform.position.x + r * Mathf.Cos(angle);
                var y = transform.position.y + r * Mathf.Sin(angle);
                angle += distance;
                var newBullet = Instantiate(bullet);
                newBullet.transform.position = new Vector3(x, y, 0);
                var trajectory = (newBullet.transform.position - transform.position).normalized * 2;
                newBullet.GetComponent<Rigidbody2D>().velocity = trajectory;
            }

            enabled = false;

            Destroy(gameObject);
        }
    }
}
