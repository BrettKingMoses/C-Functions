﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        public float damage = 50f;
        public float speed = 50f;
        public Vector3 direction;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector3 velocity = direction.normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }
        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                e.DealDamage(damage);
                Destroy(gameObject);
            }
            if (col.name == "Ground")
            {
                Destroy(gameObject);
            }
        }
    }
}