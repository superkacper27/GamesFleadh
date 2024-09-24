using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer SR;
    public Sprite Unpressed;
    public Sprite Pressed;

    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            SR.sprite = Pressed;
        }

        if(Input.GetKeyUp(key))
        {
            SR.sprite = Unpressed;
        }
    }
}
