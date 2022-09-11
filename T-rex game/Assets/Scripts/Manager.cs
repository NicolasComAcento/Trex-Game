using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text GameOvertext;
    public Text scoreText;
    public Text Creditos;
    

    Dino dino;
    Spawn spawn;
    groundMovement GroundMovement;

    bool gameOver = false;
    bool creditos = false;

    float timeToIncreaseDifficulty = 0;
    float interval = 5f; 
    int score;

    public void Play()
    {
        score = 0;
      scoreText.text = score.ToString();
      Time.timeScale = 1f;
      dino.enabled = true;
    }
    void Start() {
        GameOvertext.enabled = false;
        Creditos.enabled = false;

        dino           = FindObjectOfType<Dino>();
        spawn    = FindObjectOfType<Spawn>();
        GroundMovement = FindObjectOfType<groundMovement>();

        timeToIncreaseDifficulty = Time.time + interval;

    }
    void Pause()
    {
       Time.timeScale = 0f;
       dino.enabled = false;
    }

    
    void Update() { 
        
        scoreText.text = score.ToString("D6");
        if (!gameOver) {
            Time.timeScale = 1f;
            dino.enabled = true;
            
            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("Enemy")).Length > 0) {

                gameOver = true;

                spawn.stopSpawn = true;
                Obstacle[] allObstacle = FindObjectsOfType<Obstacle>();
                foreach (Obstacle obj in allObstacle)
                    obj.speed = 0;

            }
            
            if(Time.time >= timeToIncreaseDifficulty) {

                
                spawn.speed     += 0.2f;
                score += 100;
                
                

                timeToIncreaseDifficulty = Time.time + interval;
            }

        } else {
            GameOvertext.enabled = true;
            Creditos.enabled = true;
            Pause();
            if (Input.anyKeyDown) {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void IncreaseScore()
    {
        score += 10;
    }
}