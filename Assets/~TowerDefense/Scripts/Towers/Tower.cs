using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public Cannon cannon;
        public float attackRate = 0.25f;
        public float attackRadius = 5f;
        private float attackTimer = 0;
        private List<Enemy> enemies = new List<Enemy>();
        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {

            }
        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {

            }
        }
        Enemy GetClosestEnemy()
        {
            Enemy closest = null;
            return closest;
        }
        void Attack()
        {
            GetClosestEnemy();
            if (closest != null)
                {
                Fire();
            }
        }
    }
}