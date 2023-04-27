using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int levels;
    public int score;
    public int lives;
    public int increase_speed;
    public bool tamspeed = false;
    public float timeValue;
    public string[] bienBullet = new string[400];
    private int biendem = 0;

    public bool enabledHome1;
    public bool enabledHome2;
    public bool enabledHome3;
    public bool enabledHome4;

    public bool enabledChase1;
    public bool enabledChase2;
    public bool enabledChase3;
    public bool enabledChase4;

    public bool enabledFright1;
    public bool enabledFright2;
    public bool enabledFright3;
    public bool enabledFright4;
    public bool enabledFrightBlue1;
    public bool enabledFrightBlue2;
    public bool enabledFrightBlue3;
    public bool enabledFrightBlue4;
    public bool enabledFrightBody1;
    public bool enabledFrightBody2;
    public bool enabledFrightBody3;
    public bool enabledFrightBody4;
    public bool enabledFrightEye1;
    public bool enabledFrightEye2;
    public bool enabledFrightEye3;
    public bool enabledFrightEye4;

    public bool enabledScatter1;
    public bool enabledScatter2;
    public bool enabledScatter3;
    public bool enabledScatter4;

    public float[] positionGhost1;
    public float[] positionGhost2;
    public float[] positionGhost3;
    public float[] positionGhost4;
    public float[] positionPacman;

    public float durationGhostHome1;
    public float durationGhostHome2;
    public float durationGhostHome3;
    public float durationGhostHome4;

    public float durationGhostChase1;
    public float durationGhostChase2;
    public float durationGhostChase3;
    public float durationGhostChase4;

    public float durationGhostFright1;
    public float durationGhostFright2;
    public float durationGhostFright3;
    public float durationGhostFright4;

    public float durationGhostScatter1;
    public float durationGhostScatter2;
    public float durationGhostScatter3;
    public float durationGhostScatter4;

    public PlayerData (GameManager gameManager){

        timeValue = gameManager.timeout.timeValue;
        levels = gameManager.levels;
        score = gameManager.score;
        lives = gameManager.lives;
        increase_speed = gameManager.increase_speed;
        tamspeed = gameManager.tamspeed;
        foreach (Transform pellet in gameManager.pellets){
            bienBullet[biendem] = pellet.gameObject.activeSelf.ToString();
            biendem += 1;
        }

        enabledHome1 = gameManager.ghosts[0].home.enabled;
        enabledHome2 = gameManager.ghosts[1].home.enabled;
        enabledHome3 = gameManager.ghosts[2].home.enabled;
        enabledHome4 = gameManager.ghosts[3].home.enabled;
        enabledChase1 = gameManager.ghosts[0].chase.enabled;
        enabledChase2 = gameManager.ghosts[1].chase.enabled;
        enabledChase3 = gameManager.ghosts[2].chase.enabled;
        enabledChase4 = gameManager.ghosts[3].chase.enabled;
        enabledFright1 = gameManager.ghosts[0].frightened.enabled;
        enabledFright2 = gameManager.ghosts[1].frightened.enabled;
        enabledFright3 = gameManager.ghosts[2].frightened.enabled;
        enabledFright4 = gameManager.ghosts[3].frightened.enabled;
        enabledScatter1 = gameManager.ghosts[0].scatter.enabled;
        enabledScatter2 = gameManager.ghosts[1].scatter.enabled;
        enabledScatter3 = gameManager.ghosts[2].scatter.enabled;
        enabledScatter4 = gameManager.ghosts[3].scatter.enabled;
        enabledFrightBlue1 = gameManager.ghosts[0].frightened.blue.enabled;
        enabledFrightBlue2 = gameManager.ghosts[1].frightened.blue.enabled;
        enabledFrightBlue3 = gameManager.ghosts[2].frightened.blue.enabled;
        enabledFrightBlue4 = gameManager.ghosts[3].frightened.blue.enabled;
        enabledFrightBody1 = gameManager.ghosts[0].frightened.body.enabled;
        enabledFrightBody2 = gameManager.ghosts[1].frightened.body.enabled;
        enabledFrightBody3 = gameManager.ghosts[2].frightened.body.enabled;
        enabledFrightBody4 = gameManager.ghosts[3].frightened.body.enabled;
        enabledFrightEye1 = gameManager.ghosts[0].frightened.eyes.enabled;
        enabledFrightEye2 = gameManager.ghosts[1].frightened.eyes.enabled;
        enabledFrightEye3 = gameManager.ghosts[2].frightened.eyes.enabled;
        enabledFrightEye4 = gameManager.ghosts[3].frightened.eyes.enabled;

        durationGhostHome1 = gameManager.ghosts[0].home.timeliveHome;
        durationGhostHome2 = gameManager.ghosts[1].home.timeliveHome;
        durationGhostHome3 = gameManager.ghosts[2].home.timeliveHome;
        durationGhostHome4 = gameManager.ghosts[3].home.timeliveHome;

        durationGhostChase1 = gameManager.ghosts[0].chase.timeliveChase;
        durationGhostChase2 = gameManager.ghosts[1].chase.timeliveChase;
        durationGhostChase3 = gameManager.ghosts[2].chase.timeliveChase;
        durationGhostChase4 = gameManager.ghosts[3].chase.timeliveChase;

        durationGhostFright1 = gameManager.ghosts[0].frightened.timeliveFrightended;
        durationGhostFright2 = gameManager.ghosts[1].frightened.timeliveFrightended;
        durationGhostFright3 = gameManager.ghosts[2].frightened.timeliveFrightended;
        durationGhostFright4 = gameManager.ghosts[3].frightened.timeliveFrightended;

        durationGhostScatter1 = gameManager.ghosts[0].scatter.timeliveScatter;
        durationGhostScatter2 = gameManager.ghosts[1].scatter.timeliveScatter;
        durationGhostScatter3 = gameManager.ghosts[2].scatter.timeliveScatter;
        durationGhostScatter4 = gameManager.ghosts[3].scatter.timeliveScatter;

        positionGhost1 = new float[3];
        positionGhost1[0] = gameManager.ghosts[0].transform.position.x;
        positionGhost1[1] = gameManager.ghosts[0].transform.position.y;
        positionGhost1[2] = gameManager.ghosts[0].transform.position.z;

        positionGhost2 = new float[3];
        positionGhost2[0] = gameManager.ghosts[1].transform.position.x;
        positionGhost2[1] = gameManager.ghosts[1].transform.position.y;
        positionGhost2[2] = gameManager.ghosts[1].transform.position.z;

        positionGhost3 = new float[3];
        positionGhost3[0] = gameManager.ghosts[2].transform.position.x;
        positionGhost3[1] = gameManager.ghosts[2].transform.position.y;
        positionGhost3[2] = gameManager.ghosts[2].transform.position.z;

        positionGhost4 = new float[3];
        positionGhost4[0] = gameManager.ghosts[3].transform.position.x;
        positionGhost4[1] = gameManager.ghosts[3].transform.position.y;
        positionGhost4[2] = gameManager.ghosts[3].transform.position.z;

        positionPacman = new float[3];
        positionPacman[0] = gameManager.pacman.transform.position.x;
        positionPacman[1] = gameManager.pacman.transform.position.y;
        positionPacman[2] = gameManager.pacman.transform.position.z;

    }
}
