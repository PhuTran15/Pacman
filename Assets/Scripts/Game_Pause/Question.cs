using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public Canvas pauseGame;
    // Start is called before the first frame update
    void Start()
    {
        // pauseGame = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            pauseGame.gameObject.SetActive(true);
        }
        // else{
        //     pauseGame.enabled = false;
        // }
    }
}
