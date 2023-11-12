using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSececece : MonoBehaviour
{
    public GameObject Player;
    public void OnTriggerEnter(Collider collision)
    {
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadScene("Location_4");
            }
        }
    }
}
