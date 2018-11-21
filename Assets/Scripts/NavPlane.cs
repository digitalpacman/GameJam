using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

public class NavPlane : MonoBehaviour, IPointerClickHandler {

    public HeroController Hero;
    public Tilemap Walls;
    public Collider2D TilemapCollider;
    public CompositeCollider2D Collider;

    Mesh BlockingMesh;
    public MeshFilter MeshFilter;

    void Start() {
        GenerateBlockingMesh();
    }

    public void OnPointerClick(PointerEventData pointerData) {
        Vector3 worldPosition = pointerData.pointerCurrentRaycast.worldPosition;
        if (Input.GetMouseButtonUp(0)) {
            //
        }
        else if (Input.GetMouseButtonUp(1)) {
            Hero.Agent.SetDestination(worldPosition);
        }
    }


    //
    public void GenerateBlockingMesh() {

        for (int i = 0; i < Collider.pathCount; i++) {
            Vector2[] test = new Vector2[Collider.GetPathPointCount(i)];
            int x = Collider.GetPath(i, test);

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
            go.transform.parent = MeshFilter.gameObject.transform;
            Mesh mesh = new Mesh();
            Vector3[] verts = new Vector3[test.Length];
            for (int j = 0; j < verts.Length; j++) {
                verts[j] = test[j];
            }
            mesh.vertices = verts;
            mesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
            go.GetComponent<MeshFilter>().mesh = mesh;

            NavMeshModifier mod = go.AddComponent<NavMeshModifier>();
            mod.area = 1;
            mod.overrideArea = true;
        }

        MeshFilter.gameObject.transform.position = MeshFilter.gameObject.transform.position + Walls.gameObject.transform.position;

        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
