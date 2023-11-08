using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour {
    static PlayerInputManager _instance;

    public static PlayerInputManager Instance {
        get {
            return _instance;
        }
    }
    PlayerControls PlayerControls;

    public Vector2 movementInput;
    private void Awake() {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
        }
        if(PlayerControls == null) {
            PlayerControls = new PlayerControls();
        }
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }
    private void OnEnable() {
        PlayerControls.Enable();
    }

    private void OnDisable() {
        PlayerControls.Disable();
    }
    public Vector2 GetPlayerMovement() {
        return PlayerControls.Player.Movement.ReadValue<Vector2>();
    }

    public bool HasPlayerJumped() {
        return PlayerControls.Player.Jump.triggered;
    }

    private void Update() {
        movementInput = GetPlayerMovement();
        //remove this after testing.
        if(HasPlayerJumped()) {
            Debug.Log("Player has jumped");
        }

    }
    public Vector2 GetPlayerMouse() {
        return PlayerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool GetPlayerInteraction() {
        return PlayerControls.Player.Interaction.triggered;
    }
}


