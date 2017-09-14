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
        public void Fire(Enemy targetEnemy)
        {
            targetPos = targetEnemy.transform.position;
            barrelPos = barrel.position;
            barrelRot = barrel.rotation;
            fireDirection = targetPos - barrelPos;
            transform.rotation = Quaternion.LookRotation(fireDirection, Vector3.up);
            GameObject clone = Instantiate(projectilePrefab, barrelPos, barrelRot);
            Projectile p = clone.GetComponent<Projectile>();
            p.direction = fireDirection;
        }
    }
}