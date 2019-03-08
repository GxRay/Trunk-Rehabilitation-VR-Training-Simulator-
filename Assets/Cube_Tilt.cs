using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Tilt : MonoBehaviour
{
    Data_Aquisition data;

    void Start()
    {
        data = new Data_Aquisition();
        data.Begin("192.168.4.1", 80);

    }
     void Update ()
    {
       
       this.transform.Translate(data.Accelx * Time.deltaTime, 0, data.Accelz* Time.deltaTime);
    }


         
}
