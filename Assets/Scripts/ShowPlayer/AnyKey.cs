using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnyKey : MonoBehaviour
{
    public GameManager gm;
    Text show_playagain;
    // Start is called before the first frame update
    void Start()
    {
        show_playagain = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gm.lives <= 0 || this.gm.timeout.timeValue >= 90){
            show_playagain.enabled = true;
        }
        else{
            show_playagain.enabled = false;
        }
    }
}
