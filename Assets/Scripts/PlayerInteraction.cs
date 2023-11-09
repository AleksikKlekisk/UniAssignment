using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour {
    PlayerInputManager inputManager;
    [SerializeField] Camera playerCam;
    [SerializeField] float range = 2f;
    [SerializeField] GameObject key;
    bool isKeyPickedUp = false;
    void Start() {
        inputManager = PlayerInputManager.Instance;
    }


    void Update() {
        //changing the interaction text


        RaycastHit hit;
        //DOOR
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)) {
            Animator doorAnim = hit.collider.transform.root.gameObject.GetComponent<Animator>();
            if (inputManager.GetPlayerInteraction()) {
                
                if (hit.collider.CompareTag("Door") && isKeyPickedUp) {
                    Debug.Log("Yes.it works");
                    doorAnim.SetTrigger("Update");

                }
                else if (hit.collider.CompareTag("Door") && isKeyPickedUp == false) {
                    Debug.Log("need a key");
                }
                //key pickup
                if (hit.collider.CompareTag("Key")) {
                    isKeyPickedUp = true;
                    Destroy(key);
                    Debug.Log("Picked up key");
                    // add key as a UI element


                }
            }
            
        }

    }
}

