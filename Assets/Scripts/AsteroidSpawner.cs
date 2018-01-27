using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    int asteroidCount = 0; // the asteroid count

    public int maxAsteroids;            // max number of asteroids we want
    public GameObject asteroid;         // the asteroid
    public float spawnTimer;            // how much time between spawns
    public Color drawSphereGizmoColor;  // color for gizmo
    public float spawnRadius;           // how far away do we want to spawn the asteroids
    public Transform cameraTransform;   // our camera controller

    float _spawnTimer = 0f; // counter

    public int AsteroidCount
    {
        get
        {
            return asteroidCount;
        }

        set
        {
            asteroidCount = value;
        }
    }


    // draw a sphere around the camera
    void OnDrawGizmos()
    {
        Gizmos.color = drawSphereGizmoColor;

        Gizmos.DrawSphere(cameraTransform.position, spawnRadius);
    }

    // Update is called once per frame
    void Update()
    {
        // spawn
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= spawnTimer)
        {
            Spawn();
            _spawnTimer = 0f;
        }
    }

    void Spawn()
    {
        if (AsteroidCount >= maxAsteroids)
            return;
        AsteroidCount++;
        // spawn within a circle around the asteroidSpawner gameObject
        Vector3 spawnPosition = Random.insideUnitCircle.normalized * spawnRadius;

        float scaler = Random.Range(.5f, 1.5f);

        // spawn an asteroid with the position we want
        GameObject aster = Instantiate(asteroid, spawnPosition, Quaternion.identity);
        aster.transform.localScale *= scaler;
    }
}
