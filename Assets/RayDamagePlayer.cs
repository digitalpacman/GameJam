using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDamagePlayer : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Debug.Log(collision);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player damaged");
        }
    }
}
