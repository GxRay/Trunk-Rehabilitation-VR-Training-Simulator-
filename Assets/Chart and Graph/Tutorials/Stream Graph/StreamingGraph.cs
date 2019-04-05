using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{

    public GraphChart[] Graph;
    public Data_Aquisition AccelInfo = new Data_Aquisition();
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    private float Timer = 0.001f;
    private float X = 1f;

    void Start()
    {
        //if (AccelInfo.client.Connected == false)
        //{
            AccelInfo.Begin("10.17.234.137", 80);
            Debug.Log("Finished TCP Begin");
        //}

        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;

        foreach (GraphChart g in Graph){
            g.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        }

        Graph[0].DataSource.ClearCategory("EMGleftRA"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        Graph[1].DataSource.ClearCategory("EMGrightRA");
        Graph[2].DataSource.ClearCategory("EMGleftOb");
        Graph[3].DataSource.ClearCategory("EMGrightOb");
        Graph[4].DataSource.ClearCategory("EMGerect");
        //Graph.DataSource.ClearCategory("EMG2");
        //Graph.DataSource.ClearCategory("EMG3");
        //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        //for (int i = 0; i < TotalPoints; i++)  //add random points to the graph
        //{
            Graph[0].DataSource.AddPointToCategory("EMGleftRA", 0, 0); // each time we call AddPointToCategory
            Graph[1].DataSource.AddPointToCategory("EMGrightRA", 0, 0);
            Graph[2].DataSource.AddPointToCategory("EMGleftOb", 0, 0);
            Graph[3].DataSource.AddPointToCategory("EMGrightOb", 0, 0);
            Graph[4].DataSource.AddPointToCategory("EMGerect", 0, 0);
        //Graph.DataSource.AddPointToCategory("EMG2", 0, 0);
        //Graph.DataSource.AddPointToCategory("EMG3", 0, 0);
        //Graph.DataSource.AddPointToCategory("Player 2", 0, 0); // each time we call AddPointToCategory 
        //    x -= Random.value * 3f;
        //    lastX = x;
        //}

        foreach (GraphChart g in Graph)
        {
            g.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
        }

        Debug.Log("Finished start method");
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Timer=0.001f;
            //lastX += Random.value * 3f;
            //            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph[0].DataSource.AddPointToCategoryRealtime("EMGleftRA", X, AccelInfo.EMGleftRA, 0.001f);// each time we call AddPointToCategory 
            Graph[1].DataSource.AddPointToCategoryRealtime("EMGrightRA", X, AccelInfo.EMGrightRA, 0.001f);
            Graph[2].DataSource.AddPointToCategoryRealtime("EMGleftOb", X, AccelInfo.EMGleftOb, 0.001f);
            Graph[3].DataSource.AddPointToCategoryRealtime("EMGrightOb", X, AccelInfo.EMGrightOb, 0.001f);
            Graph[4].DataSource.AddPointToCategoryRealtime("EMGerect", X, AccelInfo.EMGerect, 0.001f);
            //Graph.DataSource.AddPointToCategoryRealtime("EMG2", X, AccelInfo.Accely, 0.001f);
            //Graph.DataSource.AddPointToCategoryRealtime("EMG3", X, AccelInfo.Accelz, 0.001f);
            //Graph.DataSource.AddPointToCategoryRealtime("Player 2", X, UnityEngine.Random.value*100f,0.01f); // each time we call AddPointToCategory
            X++;
        }

    }
}
