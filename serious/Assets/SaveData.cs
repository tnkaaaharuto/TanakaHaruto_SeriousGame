using UnityEngine;


[System.Serializable]
public class SaveData
{
    public byte se;
    public byte bgm;
    public int stage1;
    public int stage2;
    public SaveData()
    {
        se = 100;
        bgm = 100;
        stage1 = 0;
        stage2 = 0;
    }
}
