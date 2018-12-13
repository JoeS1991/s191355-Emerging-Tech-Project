using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbColour : MonoBehaviour {

    private Material orbMaterial;
    public float defaultTimer = 4.0f;
    private float Timer;
    private float playerPoints = 0.0f;

    public GameObject redBullet;
    public GameObject blueBullet;

    public Text scoreText = null;
    public Text timerText = null;

    void Start()
    {
        orbMaterial = GetComponent<Renderer>().material;
        Timer = defaultTimer;

        ChangeColour();
    }
	

    //Calls my own ChangeColour function and updates the UI text every frame.
	void Update()
    {
        Timer -= Time.deltaTime;

        ChangeColour();

        if (scoreText != null && timerText != null)
        {
            timerText.text = "Orb changes in: " + Mathf.Round(Timer);
            scoreText.text = "Orb score: " + Mathf.Round(playerPoints);
        } 
	}


    //Handles the player score increasing/decreasing, the destruction of bullets,
    //and each orbs timer changing as the orb score increases/decreases.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Renderer>().material.color == Color.red
            && orbMaterial.color == Color.red)
        {
            Debug.Log("Hit Red");
            playerPoints += 1.0f;
            orbMaterial.color = Color.black;

            var redBullets = GameObject.FindGameObjectsWithTag("RedBullet");

            foreach (var bullet in redBullets)
            {
                Destroy(bullet);
            }
        }
        
        else if (collision.gameObject.GetComponent<Renderer>().material.color == Color.blue
            && orbMaterial.color == Color.blue)
        {
            Debug.Log("Hit Blue");
            playerPoints += 1.0f;
            orbMaterial.color = Color.black;

            var blueBullets = GameObject.FindGameObjectsWithTag("BlueBullet");

            foreach (var bullet in blueBullets)
            {
                Destroy(bullet);
            }
        }

        else
        {
            Debug.Log("Miss");
            playerPoints -= 1.0f;
            Destroy(collision.gameObject);
        }

        //We don't want the timer to drop below 2 seconds, as it becomes unmanagable.
        //2 seconds presents a fair challenge.
        if (defaultTimer >= 2.1f)
        {
            defaultTimer = 4.0f - (playerPoints / 10.0f);
            Debug.Log(defaultTimer.ToString());
        }
    }

    //This handles the changing of the orbs colours every 'Timer' seconds (set to 4.0f as of writing).
    //There is a 40% chance of a black orb, and 30% each for Red and Blue orbs.

    void ChangeColour()
    {
        if (Timer <= 0)
        {
            float ranFloat = Random.Range(0.0f, 1.0f);

            if (ranFloat <= 0.30f)
            {
                orbMaterial.color = Color.blue;
            }

            else if (ranFloat > 0.30f & ranFloat <= 0.60f)
            {
                orbMaterial.color = Color.red;
            }

            else
            {
                orbMaterial.color = Color.black;
            }

            Timer = defaultTimer;
        }
    }
}
