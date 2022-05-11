using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip []audioClips;
    
    void Start()
    {
        LevelManager.instance.LevelWin += WinAudio;
        Player.instance.OnPlayerfail += LoseAudio;
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.volume = 0.5f;
        GameAudio();

    }

   void WinAudio()
    {
        audioSource.Stop();
        foreach(AudioClip element in audioClips)
        {
            if(element.name=="Win Screen")
            {
                audioSource.clip = element;
                audioSource.Play();
            }
           
        }
      
    
      
        
      
    }
    void LoseAudio()
    {
        audioSource.Stop();
        foreach (AudioClip element in audioClips)
        {
            if (element.name == "Lose Sound")
            {
                audioSource.clip = element;
                audioSource.Play();
            }

        }

   



    }
    void GameAudio()
    {
        foreach (AudioClip element in audioClips)
        {
            if (element.name == "Videogame Music")
            {
                audioSource.clip = element;
                audioSource.Play();
            }

        }
      

    }
   
    void Update()
    {
        
    }
    private void OnDisable()
    {
        LevelManager.instance.LevelWin -= WinAudio;
        Player.instance.OnPlayerfail -= LoseAudio;
    }
}
