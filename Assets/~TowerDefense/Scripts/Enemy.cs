using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
}