using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    //A player should contain a profile, resources and a base
    public static Player Instance;
    public string Name;
    public TMP_Text NameText;
    public int Resource;
    public TMP_Text ResourceText;

    public Button exitButton;

    public void increaseResource(int value)
    {
        Resource += value;
        ResourceText.text = "Resource: " + Resource;
    }

    private void Awake()
    {
        Instance = this;
        Name = LoginController.loggedPlayer;
        NameText.text = "Name: " + Name;


        LoginController.players.TryGetValue(Name, out Resource);
        ResourceText.text = "Resource: " + Resource;
    }

    void Start() {
        exitButton.onClick.AddListener(Exit);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            increaseResource(5);
        }
    }

    private void Exit() {
        {
            SceneManager.LoadScene(sceneName: "LoginScene");
        }
    }

}
