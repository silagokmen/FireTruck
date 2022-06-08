using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarController : MonoBehaviour
{

    float speed = 5;
    private float destroyBound = 14f;
    private float destroyBound2 = 56f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.z > destroyBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > destroyBound2)
        {
            Destroy(gameObject);
        }
    }
}
