using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorWait : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator aim ;
    void update(){
        print("dd");
        if(Input.GetMouseButtonDown(1)){
            print("work");
            aim.SetTrigger("playSong");
        }
        if(aim.GetCurrentAnimatorStateInfo(0).IsName("wait"))
        {
            print("ins");
        }
    }
}
