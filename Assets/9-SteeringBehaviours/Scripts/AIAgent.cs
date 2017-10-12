using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public Vector3 force; // total force calculated from behaviours
        public Vector3 velocity; // direction of travel and speed
        public float maxVelocity = 100f; // max amount of velocity
        public float maxDistance = 10f;
        public bool freezeRotation = false; // freeze roatation?

        private NavMeshAgent nav;
        private List<SteeringBehaviour> behaviours;
        // list of behaviours (i.e, Seek, Flee, Wander)
        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        void Start()
        {
            behaviours = new List<SteeringBehaviour>(GetComponents<SteeringBehaviour>());
        }
        void ComputeForces()
        {
            //set force = vec3.0
            force = Vector3.0;
            //for i := 0 < behaviours.Count
            for (int i = 0; i < behaviours.Count; ++i)
            {
                //let behaviour = behaviours[i]
                SteeringBehaviour behaviour = behaviours[i];
                //if behaviour.isactiveandenabled == false
                    if(Behaviour.isActiveAndEnabled == false)
                {
                    //continue
                    continue;
                }
                    //set force = force + behaviour.GetForce() * behaviour.weighting
                    //if force > maxVelocity
                    //set force = force.normalised * maxvel
                    //break
            }
        }
        void ApplyVelocity()
        {

        }
        void FixedUpdate()
        {
            ComputeForces();
            ApplyVelocity();
        }
    }
}