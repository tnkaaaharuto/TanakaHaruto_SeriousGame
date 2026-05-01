using UnityEngine;

public class ScoreSave : MonoBehaviour
{
    [SerializeField] HighScoreData scoreData;
    GameObject DM;

    void Start()
    {
        DM = GameObject.Find("DataManager");
        SaveData data = DM.GetComponent<DataManager>().Load();
        scoreData.stage1 = data.stage1;
        scoreData.stage2 = data.stage2;
    }

    public void Scoresave()
    {
        SaveData data = DM.GetComponent<DataManager>().Load();
        data.stage1 = scoreData.stage1;
        data.stage2 = scoreData.stage2;
        DM.GetComponent<DataManager>().Save(data);
    }

    public void ScoreReset()
    {
        scoreData.stage1 = 0;
        scoreData.stage2 = 0;
    }
}
