using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI MyScoreText;
    public static int ScoreNum;
    public static bool mazeRunning = true;
    public CountdownTimer mazeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        mazeRunning = true;
        ScoreNum = 0;
        MyScoreText.text = "Cells infected : " + ScoreNum + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreNum == 6 || CountdownTimer.currentTime <= 0f)
        {
            mazeRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.tag == "Coin")
        {
            ScoreNum += 1;
            MyScoreText.text = "Cells infected :" + ScoreNum + "/6";
            Destroy(coin.gameObject);


        }
     }
     
 }
