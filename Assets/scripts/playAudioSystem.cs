using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sourceAudio ;
    // public AudioClip sound;
    public bool isAvaliable=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // print(sourceAudio.isPlaying);
        if(Input.GetMouseButtonDown(1))
        {
            isAvaliable=!isAvaliable;
            if(isAvaliable){
                sourceAudio.Play();
                print("play ssound");
            }
            else{
                sourceAudio.Pause();
            }
        }
    }

    // public void playAudio(){
    
    // }
}
