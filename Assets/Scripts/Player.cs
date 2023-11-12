using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    [SerializeField] public int maxHP = 100;
    private int currentHP = 0;
    [SerializeField] public float speed = 4f;
    [SerializeField] public float jumpSpeed = 4f;
    [SerializeField] public int maxJumps = 1;
    private int currentJumps;
    [SerializeField] private TMP_Text textValueHP;
    [SerializeField] private Scrollbar scrollbarHP;
    [SerializeField] public AudioSource gameMusic;
    [SerializeField] public AudioSource pauseMusic;
    private new Rigidbody rigidbody;
    private GameScene gameScene;
    private Vector3 move;
    [SerializeField] private new Camera camera;
    [SerializeField] private Canvas menuPause;
    [SerializeField] private Canvas inventory;
    [SerializeField] private Canvas dialogMenu;

    private void Awake(){
        SetHP(maxHP);
        currentJumps = maxJumps;
        rigidbody = GetComponent<Rigidbody>();
        if (SceneManager.GetActiveScene().name == "Game"){
            this.AddComponent<GameMainScene>();
            gameScene = GetComponent<GameMainScene>();
            dialogMenu.gameObject.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "DialogTest"){
            this.AddComponent<GameDialogScene>();
            gameScene = GetComponent<GameDialogScene>();
        }
        gameScene.menuPause = menuPause;
<<<<<<< Updated upstream
        inventory.gameObject.SetActive(false);
=======
        gameScene.gameMusic = gameMusic;
        gameScene.pauseMusic = pauseMusic;
>>>>>>> Stashed changes
    }

    public int GetHP() => currentHP;

    private void SetHP(int value){
        currentHP = Math.Min(Math.Max(currentHP + value, 0), maxHP);
        textValueHP.text = Convert.ToString(currentHP) + "/" + Convert.ToString(maxHP);
        scrollbarHP.size += value * 1f / maxHP;
    }

    public void NewHP(int value){
        currentHP = value;
        textValueHP.text = Convert.ToString(currentHP) + "/" + Convert.ToString(maxHP);
        scrollbarHP.size = value * 1f / maxHP;
    }

    public void GetDamage(int valueDamage) => SetHP(-valueDamage);

    public void GetHeal(int valueHeal) => SetHP(valueHeal);

    public int GetCurrentJumps() => currentJumps;

    public void SetCurrentJumps(int countJumps) => currentJumps = countJumps;

    public void IndependentAction(){
        if (Input.GetKeyDown(KeyCode.Escape)) gameScene.SetMenuPause();
    }

    public void Action(){
        IndependentAction();
        if (!gameScene.GetIsPlayGame() || !gameScene.isDialogExit){
            rigidbody.velocity = new Vector3(0, 0, 0);
            return;
        }
        move = new Vector3(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y, Input.GetAxis("Vertical") * speed);
        transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * Time.deltaTime * Settings.rotationSpeed, Input.GetAxis("Mouse X") * Time.deltaTime * Settings.rotationSpeed, 0);
        transform.rotation = Quaternion.Euler(Math.Max(Math.Min(Math.Abs(transform.rotation.eulerAngles.x - 360) < 25f? transform.rotation.eulerAngles.x - 360: transform.rotation.eulerAngles.x, 25f), -10f), transform.rotation.eulerAngles.y, 0);
        if (Input.GetKeyDown(KeyCode.H)) GetHeal(10);
        if (Input.GetKeyDown(KeyCode.Space) && currentJumps > 0){
            currentJumps--;
            move.y = (jumpSpeed - Physics.gravity.y);
        }
        rigidbody.velocity = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0) * move;
        if (Input.GetKeyDown(KeyCode.I)) inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground")) currentJumps = maxJumps;
        if (collision.gameObject.CompareTag("Item"))
            if (CollectItem(collision.gameObject.GetComponent<Item>()))
                Destroy(collision.gameObject);
    }

    public void Continue() => gameScene.HiddenMenuPause();

    public void ExitMainMenu() => Settings.OpenMainMenu();

    public void Save() => Saver.SaveGame(gameScene);

    public bool CollectItem(Item item){
        ItemUI[] items = inventory.GetComponentsInChildren<ItemUI>();
        for(int i = 0;i < items.Length; i++)
            if (!items[i].isOccupied){
                items[i].Occupied(item);
                return true;
            }
        return false;
    }

    public void ChoiceDialogVariant(int number){
        gameScene.GetComponent<GameDialogScene>().ChoiceVariant(number);
        dialogMenu.gameObject.SetActive(false);
    }
}
