using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Collider : MonoBehaviour
{
    float moveSpeed = 10f;
    float rotateSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
    }
}
