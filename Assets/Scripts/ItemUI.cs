using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour{
    [SerializeField] private Image background;
    [SerializeField] private Image image;
    public string nameItem;
    public bool isOccupied = false;

    private void Awake(){
        background.color = Color.black;
        image.color = Color.white;
    }

    public void Occupied(Item item){
        isOccupied = true;
        image.color = Color.yellow;
        nameItem = item.name;
    }
}