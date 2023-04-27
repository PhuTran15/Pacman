using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Quit : MonoBehaviour
{
    public Question question;
    public void OutGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        // SceneManager.LoadScene("MenuGame");
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        // pauseGame.enabled = false;

        question.pauseGame.gameObject.SetActive(false);
    }
}
