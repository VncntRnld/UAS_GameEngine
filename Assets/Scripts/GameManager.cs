using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public TextMeshProUGUI scoreText;
    public CanvasGroup Startgame;
    public CanvasGroup Endgame;


    private int score;

    private void Start()
    {
        board.enabled = false;
        Startgame.interactable = true;
        gameOver.alpha = 0f;
        gameOver.interactable = false;
        Endgame.alpha = 0f;
        Endgame.interactable = false;
    }
    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void NewGame()
    {
        Endgame.alpha = 0f;
        Endgame.interactable = false;
        gameOver.alpha = 0f;
        gameOver.interactable = false;
        SetScore(0);
        TimerDMG.countdown = 11;
        Startgame.alpha = 0f;
        Startgame.interactable = false;      
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;
        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    public void EndGame()
    {
        board.enabled = false;
        Endgame.interactable = true;
        StartCoroutine(Fade(Endgame, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(points);
    }

    private void SetScore(int score)
       
    {
        if (this.score < score)
        {
            this.score = score;
            Data.damage = score;
        }
        else if(score == 0)
        {
            this.score = 0;
            Data.damage = 0;
        }
        else
        {
            return;
        }
        
        scoreText.text = score.ToString();

     //   SaveHiscore();
    }

    //private void SaveHiscore()
    //{
    //  int hiscore = LoadHiscore();

    //      if (score > hiscore) {
    //        PlayerPrefs.SetInt("hiscore", score);
    //  }
    // }

    //   private int LoadHiscore()
    // {
    //   return PlayerPrefs.GetInt("hiscore", 0);
    // }
    private void Update()
    {
        if (EnemyController.isDead)
        {
            GameOver();
        }
        if (PlayerController.isDiee)
        {
            EndGame();
        }
    }
}
