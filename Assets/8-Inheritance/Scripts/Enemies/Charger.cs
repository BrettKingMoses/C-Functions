using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float chargeSpeed = 10;
        public float knockback = 5;
        protected override void Attack()
        {
        }
    }
}