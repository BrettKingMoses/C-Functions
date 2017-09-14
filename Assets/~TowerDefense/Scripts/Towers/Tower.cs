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
                enemies.Add(e);
            }
        }
        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();
            if (e != null)
            {
                enemies.Remove(e);
            }
        }
        Enemy GetClosestEnemy()
        {
            Enemy closest = null;
            float minDistance = float.MaxValue;
            foreach (Enemy enemy in enemies)
            {
                float distance = Vector3.Distance(enemy.transform.position, cannon.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = enemy;
                }
            }
            return closest;
        }
        void Attack()
        {
            Enemy closest = GetClosestEnemy();
            if (closest != null)
            {
                cannon.Fire(closest);
            }
        }
        void Update()
        {
            attackTimer = attackTimer + Time.deltaTime;
            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
    }
}