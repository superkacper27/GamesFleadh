using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile, target;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {

            Debug.Log("Player entered shooting range");

            Vector3 playerPos = collision.transform.position;

            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);	

            bullet.GetComponent<Bullet>().Shoot(playerPos - transform.position);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
