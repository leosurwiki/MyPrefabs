using UnityEngine;
using System.Collections;

public abstract class PcPartileFilter:MonoBehaviour
{

    // Use this for initialization
    private int particleNumber;
    public abstract bool matchFilter(LPParticle p);
    public int ParticleNumber
    {
        get { return particleNumber; } 
        set { particleNumber = value; } 
    }
    public abstract void initialise2();
    public abstract void execute();
}
