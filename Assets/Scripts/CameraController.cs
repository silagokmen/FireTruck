using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 fark;
    public GameObject car;

    void Start()
    {
        fark = transform.position - car.transform.position;
    }


    void Update()
    {
        transform.position = car.transform.position + fark;
    }
}
