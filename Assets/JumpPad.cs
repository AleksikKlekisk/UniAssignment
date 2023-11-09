using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            StartCoroutine(Boost(playerMovement));
        }
    }
    IEnumerator Boost(PlayerMovement playerMovement) {
        playerMovement.isBoosted = true;
        yield return new WaitForSeconds(0.1f);
        playerMovement.isBoosted = false;
    }
}
