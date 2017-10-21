using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource engine;
    public AudioSource fence;
    public AudioSource barrel;
    public AudioSource player;

    public static SoundManager instance;

    // Use this for initialization
    void Awake () {
        instance = this;
    }
	

}
