using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    public GameObject[] BackGround;
    Vector3 pos,Bpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        pos = transform.position;
        Bpos.x = 0;
        Bpos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pos.y = player.transform.position.y + 1.5f;
        transform.position = pos;
        Bpos.y = (int)(pos.y / 10) * 10;
        BackGround[0].transform.position = Bpos;
        Bpos.y = (int)(pos.y / 10 + 1) * 10;
        BackGround[1].transform.position = Bpos;
    }
}
