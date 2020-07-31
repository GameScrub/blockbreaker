using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] [Range(-.01f, 10f)] private float gameSpeed = 1f;
    [SerializeField] private int score = 0;
    [SerializeField] private int scorePerBlockDestroyed = 234;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private bool isAutoPlayEnabled = false;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);

            // Destroy self if exists
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        DisplayScore();
    }
    
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        score += scorePerBlockDestroyed;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = "Score " + score;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
