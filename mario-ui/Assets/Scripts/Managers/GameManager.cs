using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private QuestionHandler questionHandler;

    [SerializeField] private TextMeshProUGUI levelNumber;

    [SerializeField] private TextMeshProUGUI txtCoin;

    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set; }

    public int QuestionNumber { get; set; } = 1;

    public int CurrentLevel { get; set; } = 1;

    public BlockHit TargetBlock { get; set; }

    private int coins = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        txtCoin.text = "Coin: " + coins.ToString();
        levelNumber.text = "Level: " + CurrentLevel.ToString();
    }

    //public void NextLevel()
    //{
    //    if (CurrentLevel < 5)
    //    {
    //        CurrentLevel++;
    //        levelNumber.text = "Level: " + CurrentLevel.ToString();
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    }
    //    else
    //    {
    //        WinGame();
    //    }
    //}
    public void NextLevel(int world, int stage)
    {
        if (CurrentLevel < 3)
        {
            CurrentLevel++;
            levelNumber.text = "Level: " + CurrentLevel.ToString();
            this.world = world;
            this.stage = stage;

            SceneManager.LoadScene($"{world}-{stage}");
        }
        else
        {
            WinGame();
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
        Destroy(gameObject);
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOverScene");
        Destroy(gameObject);
    }

    public void AddCoin()
    {
        coins++;
        txtCoin.text = "Coin: " + coins.ToString();
    }

    public void ShowQuestion()
    {
        Time.timeScale = 0f;
        questionHandler.ShowQuestion();
    }

    public void WrongAnswer()
    {
        questionHandler.HideQuestion();
    }

    public void CorrectAnswer()
    {
        QuestionNumber++;
        questionHandler.HideQuestion();
        TargetBlock.Hit();
    }
    // ----------------------------------------
    public void ResetLevel(float delay)
    {
        CancelInvoke(nameof(ResetLevel));
        Invoke(nameof(ResetLevel), delay);
    }
    public void ResetLevel()
    {

        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver1();
        }
    }
    public void NewGame()
    {;
        LoadLevel(1, 1);
    }

    public void GameOver1()
    {
        // TODO: show game over screen
        NewGame();
    }
    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }
}
