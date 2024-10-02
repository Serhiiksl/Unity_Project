using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design.Serialization;

public class CopyCanvasBtn : MonoBehaviour {
    
    public Sprite btn, btnPressed;
    private Image image;
    public float slow=0.5f, timer=2f, xtime;
    private bool slowmove;
    public Text numslow;
    public static int numslovmthn;
    private AudioSource audioSlowMove;
    public Button btnSlowMove;
    public bool isSlowMove;




        
   
    void Start() {
        image = GetComponent<Image>();
        audioSlowMove = GetComponent<AudioSource>();
        xtime = timer;
        btnSlowMove = GetComponent<Button>();
        numslovmthn=PlayerPrefs.GetInt("NumSlowMove");
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




    }

    public void PlayGame() {
        if(PlayerPrefs.GetString("First Game") == "No")
            StartCoroutine(LoadScene("Game"));
        else 
            StartCoroutine(LoadScene("Study"));
    }

    public void RestartGame() {
        Time.timeScale = 1;
        StartCoroutine(LoadScene("Game"));
    }
    
    public void SetPressedButton() {
        this.image.sprite = btnPressed;
        transform.GetChild(0).localPosition -= new Vector3(0, 5f, 0);
    }
    
    public void SetDefaultButton() {
        this.image.sprite = btn;
        transform.GetChild(0).localPosition += new Vector3(0, 5f, 0);
    }

    IEnumerator LoadScene(string name) {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(1f);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(name);
    }

    public void SlowMotionClick()
    { 
            Time.timeScale = slow;
            Time.fixedDeltaTime = Time.timeScale * 0.015f;
            slowmove = true;
            numslovmthn --;

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
