using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueorNew : MonoBehaviour
{
    public Canvas canvas;
    public GameManager gameManager;
     public void NewGame(){
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        gameManager.LoadPlayer();
        canvas.gameObject.SetActive(false);
    }
}
