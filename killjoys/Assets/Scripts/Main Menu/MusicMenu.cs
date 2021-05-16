using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{

    public AudioClip lookalive;
    public AudioClip nanana;

    private static MusicMenu instance = null;
    public static MusicMenu Instance
    {
        get { return instance; }
    }

    private AudioSource source;
    private bool playing = false;
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
         source = GetComponent<AudioSource>();

        if (!source.isPlaying)
        {
            source.clip = lookalive;
            PlayMusic();
            
        }
        
    }
    

    public void PlayMusic()
    {
        if (source.isPlaying) return;
        source.Play();
    }

    public void StopMusic()
    {
        source.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = nanana;
            PlayMusic();
            source.loop = true;
        }
    }
}
