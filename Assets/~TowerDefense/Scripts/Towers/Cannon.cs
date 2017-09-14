using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class Cannon : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform barrel;
        Vector3 targetPos;
        Vector3 barrelPos;
        Quaternion barrelRot;
        Vector3 fireDirection;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Fire(Enemy targetEnemy)
        {
            targetPos = targetEnemy.transform.position;
            barrelPos = barrel.position;
            barrelRot = barrel.rotation;
            fireDirection = targetPos - barrelPos;
            Cannon.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);
            clone = Instantiate(projectilePrefab, barrelPos, barrelRot);
            Projectile p = GetComponent<Projectile>();
            p.direction = fireDirection;
        }
    }
}