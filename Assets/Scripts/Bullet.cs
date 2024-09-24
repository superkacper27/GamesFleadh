using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void Shoot(Vector3 pos)
    {
        direction = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        Invoke("Destroyed", 2f);
    }

    void Destroyed()
    {
        Destroy(gameObject);
    }
}
