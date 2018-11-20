using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavPlane : MonoBehaviour, IPointerClickHandler {

    public HeroController Hero;

    public void OnPointerClick(PointerEventData pointerData) {
        Vector3 worldPosition = pointerData.pointerCurrentRaycast.worldPosition;
        Debug.Log(0);
        if (Input.GetMouseButtonUp(0)) {
            //
        }
        else if (Input.GetMouseButtonUp(1)) {
            Hero.Agent.SetDestination(worldPosition);
        }
    }

}
