using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = this.GetComponent<AudioSource> ();
	}
	
  //Change "SoundYouWantToPlay" to the method name you want to call from the Animation Event.
	void SoundYouWantToPlay (float volume = 1f) {
    //Change the "SoundFileName" to the sound file name that you want to play that is located in the Assets/Resources folder.
		audio.PlayOneShot ((AudioClip)Resources.Load ("SoundFileName"));
		audio.volume = volume;
	}
	

}
