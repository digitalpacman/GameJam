using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    public Color color = Color.black;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        var rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            Gizmos.DrawCube(transform.position, new Vector3(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y));
        }
        else
        {
            Gizmos.DrawCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y));
        }
    }
}
