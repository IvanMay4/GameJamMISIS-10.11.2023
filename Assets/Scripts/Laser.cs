using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{
    [SerializeField] private float minZ = -49;
    [SerializeField] private float maxZ = 49;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int direction = 1;

    private void Update(){
        if (transform.position.z >= maxZ) direction = -1;
        else if (transform.position.z <= minZ) direction = 1;
        transform.position = new Vector3(0, 0, transform.position.z + speed * direction);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Player>().GetDamage(10);
    }
}
