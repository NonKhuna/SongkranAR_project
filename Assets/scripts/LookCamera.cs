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
    void Start()
    {
        Cam = GameObject.FindWithTag("MainCamera");       
    }

    // Update is called once per frame
    void Update()
    {
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
        else {
            transform.LookAt(Cam.transform,Vector3.up);
        }

    }
}
