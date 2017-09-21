using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Inheritance
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [Header("Bais Enemy")]
        public Transform target;
        public float damage;
        public float attackDuration;
        public float attackRange;

        protected NavMeshAgent nav;
        protected Rigidbody rigid;

        private float attackTimer = 0f;
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            rigid = GetComponent<Rigidbody>();
        }

        protected virtual void Attack()
        {

        }
        protected virtual void OnAttackEnd()
        {

        }
        IEnumerator AttackDelay(float delay)
        {
            //do this stuff immediately
            nav.Stop();
            yield return new WaitForSeconds(delay);
            nav.Resume();
            OnAttackEnd();
        }
        // Update is called once per frame
        protected virtual void Update()
        {
            nav.SetDestination(target.position);
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= attackRange)
                {
                    StartCoroutine(AttackDelay(attackDuration));
                    Attack();
                    attackTimer = 0f;
                }
            }
        }
    }
}