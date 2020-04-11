using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gallarySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer face;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void picImage()
    {
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
}
