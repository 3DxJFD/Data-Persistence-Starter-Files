using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;
    public TMP_Text bestScore;

    private void Start()
    {
        User.userInstance.LoadPlayerData();
        playerName.text = User.userInstance.userName;
        bestScore.text = "Best Score: " + User.userInstance.MaxName + ": " + User.userInstance.maxPoints;
    }

    private void InputPlayerName(string user)
    {
        User.userInstance.userName = user;

    }

    public void StartNewGame()
    {
        InputPlayerName(playerName.text);
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
                Application.Quit(); // original code to quit Unity player
#endif
    }


}

