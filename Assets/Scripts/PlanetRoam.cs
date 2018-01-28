using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRoam : MonoBehaviour {
    public float speed = .5f;
    public float radius = 3f;

    private Vector2 center;
    private float angle;
    float rotateAngleX;
    float rotateAngleY;
    float rotateAngleZ;

    private void Start()
    {
        center = transform.position;
        rotateAngleX = Random.Range(-5f, 5f);
        rotateAngleY = Random.Range(-5f, 5f);
        rotateAngleZ = Random.Range(-5f, 5f);
    }

    private void Update()
    {
        // circular motion
        angle += speed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;

        transform.Rotate(rotateAngleX * Time.deltaTime, rotateAngleY * Time.deltaTime, rotateAngleZ * Time.deltaTime);
    }
}
