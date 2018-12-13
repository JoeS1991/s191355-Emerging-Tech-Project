using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public GameObject myo;
	
	void Update ()
    {

        //The below didn't work how I wanted it to, however it did give me 3D movement of the armband, 
        //but I had to rotate it 90 degrees to have it make any real sense.

        //The armband seems inconsistent in how it handles what direction it thinks it's facing, 
        //even when worn the same way.

            //transform.rotation = Quaternion.LookRotation(myo.transform.forward);

        //This allows me to copy the movement of the arm but only on the Z plane.
        transform.eulerAngles = new Vector3(0, 0, (myo.transform.forward.z * 60));

        //The below if statements can be commented out to allow keyboard control
        //if the Myo is not available/working/for testing without the Myo.
        
        //if (Input.GetKey("q"))
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 45);
        //}

        //else if (Input.GetKey("e"))
        //{
        //    transform.eulerAngles = new Vector3(0, 0, -45);
        //}

        //else
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}
	}
}
