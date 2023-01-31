using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    public ParticleSystem slash_ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playSlash() {
        slash_ps.Play();
    }

    void stopSlash() {
        slash_ps.Stop();
    }
}
