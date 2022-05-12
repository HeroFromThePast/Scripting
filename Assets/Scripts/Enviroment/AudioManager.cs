using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip []audioClips;
    DragAndDrop drag;
    
    
    void Start()
    {
        LevelManager.instance.LevelWin += WinAudio;
        Player.instance.OnPlayerfail += LoseAudio;
        Player.instance.OnCollideSup += SupSound;
        Player.instance.OnLiveChange += DamageSound;
       audioSource = FindObjectOfType<AudioSource>();
        drag = FindObjectOfType<DragAndDrop>();
        drag.OnClickedDone += ClickAudio;
       
        GameAudio();

    }

    void DamageSound()
    {
        foreach (AudioClip element in audioClips)
        {
            if (element.name == "damage")
            {
                //audioSource.clip = element;
                audioSource.PlayOneShot(element);
            }

        }
    }
    public void ClickAudio()
    {
        
        foreach (AudioClip element in audioClips)
        {
            if (element.name == "mouseClick")
            {
                //audioSource.clip = element;
                audioSource.PlayOneShot(element);
            }

        }
    }
    void SupSound()
    {

        foreach (AudioClip element in audioClips)
        {
            if (element.name == "SupSound")
            {
                
                audioSource.PlayOneShot(element);
            }

        }
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
        drag.OnClickedDone -= ClickAudio;
        Player.instance.OnLiveChange -= DamageSound;
    }
}
