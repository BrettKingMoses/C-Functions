using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
        public Transform target;
        private NavMeshAgent nav;
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            // if target is not null
            if (target != null)
            {
                nav.SetDestination(target.position);
            }
            //set nav destination to target position
        }
    }
}