using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Cam;
    public float y_max;
    public float y_min;
    public float x_max;
    public float x_min;
    public GameObject cube;
    public float Inc=0.01f;

    public int modMax=200; 
    int cnt=0;
    private Quaternion target;
    void Start()
    {
        Cam = GameObject.FindWithTag("MainCamera");
        target.x=26.2f;
        target.y=2.3f;     
    }

    // Update is called once per frame
    void Update()
    {
        // cnt++;
        // print(cube.transform.rotation.y);
        if(cube.transform.localRotation.y > y_max){
            Quaternion now=cube.transform.localRotation;
            now.y=y_max-Inc;
            cube.transform.localRotation=Quaternion.Lerp(cube.transform.localRotation,now,Time.deltaTime*10);
        }
        else if(cube.transform.localRotation.y < y_min){
            Quaternion now=cube.transform.localRotation;
            now.y=y_min+Inc;
            cube.transform.localRotation=Quaternion.Lerp(cube.transform.localRotation,now,Time.deltaTime*10);
            // cube.transform.localRotation=now;
        }
        // else {
            // if(cnt>modMax){
            //     Quaternion now=cube.transform.localRotation;
            //     now.x=26.2f;
            //     now.y=2.3f;
            //     cube.transform.localRotation=Quaternion.Lerp(cube.transform.localRotation,now,Time.deltaTime);
            //     if(cnt>1000) cnt=0;
            // }
            else {
                transform.LookAt(Cam.transform,Vector3.up);
            }
        // }

    }
}
