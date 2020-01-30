using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource ado;
    public AudioSource adoEnemy;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playFX(AudioClip clip)
    {
        ado.clip = clip;
        ado.Play();
    }

    public void playFXonshot(AudioClip clip,float volume)
    {
        ado.PlayOneShot(clip,volume);
    }

    public void playEnemyFX(AudioClip clip)
    {
        adoEnemy.clip = clip;
        adoEnemy.Play();
    }
}
