using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_Statistics : MonoBehaviour
{

    public TextMeshProUGUI Total_Score_Text, Total_Lives_Text;
    public Player_Collision RoundTotal;
    int tot_score, tot_lives;

    private void Update()
    {
            Score();
            Lives();
        return;
    }

    void Score()
    {
        tot_score = RoundTotal.score;
        Total_Score_Text.text = "Score: " + tot_score.ToString();
    }

    void Lives()
    {
        tot_lives = RoundTotal.lives;
        Total_Lives_Text.text = "Lives: " + tot_lives.ToString();
    }




}
