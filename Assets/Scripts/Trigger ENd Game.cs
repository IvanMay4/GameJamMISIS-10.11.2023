using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerENdGame : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        {
            SceneManager.LoadScene("Main");
            GameObject.Destroy(gameObject);
        }
    }
}
