using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_PlaySound : MonoBehaviour {

    public AudioSource sound;
    public float volume = 1;
    public float pitch = 1;

	void Start () {
        
        sound.Stop();
    }
	
	void Update () {
        sound.volume = volume;
        sound.pitch = pitch;
    }

    public void OnClick()
    {
        sound.Play();
    }
}
