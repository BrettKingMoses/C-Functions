using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arrays
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public Vector3 direction;

        // Use this for initialization
        void Update()
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
