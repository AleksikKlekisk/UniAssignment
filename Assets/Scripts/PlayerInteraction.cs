using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    PlayerInputManager inputManager;
    [SerializeField] Camera playerCam;
    [SerializeField] float range = 2f;
    void Start()
    {
        inputManager = PlayerInputManager.Instance;
        
    }

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range)) {
            //Debug.Log(hit.transform.name);
            Animator doorAnim = hit.collider.transform.root.gameObject.GetComponent<Animator>();
            if (hit.collider.CompareTag("Door") &&  Input.GetKeyDown(KeyCode.F)) {
                Debug.Log("Yes.it works");
                doorAnim.SetTrigger("Update");
            }
        }
    }
    
}

