using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureControl : MonoBehaviour {


    //We need a reference to the Myo armband GameObject, rest is set to true in the event of the Myo 
    //armband not being connected/detected so that we don't have a blank player arrow.

    public GameObject myo;
    public GameObject redBullet;
    public GameObject blueBullet;
    public bool rest = true;
    public bool fist = false;
    public bool spread = false;
    private Material arrowMaterial;
    private float timer = 0.0f;

    void Start()
    {
        arrowMaterial = GetComponent<Renderer>().material;
        arrowMaterial.color = Color.black;
    }

    void Update()
    {

        //Having this lets us get the updated position & gesture of the Armband every frame.
        ThalmicMyo myoArmband = myo.GetComponent<ThalmicMyo> ();

        //Decrement the timer in seconds.
        timer -= Time.deltaTime;

        //Simple calls to the API of the Armband to check the current pose.

        //If Rest, we set the arrow colour to black.
        if (myoArmband.pose == Thalmic.Myo.Pose.Rest)
        {
            fist = false;
            spread = false;
            rest = true;
            arrowMaterial.color = Color.black;
            //Debug.Log("Rest");
        }

        //If Fist, we fire red bullets every 0.25s, and change the arrow colour to red.
        else if (myoArmband.pose == Thalmic.Myo.Pose.Fist 
                || Input.GetKey ("r"))
        {
            rest = false;
            spread = false;
            fist = true;
            arrowMaterial.color = Color.red;
            //Debug.Log("Fist");

            if (timer <= 0.0f)
            {
                Object.Instantiate(redBullet, this.transform);
                this.transform.DetachChildren();
                timer = 0.25f;
                //Debug.Log("Shoot Red");
            }
        }

        //Likewise for Spread Fingers, we do the same, but blue.
        else if (myoArmband.pose == Thalmic.Myo.Pose.FingersSpread 
                || Input.GetKey("b"))
        {
            rest = false;
            fist = false;
            spread = true;
            arrowMaterial.color = Color.blue;

            if (timer <= 0.0f)
            {
                Object.Instantiate(blueBullet, this.transform);
                this.transform.DetachChildren();
                timer = 0.25f;
                //Debug.Log("Shoot Blue");
            }

            //Debug.Log("Spread");
        }
	}
}
