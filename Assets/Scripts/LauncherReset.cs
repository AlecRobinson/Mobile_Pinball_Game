using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauncherReset : MonoBehaviour {
    
    [SerializeField] private Button launcher;

    void OnTriggerEnter(Collider other) {       //Checking the pinball has made it into the playable area
        if (other.tag == "Pinball") {
            launcher.enabled = false;
        }
    }
}