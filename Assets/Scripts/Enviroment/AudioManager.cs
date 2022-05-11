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
        //GameAudio();

    }

   void WinAudio()
    {
        audioSource.PlayOneShot(audioClips[0]);
      
    }
    void LoseAudio()
    {
        audioSource.PlayOneShot(audioClips[1]);
       

    }
    void GameAudio()
    {
        audioSource.PlayOneShot(audioClips[2]);
        
    }
    void GameAudioStop()
    {
        audioSource.Stop();

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
