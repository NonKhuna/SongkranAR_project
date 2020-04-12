using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlaim : MonoBehaviour
{
    // Start is called before the first frame update
    public colisionpaticle scriptColi;
    public AudioSource cilp;
    bool before=false,nowPlay=false;
    void Start()
    {
        
    }

    public Animator aim;
    void Update()
    {
        // print("dd");
        if(Input.GetMouseButtonDown(0)){
            // print("work");
            aim.SetTrigger("playSong");
        }
        if(aim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            nowPlay=true;
            if(nowPlay!=before){
                before=nowPlay;
                cilp.Play();
            }
            scriptColi.Play=true;
        }
        else 
        {
            nowPlay=false;
             if(nowPlay!=before){
                before=nowPlay;
                cilp.Pause();
            }
            scriptColi.Play=false;
        }
        
    }
}
