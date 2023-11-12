using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        StartCoroutine(SceneLoader());
    }

    IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("room_2");
    }
}
