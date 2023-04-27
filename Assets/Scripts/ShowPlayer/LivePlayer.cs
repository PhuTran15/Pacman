using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivePlayer : MonoBehaviour
{
    public GameManager gm;
    Text show_live;
    // Start is called before the first frame update
    void Start()
    {
        show_live = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        show_live.text = "Live: " + this.gm.lives;
    }
}
