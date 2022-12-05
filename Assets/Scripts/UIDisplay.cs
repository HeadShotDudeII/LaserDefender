using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    //scoreText;
    [SerializeField] Slider healthBar;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] GameObject playerGB;
    [SerializeField] Health playerHealth;
    //[SerializeField] 
    ScoreKeeper scoreKeeper;
    int startHealth;


    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        startHealth = playerHealth.GetHealth();
    }

    private void Update()
    {
        DisplayHealth();
        DisplayScore();

    }


    public void DisplayHealth()
    {
        healthBar.value = (float)playerHealth.GetHealth() / (float)startHealth;
        //Debug.Log("player health is " + startHealth);
    }

    public void DisplayScore()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");

    }
}
