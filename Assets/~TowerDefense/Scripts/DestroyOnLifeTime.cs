﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLifeTime : MonoBehaviour {
    public float lifeTime = 5f;
	// Use this for initialization
	void Start () {
        //destroy self after lifetime
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
