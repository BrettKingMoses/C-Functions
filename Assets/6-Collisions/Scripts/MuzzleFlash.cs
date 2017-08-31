using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public int maxFrames = 1;
    private int currentFrames;
    void Update()
    {
        if(currentFrames >= maxFrames)
        {
            Destroy(gameObject);
        }
        currentFrames++;
    }
}
