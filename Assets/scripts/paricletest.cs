using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paricletest : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Particlelaunch;
    private int cnt=0;
    public int freq=20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            cnt++;
            if(cnt%freq==0){
            Particlelaunch.Emit(1);
            }
        }
    }
}
