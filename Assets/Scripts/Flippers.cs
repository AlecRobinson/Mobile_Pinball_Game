using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Flippers : MonoBehaviour {
    private GameObject pinball;
    [SerializeField] public float power;
    public Boolean pressed;

    private void Start() {
        pinball = GameObject.Find("Pinball");       //Finding pinball
        power = 700;                                //Setting the initial power for the game
    }
    public void Flipper() {
        StartCoroutine(Flipping());
    }
    public IEnumerator Flipping() {
        transform.GetComponentInParent<Animator>().SetTrigger("UpdateState");   //Playing animation
        pressed = true;                         //Variable to say that the button has been pressed 
        yield return new WaitForSeconds(0.3f);
        pressed = false;
    }
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Pinball" && pressed == true) {     //Checking that a collison between the paddle and pinball has occured
            pinball.GetComponent<Rigidbody>().AddForce(Vector3.up * power);     //Applying upward force to the pinball
            pressed = false;
        }
    }
}
