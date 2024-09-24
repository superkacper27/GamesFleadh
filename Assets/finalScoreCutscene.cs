using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScoreCutscene : MonoBehaviour
{
    private TextMeshProUGUI finalScore;
    [SerializeField] private infectedSO infectedSO;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = gameObject.GetComponent<TextMeshProUGUI>();
        finalScore.text = ((int)infectedSO.Score).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
