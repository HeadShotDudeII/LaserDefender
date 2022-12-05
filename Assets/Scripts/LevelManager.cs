using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
