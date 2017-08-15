using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Arrays
{
    public class Weapon : MonoBehaviour
    {
        public int damage = 10;
        public int maxBullets = 30;
        public float fireInterval = 0.2f;
        public GameObject bulletPrefab;
        public Transform spawnPoint;
        private Transform target;
        private bool isFired = false;
        private int currentBullets = 0;
        private Bullet[] spawnedBullets; //null by default
        // Use this for initialization
        void Start()
        {
            spawnedBullets = new Bullet[maxBullets];
        }

        // Update is called once per frame
        void Update()
        {
            //if !isFired && currentBullets < maxBullets
            if (!isFired && currentBullets < maxBullets) 
            {
                //Fire!
                StartCoroutine(Fire());
            }
        }
        IEnumerator Fire()
        {
            //run whatever is at the top of this function
            isFired = true;
            //spawn a bullet
            SpawnBullet();
            yield return new WaitForSeconds(fireInterval); //wait for fireInterval to finish
            //run whatever is here after fireInterval
            isFired = false;
        }
        void SpawnBullet()
        {
            //1. instantiate a bullet clone
            GameObject clone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            //2 create direction variable for bullet and rotating
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            //3. rotate weapon to direction
            transform.rotation = Quaternion.LookRotation(direction);
            //4. grab bullet script from clone
            Bullet bullet = clone.GetComponent<Bullet>();
            //5 send bullet to target
            bullet.direction = direction;
            //6 store bullet in array
            spawnedBullets[currentBullets] = bullet;
            //7 increment currentBullets
            currentBullets++;
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
