using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWait : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key was pressed");
            gameObject.SetActive(false);
        }
    }

    public void ChangeTime()
    {

        
    }
}