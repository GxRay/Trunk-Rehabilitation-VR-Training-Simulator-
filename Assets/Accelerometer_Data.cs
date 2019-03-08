using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer_Data : MonoBehaviour
{
    Data_Aquisition data;
    // Start is called before the first frame update
    void Start()
    {
        data = new Data_Aquisition();
        data.Begin("192.168.4.1", 80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
