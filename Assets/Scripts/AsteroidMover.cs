using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour {
    public Rigidbody2D rb;
    public float pushForce;
    public float destroyDistance;
    public float lifetime;              // max time on screen

    AsteroidSpawner spawner;

    void OnEnable()
    {
        spawner = GameObject.Find("GameController").GetComponent<AsteroidSpawner>();
        
        // when the asteroid is made, add force in a random direction as an impulse
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * pushForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        //Debug.Log(distance);

        if (distance >= destroyDistance)
        {
            Destroy(gameObject);
            spawner.AsteroidCount--;
        }

        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
            spawner.AsteroidCount--;
        }
    }
}
