using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Dialog : MonoBehaviour
{
    public GameObject windowDialog;
    public TextMeshProUGUI textDialog;
    public string[] message;
    public int numberDialog = 0;
    public Button button;
    public Canvas canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (numberDialog == message.Length - 1)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.gameObject.SetActive(true);
                button.onClick.AddListener(NextDialog);
            }

            windowDialog.SetActive(true);
            textDialog.text = message[numberDialog];
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
        numberDialog = 0;
        button.onClick.RemoveAllListeners();
    }

    public void NextDialog()
    {
        numberDialog++;
        textDialog.text = message[numberDialog];
        if (numberDialog == message.Length - 1)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void Update(){
        Player player = FindAnyObjectByType<Player>();
        Debug.Log(Math.Abs(Vector3.Distance(transform.position, player.transform.position)));
        if (Math.Abs(Vector3.Distance(transform.position, player.transform.position)) < 20f)
            canvas.gameObject.SetActive(true);
    }
}