using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    // Update is called once per frame
    void Update()
    {
        finalScoreText.text = "Your Scored:\n" + scoreKeeper.GetScore().ToString();
    }
}
