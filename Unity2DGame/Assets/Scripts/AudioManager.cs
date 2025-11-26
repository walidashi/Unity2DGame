using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource BGMusic;
    public AudioSource SFX;
    public AudioClip overworldMusic;
    public AudioClip caveMusic;
    public AudioClip[] variousSFX;

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        BGMusic.clip = overworldMusic;
        BGMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusicSFX(AudioClip clip){
        SFX.clip = clip;
        SFX.Play();
    }

    public void PlayMusic(AudioClip clip){
        BGMusic.clip = clip;
        BGMusic.Play();
    }
}
