using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject UIevent;
    Rigidbody2D playerRB;
    Vector2 Pos, sPos;
    bool drag=false;
    bool Ctrl = false;
    float unctrltime = 3.0f;
    int hit = 0;
    float time =0f;
    public Sprite[] walks;
    int idx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        playerRB = GetComponent<Rigidbody2D>();
        UIevent = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {   
        
        playerRB.linearVelocity = Vector2.zero;
        if (Input.GetMouseButtonDown(0))
        {
            drag = true;
            sPos = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            UIevent.GetComponent<UIController>().UnVisibleController();
            drag = false;
        }
        unctrltime -=Time.deltaTime;
        if (unctrltime <= 0 && Ctrl)
        {
            if (drag)
            {
                Pos = Input.mousePosition;
                playerRB.AddForce((Pos - sPos)*2);                
                if ((Pos - sPos).magnitude > 20)
                {
                    playerRB.linearVelocity = playerRB.linearVelocity.normalized * 30;
                }
                else
                {
                    playerRB.linearVelocity = playerRB.linearVelocity.normalized * (Pos - sPos).magnitude / 20 * 30;
                }
                    UIevent.GetComponent<UIController>().VisibleController(Pos, sPos);

                time += Time.deltaTime;
                if(time >= 0.2f)
                {
                    GetComponent<SpriteRenderer>().sprite = walks[idx];
                    idx = 1 - idx;
                    time = 0;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            transform.Translate((sPos - Pos).normalized*0.8f);
            unctrltime = 1.0f;
            hit += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIevent.GetComponent<UIController>().StageClear(hit);
        EndGame();
    }
    public void StartGame()
    {
        Ctrl = true;
    }
    public void EndGame()
    {
        Ctrl = false;
        UIevent.GetComponent <UIController>().RestartButton();
    }
}
