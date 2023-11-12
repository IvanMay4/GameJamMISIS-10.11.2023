using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public bool isCollect = false;

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            isCollect = true;
            gameObject.SetActive(false);
        }
    }
}
