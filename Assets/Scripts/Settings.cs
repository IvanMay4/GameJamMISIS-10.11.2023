using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public static class Settings{
    public static float volume = 1;
    public static int levelComplexity = 1;
    public static float rotationSpeed = 10f;
    public static bool isLoadGame = false;
    public static string filenameSaveGame = "SaveGame.txt";
    public static string filenameSaveSettings = "SaveSettings.txt";

    public static void OpenMainMenu() => SceneManager.LoadScene("Main");

    public static void OpenSettings() => SceneManager.LoadScene("Settings");

    public static void LoadSettings(){
        Saver.LoadSettings();
        volume = Saver.volume;
        levelComplexity = Saver.levelComplexity;
        rotationSpeed = Saver.rotationSpeed;
    }

    public static void OpenGame() => SceneManager.LoadScene("Game");

    public static void OpenWin() => SceneManager.LoadScene("Win");

    public static void OpenGameOver() => SceneManager.LoadScene("GameOver");

    public static void Exit() => Application.Quit();

    public static void DeleteFile(string filename) => new FileInfo(@$"{filename}").Delete();

    public static void ButtonSetEnabled(Button button){
        if (!button.enabled)
            button.GetComponent<Image>().color = Color.grey;
    }
}
