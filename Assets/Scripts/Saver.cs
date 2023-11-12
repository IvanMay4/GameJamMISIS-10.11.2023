using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Saver{
    public static float volume;
    public static int levelComplexity;
    public static float rotationSpeed;
    public static string[] valuesPlayer;

    public static void SaveGame(GameScene gameScene){
        StreamWriter writer = new StreamWriter(Settings.filenameSaveGame);
        Player player = gameScene.GetComponentInParent<Player>();
        writer.WriteLine(player.transform.position.x + " " + player.transform.position.y + " " + player.transform.position.z + " " + player.transform.rotation.eulerAngles.y + " " + player.GetCurrentJumps() + " " + player.GetHP());
        writer.Close();
    }

    public static void SaveSettings(){
        StreamWriter writer = new StreamWriter(Settings.filenameSaveSettings);
        writer.WriteLine(Settings.volume + " " + Settings.levelComplexity + " " + Settings.rotationSpeed);
        writer.Close();
    }

    public static void LoadGame() {
        StreamReader reader = new StreamReader(Settings.filenameSaveGame);
        valuesPlayer = reader.ReadLine().Split();
        reader.Close();
    }

    public static void LoadSettings(){
        StreamReader reader = new StreamReader(Settings.filenameSaveSettings);
        string[] valuesSettings = reader.ReadLine().Split();
        volume = (float)Convert.ToDouble(valuesSettings[0]);
        levelComplexity = Convert.ToInt32(valuesSettings[1]);
        rotationSpeed = (float)Convert.ToDouble(valuesSettings[2]);
        reader.Close();
    }
}
