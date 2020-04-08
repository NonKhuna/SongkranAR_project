using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlaim : MonoBehaviour
{
    // Start is called before the first frame update
    public colisionpaticle scriptColi;
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
            scriptColi.Play=true;
        }
        else 
        {
            scriptColi.Play=false;
        }
        
    }
}
