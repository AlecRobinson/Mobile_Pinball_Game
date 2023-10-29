using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Death : MonoBehaviour {
    GameObject pinball;
    public int lives = 3;               //Setting up live systems
    [SerializeField] TMP_Text text;
    [SerializeField] Button button;
    private int i = 1;
    GameObject LivesOBJ;
    [SerializeField] private Button launcher;
    [SerializeField] private GameObject particles;

    void OnTriggerEnter(Collider other) {           //Checking a collison has occured with the death box
        if (lives != 0) {
            if (other.tag == "Pinball") {
                pinball = GameObject.Find("Pinball");
                pinball.transform.position = new Vector3(3.4f, -4.5f, 6.9f);        //Putting the pinball back in the launcher
                launcher.enabled = true;                                            //Enabling the launcher
                transform.GetComponent<AudioSource>().Play();                       //Playing a death sound cue
                GameObject clone = Instantiate(particles, transform.position, transform.rotation);      //Making particles
                Destroy(clone, 1f);

                lives -= 1;                                     //Removing one of the players lives
                LivesOBJ = GameObject.Find("Lives" + i);
                i++;                            //Incresing my placeholder variable
                Destroy(LivesOBJ);                  //Removing one of the gameobjects on screen representing the lives
            }
        }
        else {
            text.text = "Your out of pinballs. Final Score was: " + Score.score;    //Final score counter
            Score.score = 0;
            button.gameObject.SetActive(true);          //Allowing the user to press the menu button
        }
    }
}