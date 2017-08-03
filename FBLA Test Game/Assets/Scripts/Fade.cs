using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float fadeInTime; //Fade in time in seconds
    public float fadeOutTime; //Fade out time in seconds
    public bool autoFadeIn; //Determines if the panel should automatically fade in on scene load
    public bool loadingScreenPot;

    private Image fadePanel; //The UI panel GameObject to fade
    private Color currentColor; //The current color component of the panel object

    private bool fading = false; //Determines if the panel is currently fading or not
    private string fade; //Determines if the panel is to fade in or out
    private float fadeRate; //The rate at which the fade occurs
    private string nextLevel; //The level to be loaded after the fade

    private void Awake()
    {
        fadePanel = GetComponent<Image>();
        currentColor = fadePanel.color;
        currentColor.a = 1;
        fadePanel.color = currentColor;
    }

    private void Start()
    {
        if (autoFadeIn)
        {
            fading = true;
            fade = "In";
        }

    }

    private void Update()
    {
        if (fading)
        {
            if (fade == "In")
            {
                if (currentColor.a > 0f)
                {
                    if (currentColor.a - fadeInTime * Time.deltaTime <= 0f)
                    {
                        currentColor.a = 0f;
                        fadePanel.color = currentColor;
                        fading = false;
                        if (loadingScreenPot)
                        {
                            GameObject pot = GameObject.Find("Pot");
                            Transform AwesomePot = pot.transform.GetChild(0);
                            AwesomePot.gameObject.SetActive(true);
                        }
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        currentColor = fadePanel.color;
                        currentColor.a -= Time.deltaTime / fadeInTime;
                        fadePanel.color = currentColor;
                    }
                }

                else
                {
                    fading = false;
                }

            }

            else if (fade == "Out")
            {
                if (currentColor.a < 1)
                {
                    if (currentColor.a + fadeOutTime * Time.deltaTime >= 1)
                    {
                        currentColor.a = 1;
                        fadePanel.color = currentColor;
                        fading = false;
                        LevelManager lev = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                        lev.LoadLevel(nextLevel);
                    }
                    else
                    {
                        currentColor = fadePanel.color;
                        currentColor.a += Time.deltaTime / fadeOutTime;
                        fadePanel.color = currentColor;
                    }
                }

                else
                {
                    fading = false;
                    LevelManager lev = GameObject.Find("LevelManager").GetComponent<LevelManager>();
                    lev.LoadLevel(nextLevel);
                }
            }

            else
            {
                fading = false;
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void FadeIn() //Method to call to start fade in
    {
        fading = true;
        fade = "In";
    }

    public void FadeOut(string scene) //Method to call to start fade out
    {
        gameObject.SetActive(true);
        nextLevel = scene;
        fading = true;
        fade = "Out";
    }
}
