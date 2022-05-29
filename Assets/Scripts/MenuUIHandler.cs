using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text HighScoreText;
    

    private void Start()
    {
        //if (!Director.Instance.highScorePlayerName.Equals(string.Empty))
        if (Director.Instance.highScore > 0)
        {
            HighScoreText.text = "High Score: " + Director.Instance.highScorePlayerName + " : " + Director.Instance.highScore;
            nameInputField.text = Director.Instance.PlayerName;
        }
        else
        {
            HighScoreText.text = "High Score: N/A";
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Director.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    //public void OnNameEntryDone(string playerName)
    //{
    //    Director.Instance.highScorePlayerName = playerName;
    //    Debug.Log("Player name: " + playerName);
    //}

    public void OnNameEntryDone(string someText)
    {
        Director.Instance.PlayerName = nameInputField.text;
    }
}
