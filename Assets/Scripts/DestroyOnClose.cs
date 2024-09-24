using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnClose : MonoBehaviour
{
    [SerializeField] private GameObject game;
    // Start is called before the first frame update
    public void UnloadCurrentScene()
    {
        Destroy(game);
    }
}
