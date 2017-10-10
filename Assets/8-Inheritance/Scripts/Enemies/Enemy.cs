using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Enemy : MonoBehaviour
    {
        public int health = 100;
        public int damage = 25;
        public float attackRate = 5f;
        public float attackRadius = 10f;

        private float attackTimer = 0f;
        void update()
        {
            attackTimer += Time.deltaTime;
            if(attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0f;
            }
        }
        public virtual void Attack()
        {

        }
    }
}