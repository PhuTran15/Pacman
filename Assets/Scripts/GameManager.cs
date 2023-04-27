using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public int ghostMultiplier {get; private set;} = 1;
    public Transform pellets;
    public int score { get; private set; }
    public int lives{ get; private set; }

    public int increase_speed;
    public bool tamspeed = false;
    public int levels = 1;
    public Stopwatch timeout;
    public Text bestScore;
    public Pellet pellet;
    private int biendem = 0;
    public float timelive;
    public bool bienRestate = true;

    private void Awake() {
        Time.timeScale = 0;
    }

    private void Start() {
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        NewGame();
    }

    private void NewGame(){
        SetScore(0);
        SetLives(3);
        NewRound();
        this.increase_speed = 0;
        this.levels = 1;
        this.timeout.timeValue = 1;
        this.timeout.time.color = Color.white;
    }

    private void Update(){
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
            bienRestate = true;
        }
        else if (this.timeout.timeValue >= 90){
            GameOver();
            if (Input.anyKeyDown){
                NewGame();
                bienRestate = true;
            }
            
        }

        timelive += Time.deltaTime;

    }

    private void NewRound(){
        this.timeout.timeValue = 1;
        this.timeout.time.color = Color.white;
/////////////
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].ResetState();
        }
/////////////////
        foreach (Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }

        ResetState();
        
    }

    private void ResetState(){
        //     for (int i = 0; i < this.ghosts.Length; i++)
        //     {
        //         this.ghosts[i].ResetState();
        //     }
        
        this.pacman.ResetState();
    }

    private void GameOver(){
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }

    private void SetScore(int score){
        this.score = score;
    }
    private void SetLives(int lives){
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost){
        int points = ghost.points * this.ghostMultiplier;
        SetScore(this.score + points);
        this.ghostMultiplier++;
    }

    public void PacmanEaten(){
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if (this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        }
        else {
            GameOver();
        }
    }
    public void PelletEaten(Pellet pellet){
        pellet.gameObject.SetActive(false);
        SetScore(this.score + pellet.points);
        if (this.score > PlayerPrefs.GetInt("BestScore", 0)){
            PlayerPrefs.SetInt("BestScore", this.score);
            bestScore.text = this.score.ToString();
        }

        if (!HasRemainingPellets()){// Neu khong con thuc an thi doi 3s goi toi man moi
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
            this.increase_speed += 1;
            this.tamspeed = true;
            this.levels += 1;
            bienRestate = true;
            
        }
    }
    public void PowerPelletEaten(PowerPellet pellet){

        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        // TODO: chuyen trang thai cua ghost
    }

    private bool HasRemainingPellets(){
        foreach (Transform pellet in this.pellets){
            if (pellet.gameObject.activeSelf){//kiem tra doi tuong co dang hoat dong
                return true;
            }
        }
        return false;
    }
    private void ResetGhostMultiplier(){
        this.ghostMultiplier = 1;
    }

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer();

        timeout.timeValue = data.timeValue;
        levels = data.levels;
        score = data.score;
        lives = data.lives;
        increase_speed = data.increase_speed;
        tamspeed = data.tamspeed;
        
        foreach (Transform pellet in pellets){
            pellet.gameObject.SetActive(bool.Parse(data.bienBullet[biendem]));
            biendem += 1;
        }

        bienRestate = false;

        ghosts[0].home.enabled = data.enabledHome1;
        ghosts[1].home.enabled = data.enabledHome2;
        ghosts[2].home.enabled = data.enabledHome3;
        ghosts[3].home.enabled = data.enabledHome4;
        ghosts[0].chase.enabled = data.enabledChase1;
        ghosts[1].chase.enabled = data.enabledChase2;
        ghosts[2].chase.enabled = data.enabledChase3;
        ghosts[3].chase.enabled = data.enabledChase4;
        ghosts[0].frightened.enabled = data.enabledFright1;
        ghosts[1].frightened.enabled = data.enabledFright2;
        ghosts[2].frightened.enabled = data.enabledFright3;
        ghosts[3].frightened.enabled = data.enabledFright4;
        ghosts[0].scatter.enabled = data.enabledScatter1;
        ghosts[1].scatter.enabled = data.enabledScatter2;
        ghosts[2].scatter.enabled = data.enabledScatter3;
        ghosts[3].scatter.enabled = data.enabledScatter4;
        ghosts[0].frightened.blue.enabled = data.enabledFrightBlue1;
        ghosts[1].frightened.blue.enabled = data.enabledFrightBlue2;
        ghosts[2].frightened.blue.enabled = data.enabledFrightBlue3;
        ghosts[3].frightened.blue.enabled = data.enabledFrightBlue4;
        ghosts[0].frightened.body.enabled = data.enabledFrightBody1;
        ghosts[1].frightened.body.enabled = data.enabledFrightBody2;
        ghosts[2].frightened.body.enabled = data.enabledFrightBody3;
        ghosts[3].frightened.body.enabled = data.enabledFrightBody4;
        ghosts[0].frightened.eyes.enabled = data.enabledFrightEye1;
        ghosts[1].frightened.eyes.enabled = data.enabledFrightEye2;
        ghosts[2].frightened.eyes.enabled = data.enabledFrightEye3;
        ghosts[3].frightened.eyes.enabled = data.enabledFrightEye4;

        Vector3 positionGhost1;
        positionGhost1.x = 0f;
        positionGhost1.y = 3.5f;
        positionGhost1.z = -1f;
        ghosts[0].transform.position = positionGhost1;

        Vector3 positionGhost2;
        positionGhost2.x = data.positionGhost2[0];
        positionGhost2.y = data.positionGhost2[1];
        positionGhost2.z = data.positionGhost2[2];
        ghosts[1].transform.position = positionGhost2;

        Vector3 positionGhost3;
        positionGhost3.x = data.positionGhost3[0];
        positionGhost3.y = data.positionGhost3[1];
        positionGhost3.z = data.positionGhost3[2];
        ghosts[2].transform.position = positionGhost3;

        Vector3 positionGhost4;
        positionGhost4.x = data.positionGhost4[0];
        positionGhost4.y = data.positionGhost4[1];
        positionGhost4.z = data.positionGhost4[2];
        ghosts[3].transform.position = positionGhost4;

        Vector3 positionPacman;
        positionPacman.x = 0f;
        positionPacman.y = -8.5f;
        positionPacman.z = -5f;
        pacman.transform.position = positionPacman;
    }
}
