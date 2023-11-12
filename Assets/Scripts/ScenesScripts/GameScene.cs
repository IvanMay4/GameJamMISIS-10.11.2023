using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameScene : MonoBehaviour{
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

    public void LoadGame(){
        Player player = GetComponent<Player>();
        player.transform.position = new Vector3((float)Convert.ToDouble(Saver.valuesPlayer[0]), (float)Convert.ToDouble(Saver.valuesPlayer[1]), (float)Convert.ToDouble(Saver.valuesPlayer[2]));
        player.transform.eulerAngles = new Vector3(0, (float)Convert.ToDouble(Saver.valuesPlayer[3]), 0);
        player.SetCurrentJumps(Convert.ToInt32(Saver.valuesPlayer[4]));
        player.NewHP(Convert.ToInt32(Saver.valuesPlayer[5]));
    }

    private void LateUpdate(){
        Player player = GetComponent<Player>();
        player.Action();
        if (Settings.isLoadGame){
            Settings.isLoadGame = false;
            LoadGame();
        }
    }
}
