using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginController : MonoBehaviour
{
    public TMP_InputField playerName;
    public Button loginButton;
    
    // Start is called before the first frame update
    public static string loggedPlayer;
    public static Dictionary<string, int> players = new Dictionary<string, int>
    {
        {"testname", 1000},
        {"random", 2000}
    };
    void Start()
    {
        loginButton.onClick.AddListener(loginValidation);
        //temp players
        
    }

    public void loginValidation()
    {
        string name = playerName.text;
        
        if (players.ContainsKey(name))
        {
            SceneManager.LoadScene(sceneName: "PlayerTest");
            loggedPlayer = name;
        }
        else
        {
            Debug.Log("Failed Login");
        }
    }

}
