using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayer : MonoBehaviour
{
    public GameManager gm;
    Text show_level;
    // Start is called before the first frame update
    void Start()
    {
        show_level = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        show_level.text = "Level: " + this.gm.levels;
    }
}
