using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class Dialog : MonoBehaviour
{
    public GameObject windowDialog;
    public TextMeshProUGUI textDialog;
    public string[] message;
    public Canvas canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            windowDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
    }

    public void Update() {
        Player player = FindAnyObjectByType<Player>();
        Debug.Log(Math.Abs(Vector3.Distance(transform.position, player.transform.position)));
        if (Math.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 0.6f) {
            canvas.gameObject.SetActive(true);
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer(){
        yield return new WaitForSeconds(3);
        canvas.gameObject.SetActive(false);
    }
}