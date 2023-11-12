using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameScene : MonoBehaviour{
    public Enemy[] enemies;
    public Canvas menuPause;
    private bool isPlayGame = true;
    public bool isDialogExit = true;
    public AudioSource gameMusic;
    public AudioSource pauseMusic;

    

    private void Start(){
        Settings.LoadSettings();
    }

    public bool GetIsPlayGame() => isPlayGame;

    public void PlayGame() => isPlayGame = true;

    public void StopGame() => isPlayGame = false;

    public void ShowMenuPause(){
        StopGame();
        gameMusic.Pause();
        pauseMusic.Play();
        menuPause.gameObject.SetActive(true);
    }

    public void HiddenMenuPause(){
        PlayGame();
        gameMusic.UnPause();
        pauseMusic.Stop();
        menuPause.gameObject.SetActive(false);
    }

    public void SetMenuPause(){
        if (menuPause.gameObject.activeSelf) HiddenMenuPause();
        else ShowMenuPause();
    }

    public void DeleteEnemy(int indexEnemy){
        Destroy(enemies[indexEnemy].gameObject);
        Enemy[] newEnemies = new Enemy[enemies.Length - 1];
        for (int i = 0; i < indexEnemy; i++) newEnemies[i] = enemies[i];
        for (int i = indexEnemy + 1; i < enemies.Length; i++) newEnemies[i - 1] = enemies[i];
        enemies = newEnemies;
    }

    public void LoadGame(){
        Player player = GetComponent<Player>();
        player.transform.position = new Vector3((float)Convert.ToDouble(Saver.valuesPlayer[0]), (float)Convert.ToDouble(Saver.valuesPlayer[1]), (float)Convert.ToDouble(Saver.valuesPlayer[2]));
        player.transform.eulerAngles = new Vector3(0, (float)Convert.ToDouble(Saver.valuesPlayer[3]), 0);
        player.SetCurrentJumps(Convert.ToInt32(Saver.valuesPlayer[4]));
        player.NewHP(Convert.ToInt32(Saver.valuesPlayer[5]));
        enemies = new Enemy[Saver.valuesEnemies.Length]; 
        for (int i = 0; i < enemies.Length; i++){
            enemies[i] = Instantiate(Resources.Load("Prefabs/Enemy") as Enemy, new Vector3((float)Convert.ToDouble(Saver.valuesEnemies[i][0]), 1, (float)Convert.ToDouble(Saver.valuesEnemies[i][1])), new Quaternion());
            enemies[i].NewHP(Convert.ToInt32(Saver.valuesEnemies[i][2]));
        }
    }

    private void LateUpdate(){
        Player player = GetComponent<Player>();
        player.Action();
        if (Settings.isLoadGame){
            Settings.isLoadGame = false;
            LoadGame();
        }
        for (int i = 0; i < enemies.Length; i++){
            enemies[i].Action();
            if (enemies[i].GetHP() <= 0) DeleteEnemy(i);
        }
        if (player.GetHP() == 0) Settings.OpenGameOver();
        else if (enemies.Length == 0) Settings.OpenWin();
    }
}
