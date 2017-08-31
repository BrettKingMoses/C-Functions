using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{


    public class Ball : MonoBehaviour
    {
        public float speed = 10f;
        private Vector3 velocity;

        // Use this for initialization
        void Start()
        {

        }
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }
        public void OnCollisionEnter2D(Collision2D other)
        {
            ContactPoint2D contact = other.contacts[0];
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            velocity = reflect.normalized * velocity.magnitude;
            if (other.gameObject.tag == "Block")
            {
                Debug.Log("Block Destroyed, + 1 point");
                Destroy(other.gameObject);
            }
        }
        // Update is called once per frame
        void Update()
        {
            transform.position += velocity * Time.deltaTime;
        }
    }
}