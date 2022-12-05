using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;
    static ScoreKeeper instance;

    private void Awake()
    {
        MangeSingleton();
    }

    private void MangeSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

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
