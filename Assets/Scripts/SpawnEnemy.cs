using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour{
    [SerializeField] Enemy enemy;
    [SerializeField] int countEnemy = 0;

    void Start(){
        GameScene gameScene = FindAnyObjectByType<GameScene>();
        if (Settings.isLoadGame) return;
        gameScene.enemies = new Enemy[countEnemy];
        for (int i = 0; i < countEnemy; i++)
            gameScene.enemies[i] = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(0, 50), 1, UnityEngine.Random.Range(0, 50)), new Quaternion());
    }
}
