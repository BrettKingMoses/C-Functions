using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{
    public class Seek : SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            Vector3 force = Vector3.zero;
            if (target == null)
            {
                return force;
            }
            desiredForce = target position - transform position;
            return force;
        }
    }
}