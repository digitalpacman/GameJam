using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

public class NavPlane : MonoBehaviour, IPointerDownHandler {

    public HeroController Hero;
    public Tilemap Walls;
    public CompositeCollider2D CompositeCollider;    

    void Start() {
        GenerateBlockingMesh();

        // testing
        //EnemyController Enemy = FindObjectOfType<EnemyController>();
        //Enemy.Movement.MoveTo(Vector3.down);
    }

    public void OnPointerDown(PointerEventData pointerData) {
        Vector3 worldPosition = pointerData.pointerCurrentRaycast.worldPosition;
        if (Input.GetMouseButtonDown(0)) {
            if (Hero.enemyTarget != null) { Hero.enemyTarget = null; }
            Hero.MoveTo(worldPosition);
        }
        else if (Input.GetMouseButtonDown(1)) {
            // use ability
        }
    }


    //
    public void GenerateBlockingMesh() {

        for (int i = 0; i < CompositeCollider.pathCount; i++) {
            Vector2[] pathPoints = new Vector2[CompositeCollider.GetPathPointCount(i)];
            CompositeCollider.GetPath(i, pathPoints);

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
            go.transform.parent = transform;
            Mesh mesh = new Mesh();
            Vector3[] verts = new Vector3[pathPoints.Length];
            for (int j = 0; j < verts.Length; j++) {
                verts[j] = pathPoints[j];
            }
            mesh.vertices = verts;
            mesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
            go.GetComponent<MeshFilter>().mesh = mesh;

            NavMeshModifier mod = go.AddComponent<NavMeshModifier>();
            mod.area = 1;
            mod.overrideArea = true;
        }

        //MeshFilter.gameObject.transform.position = MeshFilter.gameObject.transform.position + Walls.gameObject.transform.position;
        transform.position = transform.position + Walls.gameObject.transform.position;

        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
