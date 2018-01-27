using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRoam : MonoBehaviour {
    public float speed = .5f;
    public float radius = 3f;

    private Vector2 center;
    private float angle;

    private void Start()
    {
        center = transform.position;
    }

    private void Update()
    {
        // circular motion
        angle += speed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
    }
}
