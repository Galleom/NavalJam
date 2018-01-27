using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip[] buttonClickSounds;
    public AudioClip loseSound;
    public AudioClip oneFinishedSound;
    public AudioClip winSound;

    private AudioSource source;
    
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

    }
    public void playButtonClickSound(int color, float pitch = 1, float volumeScale = 1)
    {
        source.pitch = pitch;
        source.PlayOneShot(buttonClickSounds[color], volumeScale);
    }
    public void playOneFinishedSound(float pitch = 1, float volumeScale = 1)
    {
        source.pitch = pitch;
        source.PlayOneShot(oneFinishedSound, volumeScale);
    }
    public void playWinSound(float pitch = 1, float volumeScale = 1)
    {
        source.pitch = pitch;
        source.PlayOneShot(winSound, volumeScale);
    }
    public void playLoseSound(float pitch = 1, float volumeScale = 1)
    {
        source.pitch = pitch;
        source.PlayOneShot(loseSound, volumeScale);
    }
    public void playClickSound(float pitch = 1, float volumeScale = 1)
    {
        source.pitch = pitch;
        source.PlayOneShot(clickSound, volumeScale);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
