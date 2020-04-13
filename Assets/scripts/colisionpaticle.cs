using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class colisionpaticle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public ParticleSystem[] particleLauncher;

    [SerializeField]
    public ParticleSystem[] particlePetals;

    [SerializeField]
    private ParticleSystem[] allParsis;
    private int cnt=0;
    private int cntPour=0;
    public int freq=20;
    public int modPetals=20;
    public bool Play=false;
    List<ParticleCollisionEvent> collisionEvent;
    void Start()
    {
        collisionEvent = new List<ParticleCollisionEvent>();
    }
    
    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher[0],other,collisionEvent);
        
        for(int i=0;i<collisionEvent.Count;i++)
        {
            emitAtlocation(collisionEvent[i]);
        }
    }

    void emitAtlocation(ParticleCollisionEvent EventOther){
        print("in");
        foreach(ParticleSystem s in allParsis)
        {
            s.transform.position = EventOther.intersection;
            s.transform.rotation = Quaternion.LookRotation(EventOther.normal);
        }
        cnt++;
        foreach(ParticleSystem s in allParsis)
        {
            if(cnt%freq==0){
                s.Emit(1);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Play){
            cntPour++;
            for(int i=0;i<particleLauncher.Length;i++){
                particleLauncher[i].Emit(1);
            }
            foreach(ParticleSystem Pa in particlePetals){
                if(cntPour%modPetals==0){
                    Pa.Emit(1);
                } 
            }
        }
    }
}

