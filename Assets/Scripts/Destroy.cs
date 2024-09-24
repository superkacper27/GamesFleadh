using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Destroy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject nearestNpc;
    [SerializeField] private GameObject[] allNpcs;
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject unsuccess;
    [SerializeField] private GameObject blackBg;
    [SerializeField] private GameObject minigameScore;
    private GameObject playerInteractUI; // interact text (infect)
    private GameObject infectedScoreUI; // score of the main game
    [SerializeField] private GameObject bgAmbientObj;

    private AudioSource bgAmbient;
    private NPCInteractable npc;
    public static bool levelPassed;

    public int points = 0;
    public TextMeshProUGUI guiScore;
    public int complete = 0;

    float distance;
    float nearestDistance = 10000;
    // Start is called before the first frame update

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

        guiScore.text = "Score: "+ points.ToString();

        if (points == complete && levelPassed == false) 
        {
            levelPassed = true;
            minigameScore.SetActive(false);
            blackBg.SetActive(true);
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "Person")
        {
            //Create a reference to the man
            GameObject person = collision.gameObject;

            //Destroy the man
            Destroy(person);

            //Debug the new Total
            Debug.Log("Person dead");

            points += 200;
            Debug.Log("Points: " + points);
        }

         if(collision.collider.tag == "virus")
        {
            //Create a reference to the collectable
            GameObject virus = collision.gameObject;

            //Destroy the man
            Destroy(virus);

        }
    }
}


