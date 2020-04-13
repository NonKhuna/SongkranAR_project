using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject guide1;
    public GameObject guide2;
    public GameObject guidebutton;
    void Start()
    {
        guide1.SetActive(true);
        guidebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close(){
        guide1.SetActive(false);
        guide2.SetActive(false);
        guidebutton.SetActive(true);
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
}
