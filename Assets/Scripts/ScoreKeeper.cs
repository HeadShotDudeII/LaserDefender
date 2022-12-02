using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ModifyScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log("Current Score is " + currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
