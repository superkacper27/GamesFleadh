using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class infectedSO : ScriptableObject
{
    
    [SerializeField] private float _score;
    [SerializeField] private float _scoreMult;

    public float Score 
    {
        get { return _score; }
        set { _score = value; }
    }

    public float ScoreMultiplier
    {
        get { return _scoreMult; }
        set { _scoreMult = value; }
    }
}
