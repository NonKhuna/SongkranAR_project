using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gallarySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer face;
    public RectTransform rectT;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // print(Screen.height);
        print(RectTransformToScreenSpace(rectT));
    }

    public void picImage()
    {
        // StartCoroutine(Loadimage());
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if(path != null){
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if(texture == null) {
                    Debug.Log("Could't load texture from" + path);
                    return;
                }
                texture.Resize(texture.width,texture.width);
                face.material.mainTexture = texture;

            }
        },"select a image","image/*");
    }

    // private IEnumerator Loadimage()
    // {
    //     yield return new WaitForEndOfFrame();
    //     NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
    //     {
    //         if(path != null){
    //             Texture2D texture = NativeGallery.LoadImageAtPath(path);
    //             if(texture == null) {
    //                 Debug.Log("Could't load texture from" + path);
    //                 return;
    //             }
    //             texture.Resize(texture.width,texture.width);
    //             face.material.mainTexture = texture;

    //         }
    //     },"select a image","image/*");
    // }
    public void takePhoto(){
        StartCoroutine( TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();
        Rect realR=RectTransformToScreenSpace(rectT);
        Texture2D ss = new Texture2D( Screen.width, (int)realR.y, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect(0, realR.height,Screen.width,(int)realR.y), 0, 0 );
        // ss.ReadPixels( new Rect(0,0,Screen.width,Screen.height), 0, 0 );
        ss.Apply();
        //
        // Save the screenshot to Gallery/Photos
        Debug.Log( "Permission result: " + NativeGallery.SaveImageToGallery( ss, "GalleryTest", "Image.png" ) );
        
        // To avoid memory leaks
        Destroy( ss );
    }

    public static Rect RectTransformToScreenSpace(RectTransform transform)
     {
         Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
         Rect rect = new Rect(transform.position.x, Screen.height - transform.position.y, size.x, size.y);
         rect.x -= (transform.pivot.x * size.x);
         rect.y -= ((1.0f - transform.pivot.y) * size.y);
         return rect;
     }
    
    // void OnGUI()
    // {  
    //     Rect realR=RectTransformToScreenSpace(rectT);
    //     GUI.Box(new Rect(0,0,Screen.width,(int)realR.y), "here");
    // }
}
