using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_BackWall : MonoBehaviour
{
  

   

    private void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);
       
    }
}
