using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_Graph : MonoBehaviour
{
    // Sprite can be set in Unity Editor
    [SerializeField] private Sprite circleSprite;

    private RectTransform graph_Container;


        private void Awake()
    {
        graph_Container = transform.Find("graph_Container").GetComponent <RectTransform>();

        // data gets put into this list
               List<float> list = new List<float>() { 10f, 15f, 30f, 5f, 100f, 10f, 0f, 86f };
        // Creates Graph
        ShowGraph(list);

    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graph_Container, false);

        // Setting Sprite in Game object to be equal to Circle sprite obtained from Unity Editor
        gameObject.GetComponent<Image>().sprite = circleSprite;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;

        //Setting size of rectangle where sprite will be printed (POSSIBLE LOWER FOR EMG)
        rectTransform.sizeDelta = new Vector2(5, 5);

        // Starts graph at lower left corner, meaning all coordinates are in reference to lower left as origin.
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;

    }

    private void ShowGraph(List<float> list)
    {
        // Difference between each point on the x-axis
        float xsize = 50f;
        float ymax = 100f;
        // Getting total height of Graph Container Frame
        float height = graph_Container.sizeDelta.y;

       // Ensuring graphing starts at 1st point of dataset.
        GameObject lastcircleGameObject = null;
        // Maps x and y data to X and Y coordinates on the graph in 2D space.
        for (int i = 0; i < list.Count; i++)
        {
            float xPosition = i * xsize;
            float yPosition = (list[i] / ymax) * height;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

            // Draws a line from the previous dot position in the data set to the next dot position in the data set.
            if (lastcircleGameObject != null)
            {

                CreateDotConnection(lastcircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
                lastcircleGameObject = circleGameObject;

        }
    }

    // Function creates line that connects dot A to dot B
        private void CreateDotConnection (Vector2 dotpositionA, Vector2 dotpositionB)
        {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graph_Container, false);

        // Setting colour of line connecting dots
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, .5f);

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // Set direction line is going to face
        Vector2 direction = (dotpositionB - dotpositionA).normalized;

       
        float distance = Vector2.Distance(dotpositionA, dotpositionB);
        // Starts graph at lower left corner, meaning all coordinates are in reference to lower left as origin.
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        //Setting size of line
        rectTransform.sizeDelta = new Vector2(distance,3f);

        // Start line at position A (first dot)
                rectTransform.anchoredPosition = dotpositionA + direction* distance *.5f;

        rectTransform.localEulerAngles = new Vector3(0, 0, Vector2Angle(direction));

        
   
    }

    private static float Vector2Angle (Vector3 dir)
    {
        // Calculate the amount of rotation in degrees 
        dir = dir.normalized;
        float newdir = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (newdir < 0)
        {
            newdir += 360;
        }
        return newdir;

    }





}



