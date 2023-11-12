using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    public AudioSource treeSound;
    public void Interact()
    {
        StartCoroutine(SceneLoader());
    }

    public void OnInteract()
    {
        
    }

    IEnumerator SceneLoader()
    {
        treeSound.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("room_2");
    }
}
