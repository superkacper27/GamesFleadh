using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timewait : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 0;
    }

    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("space key was pressed");
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
