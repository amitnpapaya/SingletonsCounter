using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private KeyCode _muteButton;
    [SerializeField] private GameObject _muteIndication;

    private bool _muteOn;
    
    private void Awake()
    {
        _muteIndication.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_muteButton))
        {
            ToggleMute();
        }
    }

    private void ToggleMute()
    {
        _muteOn = !_muteOn;
        _muteIndication.gameObject.SetActive(_muteOn);
    }

    public void PlaySound(AudioClip audioClip)
    {
        if (!_muteOn)
        {
            _audioSource.PlayOneShot(audioClip);   
        }
    }
        
}