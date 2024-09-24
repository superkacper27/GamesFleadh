using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //shouldnt make every variable public
    public AudioSource Music;

    public bool startMusic;

    public BeatScroller BS;

    public static GameManager instance;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject unsuccess;
    [SerializeField] private GameObject blackBg;
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private GameObject SplashScreen;
    private GameObject playerInteractUI;// interact text (infect)
    private GameObject infectedScoreUI; // score of the main game
    private GameObject player;
    [SerializeField] private GameObject nearestNpc;
    [SerializeField] private GameObject[] allNpcs;
    [SerializeField] private GameObject bgAmbientObj;
    private NPCInteractable npc;
    private AudioSource bgAmbient;
    float distance;
    float nearestDistance = 10000;

    public int currentScore;

    public int scorePerNote;

    public int scorePerNormalHit = 100;

    public int scorePerGoodNote = 150;

    public int scorePerPerfectNote = 200;

    public Text scoreText;

    public Text multiText;

    public int currentMultiplier;

    public int multiplierTracker;
    public int[] multiplierTresholds;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    //public GameObject SplashScreen;

    public static bool levelPassed;

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
        normalHits = goodHits = perfectHits = missedHits = 0;
        levelPassed = false;
        totalNotes = FindObjectsOfType<Note>().Length;
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        for(int  i = 0; i < allNpcs.Length; i++)
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
        if (!startMusic)
        {
            if (Input.anyKeyDown)
            {
                startMusic = true;
                BS.hasStarted = true;
                SplashScreen.SetActive(false);
                Music.Play();
            }
        }
        if (totalNotes == (normalHits + goodHits + perfectHits + missedHits) && npc.minigameOn)
        {
            blackBg.SetActive(true);
            if (currentScore >= 1000)
            {
                levelPassed = true;
                success.SetActive(true);
                npc.isInfected = true;
                infectedSO.ScoreMultiplier += 0.1f;
                infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
                // Set player and UI to true
                player.SetActive(true);
                infectedScoreUI.SetActive(true);
                playerInteractUI.SetActive(true);
                bgAmbient.Play();
                npc.minigameOn = false;
            }
            else
            {
                levelPassed = false;
                unsuccess.SetActive(true);
                npc.isInfected = false;
                infectedSO.ScoreMultiplier = 1f; // reset infect multiplier
                // Set player and UI to true
                player.SetActive(true);
                infectedScoreUI.SetActive(true);
                playerInteractUI.SetActive(true);
                bgAmbient.Play();
                npc.minigameOn = false;
            }
        }

    }


    public void NoteHit()
    {
        Debug.Log("Hit on time!");
        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;
            if (multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
                multiText.text = "Multiplier: x" + currentMultiplier;
            }
        }
        /*currentScore += (scorePerNote*currentMultiplier);*/
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += (scorePerNormalHit * currentMultiplier);
        NoteHit();
        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += (scorePerGoodNote*currentMultiplier);
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += (scorePerPerfectNote*currentMultiplier);
        NoteHit();

        perfectHits++;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed note!");
        currentScore -= scorePerNote;
        currentMultiplier = 1;
        multiplierTracker = 0;
        scoreText.text = "Score: "+currentScore;
        multiText.text = "Multiplier: x"+currentMultiplier;

        missedHits++;
    }
}
