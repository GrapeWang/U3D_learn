using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManagement : MonoBehaviour
{
    public AudioClip[] Clip = new AudioClip[2];
    public AudioSource ado;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonFXplay(int i)
    {
        ado.clip = Clip[i];
        ado.Play();
    }
}
