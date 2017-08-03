using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{

    public List<AudioClip> tracks;
    public List<string> trackNames;
    public bool AutoPlayStartMusic;

    private string currentlyPlayingTrack;

    [SerializeField]
    private AudioSource source;
    static private MusicPlayer instance;


    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    protected virtual void Start()
    {
        if (AutoPlayStartMusic)
        {
            PlayString("Start");
        }
    }

    public void PlayString(string track)
    {
        if (track != currentlyPlayingTrack)
        {
            if (instance != null)
            {
                if (instance.source != null)
                {
                    instance.source.Stop();
                    currentlyPlayingTrack = track;
                    int trackIndex = trackNames.FindIndex(trackString => trackString == track); //Converts the string to a System.Predicate<string>
                    //GameObject nextTrack = instance.tracks[];
                    instance.source.clip = tracks[trackIndex];
                    instance.source.Play();
                }
                else
                {
                    currentlyPlayingTrack = track;
                    int trackIndex = trackNames.FindIndex(trackString => trackString == track); //Converts the string to a System.Predicate<string>
                    //GameObject nextTrack = instance.tracks[];
                    instance.source.clip = tracks[trackIndex];
                    instance.source.Play();
                }
            }
            else
            {
                Debug.LogError("Unavailable MusicPlayer component");
            }
        }

    }
    public void PlayClip(AudioClip clip)
    {
        print("Henlo");
        if (instance != null)
        {
            print("Henlo2");
            if (instance.source != null)
            {
                print("Henlo3");
                instance.source.Stop();
                instance.source.clip = clip;
                instance.source.Play();
            }
            else
            {
                print("Henlo4");
                instance.source.clip = clip;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    public void ChangeVolume(float volume)
    {
        source.volume = volume;
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        foreach (string name in trackNames)
        {
            if (scene.name == name)
            {
                PlayString(name);
            }
        }
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }

}