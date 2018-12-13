using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour {

    public float bulletSpeed = 5.0f;

    void Start()
    {
        //The +2.4f on the Y axis spawns the bullet at the end of the player arrow, 
        //and the -0.8f Z axis aligns them with the orbs so they can collide.
        transform.Translate(new Vector3(0, 2.4f, -0.8f));
        this.GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
    }
}
