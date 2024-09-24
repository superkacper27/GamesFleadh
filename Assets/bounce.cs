using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
public Rigidbody rb;
public float str = 0.21f;

public float maxVelocity = 1f;



// Start is called before the first frame update
private void Start()
{
    rb = GetComponent<Rigidbody>();
}

private void OnCollisionEnter(Collision col)
{
    if (col.gameObject.tag == "trampoline")
    {
        rb.AddForce(rb.velocity * str, ForceMode.Impulse);

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }

}
}
