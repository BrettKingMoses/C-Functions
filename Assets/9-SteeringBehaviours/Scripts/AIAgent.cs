using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public float maxSpeed = 10f;
        public float maxDistance = 10f;

        [HideInInspector]
        public Vector3 velocity;

        private Vector3 force;
        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;
        // list of behaviours (i.e, Seek, Flee, Wander)
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }
        void ComputeForces()
        {
            //set force = vec3.0
            force = new Vector3(0, 0, 0);
            //for i := 0 < behaviours.Count
            for (int i = 0; i < behaviours.Count; i++)
            {
                //let behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i];
                //if behaviour.isactiveandenabled == false
                if (behaviour.isActiveAndEnabled == false)
                {
                    //continue
                    continue;
                }
                //set force = force + behaviour.GetForce() * behaviour.weighting
                force += behaviour.GetForce();
                //if force > maxVelocity
                if (force.magnitude > maxSpeed)
                {
                    force = force.normalized * maxSpeed;
                    break;
                }

                //set force = force.normalised * maxvel
                //break
            }
        }
        void ApplyVelocity()
        {
            //set velocity = velocity + force *deltatime
            velocity = velocity + force * Time.deltaTime;
            //if velocity.magnitude > macvelocity
            if (velocity.magnitude > maxSpeed)
            //set velocity = velocity.normalised
            {
                velocity = velocity.normalized;
            }
            if (velocity.magnitude > 0)
            {
                transform.position = transform.position + velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
            //if velocity.magnitude > 0
            //set transform.position = tran.pos + vel *deltime
            //set tran.rot = quat lookrot (vel)
        }
        void FixedUpdate()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}