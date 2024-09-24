    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MazeController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject nearestNpc;
    [SerializeField] private GameObject[] allNpcs;
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject unsuccess;
    [SerializeField] private GameObject blackBg;
    private GameObject playerInteractUI; // interact text (infect)
    private GameObject infectedScoreUI; // score of the main game
    [SerializeField] private GameObject MyScoreText; // score of maze
    [SerializeField] private GameObject countdownText; // timer
    [SerializeField] private GameObject bgAmbientObj;

    private AudioSource bgAmbient;
    private NPCInteractable npc;
    [SerializeField] private ScoreScript scoreObj;
    [SerializeField] private CountdownTimer countTime;
    public static bool levelPassed;

    float distance;
    float nearestDistance = 10000;

    private void Awake()
    {
        bgAmbientObj = GameObject.FindGameObjectWithTag("ambient");
        bgAmbient = bgAmbientObj.GetComponent<AudioSource>();
        playerInteractUI = GameObject.FindGameObjectWithTag("InteractUI");
        infectedScoreUI = GameObject.FindGameObjectWithTag("Score");
        infectedScoreUI.SetActive(false);
        playerInteractUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        allNpcs = GameObject.FindGameObjectsWithTag("Person");

        for (int i = 0; i < allNpcs.Length; i++)
        {
            distance = Vector3.Distance(player.transform.position, allNpcs[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestNpc = allNpcs[i];
                nearestDistance = distance;
            }
            npc = nearestNpc.GetComponent<NPCInteractable>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreScript.mazeRunning == false)
        {
            if ((ScoreScript.ScoreNum <= 6 && CountdownTimer.currentTime > 0f) && npc.minigameOn)
            {
                levelPassed = true;
                blackBg.SetActive(true);
                success.SetActive(true);
                npc.isInfected = true;
                infectedSO.ScoreMultiplier += 0.1f;
                infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
                // Set player and UI to true
                player.SetActive(true);
                infectedScoreUI.SetActive(true);
                playerInteractUI.SetActive(true);

                MyScoreText.SetActive(false);
                countdownText.SetActive(false);
                bgAmbient.Play();
                npc.minigameOn = false;
            }
            else if ((ScoreScript.ScoreNum < 6 && CountdownTimer.currentTime == 0f) && npc.minigameOn)
            {
                levelPassed = false;
                blackBg.SetActive(true);
                unsuccess.SetActive(true);
                npc.isInfected = false;
                infectedSO.ScoreMultiplier = 1f; // reset infect multiplier
                                                 // Set player and UI to true
                player.SetActive(true);
                infectedScoreUI.SetActive(true);
                playerInteractUI.SetActive(true);

                MyScoreText.SetActive(false);
                countdownText.SetActive(false);
                bgAmbient.Play();
                npc.minigameOn = false;
            }
        }

    }
}
