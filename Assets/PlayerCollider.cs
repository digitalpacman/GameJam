using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) GetComponent<Rigidbody2D>().velocity += Vector2.up;
        if (Input.GetKey(KeyCode.A)) GetComponent<Rigidbody2D>().velocity += Vector2.left;
        if (Input.GetKey(KeyCode.S)) GetComponent<Rigidbody2D>().velocity += Vector2.down;
        if (Input.GetKey(KeyCode.D)) GetComponent<Rigidbody2D>().velocity += Vector2.right;
        //GetComponent<Rigidbody2D>().AddForce(Vector3.up * 0.5f);
    }
}
