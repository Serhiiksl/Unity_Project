using UnityEngine;
using UnityEngine.UI;

public class BuySlowMotion : MonoBehaviour
{
    public AudioClip success, fail;
    public GameObject slowmove;
    public Sprite btn, btnPressed;
    public Animation coinsText;
    public Text coinsCount, numslow;
    private Image image;
    public bool isSlowMove;
    public Button btnSlowMove;

    void Start()
    {
        image = GetComponent<Image>();
        // PlayerPrefs.SetInt("NumSlowMove", 0);
        int numslovmthn = PlayerPrefs.GetInt("NumSlowMove");
        if (isSlowMove)
        {
            numslow.text = numslovmthn.ToString();
        }

    }

    public void BuySlowMove(int needCoins)
    {
        int coins = PlayerPrefs.GetInt("Coins");
        int numslovmthn = PlayerPrefs.GetInt("NumSlowMove");
        if (coins < needCoins)
        {
            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = fail;
                GetComponent<AudioSource>().Play();
            }

            coinsText.Play();
        }
        else
        {
            // Buy map
            numslovmthn++;
            PlayerPrefs.SetInt("NumSlowMove", numslovmthn);


            int nowCoins = coins - needCoins;
            coinsCount.text = nowCoins.ToString();
            PlayerPrefs.SetInt("Coins", nowCoins);
            numslow.text = numslovmthn.ToString();

            if (PlayerPrefs.GetString("music") != "No")
            {
                GetComponent<AudioSource>().clip = success;
                GetComponent<AudioSource>().Play();
            }
        }
    }

}
