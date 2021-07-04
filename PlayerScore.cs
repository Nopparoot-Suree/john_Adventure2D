using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public int score;
    public float timeleft = 60;
    public GameObject timeUI;
    public GameObject scoreUI;
    private AudioSource au;
    public AudioClip coinClip;
    void Start()
    {
        au = GetComponent<AudioSource>();
    }


    void Update()
    {
        timeleft -= Time.deltaTime;
        timeUI.gameObject.GetComponent<Text>().text=""+ (int)timeleft;
        scoreUI.gameObject.GetComponent<Text>().text = "" + score;

        if (timeleft <0.1f)
        {
            Destroy(gameObject);
            Application.LoadLevel("Death");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoinA")
        {
            score += 10;
            Destroy(other.gameObject);
            au.clip = coinClip;
            au.Play();
            //get key : value high score
            if (score > PlayerPrefs.GetInt("HightScore",0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
