using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    private float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;

    public GameObject Player;
    public Transform spawnPoint;

    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootPlayer();
    }

    void ShootPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;
        Vector3 direction = (player.position - spawnPoint.position).normalized;
        GameObject bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Rigidbody projectile = bullet.GetComponent<Rigidbody>();
        projectile.AddForce((direction) * enemySpeed);
        Destroy(projectile, 2f);
    }
}
