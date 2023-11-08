using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Slider sensitivitySlider;
    MouseLook sensitivity;

    //Player prefs, and sensitivity slider
    private void Start() {
        sensitivitySlider = GetComponent<Slider>();
        sensitivity = GetComponent<MouseLook>();
        SetSensitivity(PlayerPrefs.GetFloat("MouseSensitivity", 100));
    }

    public void SetSensitivity(float value) {
        if (value < 1) {
            value = 0.001f;
        }
        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedSensitivity", value);
        sensitivity.mouseSensitivity = (Mathf.Log10(value / 100) * 20f);
        
    }
    public void SetSensitivityFromSlider(float sensitivity) { 
        sensitivitySlider.value = sensitivity;
    }

    public void RefreshSlider(float value) {
        sensitivitySlider.value = value;
    }
    //Scene management and quit button
    public void ChangeScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit() {
        Application.Quit();
    }
}
