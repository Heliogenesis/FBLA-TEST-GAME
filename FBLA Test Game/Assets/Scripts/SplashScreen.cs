using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public AudioClip LoadingJingle;
    public float loadTime = 2.5f;
    private Fade fade;

    private void Start()
    {
        if (LoadingJingle)
        {
            AudioSource.PlayClipAtPoint(LoadingJingle, transform.position);
        }
        fade = GameObject.Find("Fade").GetComponent<Fade>();
    }

    private void Update()
    {
        loadTime -= Time.deltaTime;
        if (loadTime <= 0f)
        {
            fade.FadeOut("01_Menu");
        }
    }
}
