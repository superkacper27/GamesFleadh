using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionScript : MonoBehaviour
{

    [SerializeField] private AudioSource manTalk;
    [SerializeField] private Animator transAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manTalk.isPlaying == false || Input.GetKeyDown(KeyCode.E))
        {
            transAnim.SetBool("transitionPlay", true);
        }
    }


    void startGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
