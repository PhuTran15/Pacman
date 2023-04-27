using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    public GameManager gm;
    Text show_score;
    // Start is called before the first frame update
    void Start()
    {
        show_score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        show_score.text = "Score: " + this.gm.score;   
    }
}
