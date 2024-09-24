using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIinfectedText : MonoBehaviour
{
    [SerializeField] private infectedSO playerScore;
    [SerializeField] private TextMeshProUGUI peopleInfected;
    // Start is called before the first frame update

    private void Awake()
    {
        playerScore.Score = 0;
        playerScore.ScoreMultiplier = 1f;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        peopleInfected.text = "Infected Score  " + playerScore.Score + "\nMultiplier  " + playerScore.ScoreMultiplier;
    }
}
