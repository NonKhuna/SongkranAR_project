using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadimageFromURL : MonoBehaviour
{
    // Start is called before the first frame update
    public string url ="";
    public Renderer ThisRenderer;
    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine());
        ThisRenderer.material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator LoadFromLikeCoroutine()
    {
        print("Loading ....");
        WWW wwwloader= new WWW(url);
        yield return wwwloader;

        print("loaded");
        ThisRenderer.material.color = Color.white;
        ThisRenderer.material.mainTexture = wwwloader.texture;
    }
}
