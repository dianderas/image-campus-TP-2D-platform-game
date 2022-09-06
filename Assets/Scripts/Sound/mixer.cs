using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class mixer : MonoBehaviour {
    public AudioMixer Mixer;
    public List<AudioClip> Sonidos = new List<AudioClip>();
    public AudioMixerSnapshot Main;
  
    void Start ()
    {
        
    }
	
	
	void Update ()
    {
		
	}
    public AudioClip GetSound(int sound)
    {
        return Sonidos[sound];
    }
}
