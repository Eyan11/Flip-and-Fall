using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip respawnSound;
    [SerializeField] private AudioClip portalSound;

    public void PlayWinSound() {
        //load sound into the component and play it
        audioSource.clip = winSound;
        audioSource.Play();
    }

    public void PlayDeathSound() {
        //load sound into the component and play it
        audioSource.clip = deathSound;
        audioSource.Play();
    }

    public void PlayRespawnSound() {
        //load sound into the component and play it
        audioSource.clip = respawnSound;
        audioSource.Play();
    }

    public void PlayPortalSound() {
        //load sound into the component and play it
        audioSource.clip = portalSound;
        audioSource.Play();
    }

}
