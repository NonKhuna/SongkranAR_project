﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gallarySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer face;
    public RectTransform rectT;
    public int statework=1;
    public RectTransform center;
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
        PickImage(512);
    }

    private void PickImage( int maxSize )
{
	NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
	{
		Debug.Log( "Image path: " + path );
		if( path != null )
		{
			// Create Texture from selected image
			Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
			if( texture == null )
			{
				Debug.Log( "Couldn't load texture from " + path );
				return;
			}

			// Assign texture to a temporary quad and destroy it after 5 seconds
			// GameObject quad = GameObject.CreatePrimitive( PrimitiveType.Quad );
			// quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
			// quad.transform.forward = Camera.main.transform.forward;
			// quad.transform.localScale = new Vector3( 1f, texture.height / (float) texture.width, 1f );
			
			// Material material = quad.GetComponent<Renderer>().material;
			if( !face.material.shader.isSupported) // happens when Standard shader is not included in the build
				face.material.shader = Shader.Find( "Legacy Shaders/Diffuse" );
            // Texture2D mtexture;
            // Rect realR=RectTransformToScreenSpace(center);
            // Color[] c=mtexture.GetPixel(realR.x,realR.y,);
            // texture.GetPixel()
            face.material.mainTexture = texture;
				
			// Destroy( quad, 5f );

			// If a procedural texture is not destroyed manually, 
			// it will only be freed after a scene change
			Destroy( texture, 5f );
		}
	}, "Select a PNG image", "image/png" );

	Debug.Log( "Permission result: " + permission );
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
