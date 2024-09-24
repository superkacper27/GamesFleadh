using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode key;

    public GameObject hitEffect, greatEffect, perfectEffect, missEffect;


    void Start()
    {
    }
    void Update()
    {
        if (gameObject != null) 
        {
            if (Input.GetKeyDown(key))
            {
                if (canBePressed)
                {
                    gameObject.SetActive(false);

                    //GameManager.instance.NoteHit();

                    if (Mathf.Abs(transform.position.y) > 1)
                    {
                        GameManager.instance.NormalHit();
                        Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                        Debug.Log("Good!");
                    }
                    else if (Mathf.Abs(transform.position.y) > 0.8)
                    {
                        GameManager.instance.GoodHit();
                        Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
                        Debug.Log("Great!");
                    }
                    else
                    {
                        GameManager.instance.PerfectHit();
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                        Debug.Log("Perfect");
                    }
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {

            Debug.Log("TOUCHED THIS BORDER");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(other.tag);
        }

        if (other.tag == "Activator")
        {
            canBePressed = true;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }


}
