using UnityEngine;
using System.Collections;


public class Pccountersystem : MonoBehaviour 
{
    public LPParticleSystem sys;
    PcPartileFilter[] filters;
    void Start()
    {
        if (sys == null)
            sys = FindObjectOfType<LPParticleSystem>();
        StartCoroutine("howmany");    
    }
    IEnumerator howmany()
    {
        while (true)
        {
            filters = GetComponents<PcPartileFilter>();
            yield return new WaitForSeconds(0.1f);
            foreach (PcPartileFilter filter in filters)
            {
                filter.initialise2();
            }
            foreach (LPParticle p in sys.Particles)
            {
                foreach (PcPartileFilter filter in filters)
                {
                   
                    filter.matchFilter(p);
                }
            }
            foreach (PcPartileFilter filter in filters)
            {
                filter.execute();
            }
        }
	}
}
