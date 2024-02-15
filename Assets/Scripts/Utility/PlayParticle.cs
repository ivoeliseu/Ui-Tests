using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleHelper : MonoBehaviour
{
    public ParticleSystem particleToPlay;
    public void PlayParticle()
    {
        particleToPlay.Play();
        Invoke(nameof(StopParticles), .5f);
    }

    public void StopParticles()
    {
        particleToPlay.Stop();
    }
}
