using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour{
    [SerializeField] public Slider sliderVolume;
    [SerializeField] public TMP_Text textValueComplexity;
    [SerializeField] public TMP_InputField inputFieldRotationSpeed;

    private void Start(){
        if (File.Exists(Settings.filenameSaveSettings)) Settings.LoadSettings();
        sliderVolume.value = Settings.volume;
        inputFieldRotationSpeed.text = Settings.rotationSpeed.ToString();
    }

    private void LateUpdate(){
        Settings.volume = sliderVolume.value;
        textValueComplexity.text = Settings.levelComplexity == 1 ? "Ë¸ãêèé" : Settings.levelComplexity == 2 ? "Ñğåäíèé" : Settings.levelComplexity == 3 ? "Òÿæ¸ëûé" : "None";
        textValueComplexity.color = Settings.levelComplexity == 1 ? Color.green : Settings.levelComplexity == 2 ? Color.yellow : Settings.levelComplexity == 3 ? Color.red : Color.white;
        Saver.SaveSettings();
    }

    public void NewRotationSpeed(){
        double tmp = 0f;
        if (!double.TryParse(inputFieldRotationSpeed.text, out tmp)){
            inputFieldRotationSpeed.text = Settings.rotationSpeed.ToString();
            return;
        }
        Settings.rotationSpeed = (float)Convert.ToDouble(inputFieldRotationSpeed.text);
        Saver.SaveSettings();
    }

    public void ComplexityEasy() => Settings.levelComplexity = 1;

    public void ComplexityMedium() => Settings.levelComplexity = 2;

    public void ComplexityHard() => Settings.levelComplexity = 3;

    public void ExitMain() => Settings.OpenMainMenu();
}
