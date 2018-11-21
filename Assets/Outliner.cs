using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outliner : MonoBehaviour
{
    public Color color = Color.black;
    public OutlineMode drawMode = OutlineMode.Cube;

    public enum OutlineMode
    {
        Cube,
        WireCube
    }

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        var rectTransform = GetComponent<RectTransform>();
        Vector3 size;
        if (rectTransform != null)
        {
            size = new Vector3(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
        }
        else
        {
            size = new Vector3(transform.localScale.x, transform.localScale.y);
        }

        switch (drawMode)
        {
            case OutlineMode.Cube:
                Gizmos.DrawCube(transform.position, size);
                break;
            case OutlineMode.WireCube:
                Gizmos.DrawWireCube(transform.position, size);
                break;
        }
    }
}
