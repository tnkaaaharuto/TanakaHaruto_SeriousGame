using UnityEngine;
using UnityEngine.UI;

public class SoundSet : MonoBehaviour
{
    [SerializeField] SoundData sound;
    GameObject DM;

    private void Start()
    {
        DM = GameObject.Find("DataManager");
        SaveData data = DM.GetComponent<DataManager>().Load();
        GameObject.Find("SE").GetComponent<Slider>().value = data.se/20;
        GameObject.Find("BGM").GetComponent<Slider>().value = data.bgm/20;
    }
    public void Setting()
    {
        sound.se = (byte)(int)(GameObject.Find("SE").GetComponent<Slider>().value*20);
        sound.bgm = (byte)(int)(GameObject.Find("BGM").GetComponent<Slider>().value * 20);
        SaveData data = DM.GetComponent<DataManager>().Load();
        data.se = sound.se;
        data.bgm = sound.bgm;
        DM.GetComponent<DataManager>().Save(data);
    }

    public void Menu()
    {
        GameObject.Find("Sound").GetComponent<Canvas>().enabled = !GameObject.Find("Sound").GetComponent<Canvas>().enabled;
    }

    public void SoundReset()
    {
        GameObject.Find("SE").GetComponent<Slider>().value = 5;
        GameObject.Find("BGM").GetComponent<Slider>().value = 5;
    }
}