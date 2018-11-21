using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript_Character : MonoBehaviour {

    public List<Sprite> sprites = new List<Sprite>();
    public SpriteRenderer r;
    public Camera cam;

    private void Awake() {
        cam = Camera.main;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.D)) {
            r.sprite = sprites[0];
            var pos = transform.position;
            pos.x += 5 * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.S)) {
            r.sprite = sprites[1];
            var pos = transform.position;
            pos.y -= 5 * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.A)) {
            r.sprite = sprites[2];
            var pos = transform.position;
            pos.x -= 5 * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.W)) {
            r.sprite = sprites[3];
            var pos = transform.position;
            pos.y += 5 * Time.deltaTime;
            transform.position = pos;
            
        }

        Vector3 cPos = cam.transform.position;
        cPos.x = RoundToNearestPixel(cPos.x);
        cPos.y = RoundToNearestPixel(cPos.y);
        cam.transform.position = cPos;
    }

    public float RoundToNearestPixel(float unityUnits) {
        float valueInPixels = (Screen.height / (cam.orthographicSize * 2)) * unityUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float adjustedUnityUnits = valueInPixels / (Screen.height / (cam.orthographicSize * 2));
        return adjustedUnityUnits;
    }
}
