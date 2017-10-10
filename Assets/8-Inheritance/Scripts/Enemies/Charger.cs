using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Charger : MonoBehaviour
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 10f;
        public virtual void Attack()
        {

        }
    }
}