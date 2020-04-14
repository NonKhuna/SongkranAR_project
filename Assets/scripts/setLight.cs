using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class setLight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool setFlash=false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CameraDevice.Instance.SetFlashTorchMode(setFlash);

        bool  focusModeSet = CameraDevice.Instance.SetFocusMode(
        CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (!focusModeSet) {
          Debug.Log("Failed to set focus mode(unsupported mode).");
        }
    }

    public void FlashButton()
    {
        setFlash=!setFlash;
    }
}
