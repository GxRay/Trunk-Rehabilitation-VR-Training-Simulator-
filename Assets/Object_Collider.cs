using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Collider : MonoBehaviour
{
    float moveSpeedSpike = 10f;
    float rotateSpeedSpike = 50f;
    float rotateSpeedGem = 70f;
    float moveSpeedGem = 5f;

    // Update is called once per frame
    void Update()
    {
        
        //  Moves object in relation to World axi's and Rotates object in relation to objects axis.
        if (gameObject.tag == "Spike")
        {
         transform.Rotate(0, 0,rotateSpeedSpike * Time.deltaTime, Space.Self);
            transform.Translate(0, 0, moveSpeedSpike * Time.deltaTime,Space.World);
        }
        if (gameObject.tag == "Score_Gem" || gameObject.tag == "Life_Gem")
        {
            transform.Rotate(0, rotateSpeedGem * Time.deltaTime, 0, Space.Self);
            transform.Translate(0, 0, moveSpeedGem * Time.deltaTime, Space.World);
        }

    }
}
