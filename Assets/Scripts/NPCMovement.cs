using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WayPointCD
{
    // Waypoint we want our NPC to move towards
    public GameObject waypoint;
    // Time to wait in seconds when we get to the waypoint
    public float time;
}
public class NPCMovement : MonoBehaviour
{
    public WayPointCD[] wpPattern;
    private int patternIndex = 0;
    public float speed = 3;
    [SerializeField] private Rigidbody rb;
    private Animator anim;
    public WayPointCD wayPointCD;
    private Vector3 delta;
    // Update is called once per frame

     void Start()
    {
        anim = GetComponent<Animator>();    
    }
    void Update()
    {
        // Process the current instruction in our control data array

        wayPointCD = wpPattern[patternIndex];

        Vector3 wppos = wayPointCD.waypoint.transform.position;

        wppos.y = transform.position.y;


        // Find the range to close vector
        Vector3 rangeToClose = wppos - transform.position;

        // Draw this vector at the position of the enemy
        Debug.DrawRay(transform.position, rangeToClose, Color.cyan);

        // What's our distance to the waypoint?
        float distance = rangeToClose.magnitude;

        // How far do we move each frame
        float speedDelta = speed * Time.deltaTime;

        // If we're close enough to the current waypoint 
        // then increase the pattern index
        if (distance <= speedDelta)
        {
            StartCoroutine(waitToWalk());

            patternIndex++;
            // Reset the patternIndex if we are at the end of the instruction array
            if (patternIndex >= wpPattern.Length)
            {
                patternIndex = 0;
            }

            // Process the current instruction in our control data array
            wayPointCD = wpPattern[patternIndex];

            wppos = wayPointCD.waypoint.transform.position;

            wppos.y = transform.position.y;

            // Find the new range to close vector
            rangeToClose = wppos - transform.position;
        }

        // In what direction is our player?
        Vector3 normalizedRangeToClose = rangeToClose.normalized;

        // Draw this vector at the position of the waypoint
        Debug.DrawRay(transform.position, normalizedRangeToClose, Color.magenta);

        delta = speedDelta * normalizedRangeToClose;

        //delta.y = 0.0f;

        transform.Translate(delta, Space.World);
        


        // ANIMATE NPC


        if (delta.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }



        IEnumerator waitToWalk()
        {
            yield return new WaitForSeconds(wayPointCD.time);
        }
    }
}
