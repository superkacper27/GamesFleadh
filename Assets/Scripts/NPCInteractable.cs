using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private infectedSO infectedSO;
    [SerializeField] private string interactText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerInteractUI;
    [SerializeField] private GameObject infectedBubble;
    private GameObject infectedScoreUI; // score of the main game
    [SerializeField] private GameObject ddr;
    [SerializeField] private GameObject maze;
    [SerializeField] private GameObject angryVirus;
    [SerializeField] private Material infectedSkin;
    [SerializeField] private AudioClip[] infectedSoundClips;
    [SerializeField] private AudioSource bgAmbient;
    [SerializeField] private bool isStrong = false;
    private bool isInfectedSound = false;

    private int randomInt;
    private Vector3 minigamePosition;
    public bool isInfected = false;
    public bool minigameOn = false;

    void Start()
    {
        infectedScoreUI = GameObject.FindGameObjectWithTag("Score");
        minigamePosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + 1000, gameObject.transform.localPosition.z); // 1000 on y
    }

    public void Interact()
    {
        npcInfect();

    }

    public string GetInteractText() 
    {
        if (isInfected == true)
        {
            interactText = "Already Infected!";
        }
        return interactText;
    }

    private void npcInfect()
    {
        // normal NPC, will add 1 to the score if isStrong = false // isStrong = true means it will add float number to the multiplier if minigame is passed (somehow)
        if (isInfected == false && isStrong == false)
        {
            infectedSO.Score = infectedSO.Score + (1 * infectedSO.ScoreMultiplier);
            isInfected = true;
        }
        else if (isInfected == false && isStrong == true && minigameOn == false)
        {
            bgAmbient.Pause();
            randomInt = Random.Range(1,3);
            minigameOn = true;
            Debug.Log(randomInt);
            //play minigame, if player wins minigame, adds multiplier, if not, multiplier resets to 0.
            switch (randomInt)
            {
                case 1:
                    Instantiate(ddr, minigamePosition, transform.rotation);
                    break;
                case 2:
                    //Instantiate(maze, minigamePosition, transform.rotation);
                    Instantiate(maze, new Vector3(maze.transform.localPosition.x, maze.transform.localPosition.y, maze.transform.localPosition.z), maze.transform.localRotation);
                    break;
                case 3:

                    Instantiate(angryVirus, minigamePosition, transform.rotation);
                    break;
            }
        }
        else if (isInfected == true)  
        {

            Debug.Log("Player is already infected! Your currently infected " + infectedSO.Score + "people!");
        }


    }

    void Update()
    {
        if (isInfected == true && isInfectedSound == false)
        {
            isInfectedSound = true;
            infectedBubble.SetActive(true);
            StartCoroutine(playRandomSound());



        }
    }

    IEnumerator playRandomSound()
    {
        yield return new WaitForSeconds(2);
        SoundManager.instance.PlayRandomSoundFXClip(infectedSoundClips, transform, 1f);
    }

}
