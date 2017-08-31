using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    float recoil = 30;
    float projectileSpeed = 10f;
    float shootRate = 0.1f;
    private float shootTimer = 0f;
    private Rigidbody2D rigid;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        shootTimer += Time.deltaTime;
        //if space bar is pressed and shootTimer is >= shootRate
        if (Input.GetKey(KeyCode.Space) && shootTimer >=shootRate)
        {
        // CALL Shoot
            Shoot();

            // RESET shootTimer
            shootTimer = 0;
        }
    }
    void Shoot()
    {
        // Instantiate GameObject here
        GameObject projectile = Instantiate (projectilePrefab);
        // position of projectile to player's position
        projectile.transform.position = transform.position;
        rigid.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
        Rigidbody2D projectileRigid = projectile.GetComponent<Rigidbody2D>();
        projectileRigid.AddForce(transform.right * projectileSpeed);
    }
}