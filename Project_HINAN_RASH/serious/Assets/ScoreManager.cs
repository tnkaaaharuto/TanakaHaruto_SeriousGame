using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] HighScoreData highScore;
    void SetScore(int score)
    {
        switch (highScore.stageNo)
        {
            case 1:
                highScore.stage1 = score; 
                break;
            case 2:
                highScore.stage2 = score;
                break;
            default:
                break;
        }
    }

    int HighScore()
    {
        switch (highScore.stageNo)
        {
            case 1:
                return highScore.stage1;
            case 2:
                return highScore.stage2;
            default:
                return 0;
        }
    }
    public bool HighScore(int score)
    {
        if (score > HighScore())
        {
            SetScore(score);
            GameObject.Find("ScoreSave").GetComponent<ScoreSave>().Scoresave();
            return true;
        }
        return false;
    }

    public int Score(float time,int hit)
    {
        return (int)(time*1000)+(10-hit>0?10-hit:0)*500;
    }
}
