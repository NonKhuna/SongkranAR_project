using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFace : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Texture2D[] faceEmoji;
    public MeshRenderer face;
    public int time =100;
    int cnt =0;
    public bool Isactivate=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Isactivate){
            cnt++;
            if(cnt%time==0){
                int index = Random.Range(0,(faceEmoji.Length)-1);
                face.material.mainTexture=faceEmoji[index];
            }
        }
    }
}
