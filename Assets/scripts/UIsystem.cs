using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guide1;
    public GameObject guide2;
    public GameObject guidebutton;
    public GameObject barphoto;
    public GameObject selectwork;
    public gallarySystem gallarySystem;
    void Start()
    {
        guide1.SetActive(true);
        guidebutton.SetActive(false);
        barphoto.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(){
        guide1.SetActive(false);
        guide2.SetActive(false);
        guidebutton.SetActive(true);
        gallarySystem.statework=0;
    }

    public void next(){
        guide1.SetActive(false);
        guide2.SetActive(true);
        guidebutton.SetActive(false);
    }

    public void guideOpen(){
        guide1.SetActive(true);
        guide2.SetActive(false);
        guidebutton.SetActive(false);
    }

    public void plusbutton(){
        Close();
        guidebutton.SetActive(false);
        barphoto.SetActive(false);
        selectwork.SetActive(true);
    }

    public void takephoto(){
        selectwork.SetActive(false);
        gallarySystem.statework=1;
    }

}
