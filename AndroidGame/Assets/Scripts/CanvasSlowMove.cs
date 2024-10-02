using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasSlowMove : MonoBehaviour
{
    public Sprite btn, btnPressed;
    private Image image;
    public float slow = 0.5f, timer = 2f, xtime;
    private bool slowmove;
    public Text numslow;
    public static int numslovmthn;
    private AudioSource audioSlowMove;
    public Button btnSlowMove;
    public bool isSlowMove;






    void Start()
    {
        image = GetComponent<Image>();
        audioSlowMove = GetComponent<AudioSource>();
        xtime = timer;
       // PlayerPrefs.SetInt("NumSlowMove", 0);
        numslovmthn = PlayerPrefs.GetInt("NumSlowMove");
        if (isSlowMove)
        {
            numslow.text = numslovmthn.ToString();
        }
        if (PlayerPrefs.GetInt("NumSlowMove") <= 0)
        {
            btnSlowMove.image.sprite = btnPressed;
            btnSlowMove.enabled = false;

        }
        else
        {
            btnSlowMove.image.sprite = btn;
            btnSlowMove.enabled = true;
        }
    }

    private void Update()
    {
        /* if (slowmove && xtime > 0)
         {
             xtime -= Time.deltaTime;
         }
         else
         {
             slowmove = false;
             xtime = timer;
             Time.timeScale = 1;
         }*/

        if (PlayerPrefs.GetString("First Game") == "No")
        {
            if (PlayerPrefs.GetInt("NumSlowMove") <= 0)
            {
                btnSlowMove.image.sprite = btnPressed;
                btnSlowMove.enabled = false;

            }
            else
            {
                btnSlowMove.image.sprite = btn;
                btnSlowMove.enabled = true;
            }
        }
        else
            numslovmthn = 3;



    }



    public void SetPressedButton()
    {
        btnSlowMove.image.sprite = btnPressed;
    }

    public void SetDefaultButton()
    {
        btnSlowMove.image.sprite = btn;
    }

    public void SlowMotionClick()
    {
        Time.timeScale = slow;
        Time.fixedDeltaTime = Time.timeScale * 0.015f;
        slowmove = true;
        numslovmthn--;

        numslow.text = numslovmthn.ToString();
        audioSlowMove.Play();


        PlayerPrefs.SetInt("NumSlowMove", numslovmthn);
        if (PlayerPrefs.GetInt("NumSlowMove") <= 0)
        {
            btnSlowMove.image.sprite = btnPressed;
            btnSlowMove.enabled = false;

        }


    }
}
