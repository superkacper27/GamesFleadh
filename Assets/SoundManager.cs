using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXObject;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //asign the audioCliop

        audioSource.clip = audioClip;

        //assign Volume
        audioSource.volume = volume;
        //play sound
        audioSource.Play();
        //get length of sound fx clip
        float length = audioSource.clip.length;
        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, length);
    }

    public void PlayRandomSoundFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        // assign random index

        int rand = Random.Range(0, audioClip.Length);

        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //asign the audioCliop

        audioSource.clip = audioClip[rand];

        //assign Volume
        audioSource.volume = volume;
        //play sound
        audioSource.Play();
        //get length of sound fx clip
        float length = audioSource.clip.length;
        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, length);
    }
}
