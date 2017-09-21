using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Inheritance
{
    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float explosionRadius = 5f;
        public float knockback = 10f;
        protected override void OnAttackEnd()
        {
            Destroy(gameObject);
        }
        protected override void Attack()
        {
            //play animation
            //explosionRadius physics
            Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach(var hit in hits)
            {
                Health h = hit.gameObject.GetComponent<Health>();
                if(h != null)
                {
                    h.TakeDamage(damage);
                }
                Rigidbody r = hit.gameObject.GetComponent<Rigidbody>();
                if(r != null)
                {
                    r.AddExplosionForce(knockback, transform.position, explosionRadius, 0, ForceMode.Impulse);
                }
            }
        }
    }
}