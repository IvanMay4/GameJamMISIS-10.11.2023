using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour{
    [SerializeField] public Button buttonContinue;
    [SerializeField] public Button buttonDeleteProgress;

    private void LateUpdate(){
        buttonContinue.enabled = File.Exists(Settings.filenameSaveGame);
        buttonDeleteProgress.enabled = File.Exists(Settings.filenameSaveGame);
        Settings.ButtonSetEnabled(buttonContinue);
        Settings.ButtonSetEnabled(buttonDeleteProgress);
    }

    public void DeleteProgress() => Settings.DeleteFile(Settings.filenameSaveGame);

    public void EnterSettings() => Settings.OpenSettings();

    public void LoadGame(){
        SceneManager.LoadScene("Location_1");
        Settings.isLoadGame = true;
        Saver.LoadGame();
    }
}
