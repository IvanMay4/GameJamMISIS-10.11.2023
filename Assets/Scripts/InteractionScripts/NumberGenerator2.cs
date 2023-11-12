using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumberGenerator2 : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        
    }

    public void OnInteract()
    {
        StartCoroutine(SceneLoader());
    }

    IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Coridor");
    }
}