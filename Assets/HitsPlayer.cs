using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsPlayer : MonoBehaviour
{
    public void Hit()
    {
        Destroy(gameObject);
    }
}
