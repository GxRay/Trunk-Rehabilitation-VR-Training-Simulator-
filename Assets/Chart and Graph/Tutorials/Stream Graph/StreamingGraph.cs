using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;
using UnityEngine;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{

    public GraphChart[] Graph;
    public Data_Aquisition AccelInfo = new Data_Aquisition();
    private float X = 1f;
    public Data_Aquisition.PointData item = new Data_Aquisition.PointData();
    List<Data_Aquisition.PointData> copy;


    void Start()
    {
        //if (AccelInfo.client.Connected == false)
        //{
        //AccelInfo.Begin("10.17.35.42", 80); //RU Secure on testing board
        AccelInfo.Begin("10.17.151.14", 80); //RU Secure
        //AccelInfo.Begin("192.168.1.8", 80); //Home Testing
        Debug.Log("Finished TCP Begin");
        //}

        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;

        foreach (GraphChart g in Graph)
        {
            g.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        }

        Graph[0].DataSource.ClearCategory("EMGleftRA"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph[1].DataSource.ClearCategory("EMGrightRA");
        Graph[2].DataSource.ClearCategory("EMGleftOb");
        Graph[3].DataSource.ClearCategory("EMGrightOb");
        Graph[4].DataSource.ClearCategory("EMGerect");

        Graph[0].DataSource.AddPointToCategory("EMGleftRA", 0, 0); // each time we call AddPointToCategory
        Graph[1].DataSource.AddPointToCategory("EMGrightRA", 0, 0);
        Graph[2].DataSource.AddPointToCategory("EMGleftOb", 0, 0);
        Graph[3].DataSource.AddPointToCategory("EMGrightOb", 0, 0);
        Graph[4].DataSource.AddPointToCategory("EMGerect", 0, 0);

        foreach (GraphChart g in Graph)
        {
            g.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
        }

        Debug.Log("Finished start method");
    }

    void Update()
    {
        lock (AccelInfo.EMGdata)
        {
            //    copy = new List<Data_Aquisition.PointData>(AccelInfo.EMGdata);
            //    AccelInfo.EMGdata.Clear();
            //    Debug.Log("Copied List, Cleared List");
            //}
            for (int i = 0; i < AccelInfo.EMGdata.Count; i++)
            {
                Graph[0].DataSource.AddPointToCategoryRealtime("EMGleftRA", X, AccelInfo.EMGdata[i].EMGleftRA, 0f);// each time we call AddPointToCategory 
                Graph[1].DataSource.AddPointToCategoryRealtime("EMGrightRA", X, AccelInfo.EMGdata[i].EMGrightRA, 0f);
                Graph[2].DataSource.AddPointToCategoryRealtime("EMGleftOb", X, AccelInfo.EMGdata[i].EMGleftOb, 0f);
                Graph[3].DataSource.AddPointToCategoryRealtime("EMGrightOb", X, AccelInfo.EMGdata[i].EMGrightOb, 0f);
                Graph[4].DataSource.AddPointToCategoryRealtime("EMGerect", X, AccelInfo.EMGdata[i].EMGerect, 0f);
                X++;
            }
            Debug.Log("Updated Graphs");
            AccelInfo.EMGdata.Clear();
        }
    }
}
