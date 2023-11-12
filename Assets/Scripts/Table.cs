using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour{
    [SerializeField] private GameObject newTable;
    [SerializeField] private Item item;

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player"))
            if (item.isCollect){
                newTable.SetActive(true);
                Destroy(gameObject);
                FindAnyObjectByType<Player>().NewMaxJumps(1);
            }
    }
}
