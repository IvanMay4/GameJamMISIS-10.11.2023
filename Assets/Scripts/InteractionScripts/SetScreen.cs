using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour
{
    public GameObject uiObject;
    [SerializeField] public float time;

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        yield return new WaitForSeconds(time);
        uiObject.SetActive(false);
    }
}
