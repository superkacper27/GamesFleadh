using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{

     public AudioClip destructionSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag == "block")
        {
            //Create a reference to the block
            GameObject block = collision.gameObject;

             AudioSource audioSource = block.GetComponent<AudioSource>();

            // Play the destruction sound if available
            if (audioSource != null && destructionSound != null)
            {
                audioSource.PlayOneShot(destructionSound);
            }


            //Destroy the block after 2 seconds
            Destroy(block, 1f);

            //Debug the destroyed block
            Debug.Log("Block destroyed");

          
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
