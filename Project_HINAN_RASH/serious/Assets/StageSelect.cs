using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] HighScoreData hsdata;
    public void Select(int n)
    {
        switch (n)
        {
            case -2:
                break;
            case -1:
                hsdata.stageNo += 1;
                break;
            case 0:
                SceneManager.LoadScene("title");
                return;
            default:
                hsdata.stageNo = n;
                break;
        }
        if (hsdata.stageNo < -2 || hsdata.stageNo > 2)
        {
            SceneManager.LoadScene("title");
            return;
        }
        SceneManager.LoadScene("Stage1");
    }
}