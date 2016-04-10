using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class ColorMixing : MonoBehaviour {

    public LPParticleSystem sys;

    void FixedUpdate()
    {
        List<LPSystemPartPartContact> contactslist = sys.GetParticleContacts();
        int[] r = { 255, 0, 255 };
        int[] g = { 100, 0, 255 };
        int[] b = {100,255,100};
        int[] a = { 80, 80, 80 };
        List<int> indicesGreen = new List<int>();
        List<int> indicesPurple = new List<int>();
        List<int> indicesOrange = new List<int>();
        foreach (var contact in contactslist)
        {
            if (contact.ParticleAUserData == 1 && contact.ParticleBUserData == 2)
            {
                if (!indicesPurple.Contains(contact.ParticleAIndex))
                {
                    indicesPurple.Add(contact.ParticleAIndex);
                    indicesPurple.Add(contact.ParticleBIndex);
                }
            }
            else if (contact.ParticleAUserData == 1 && contact.ParticleBUserData == 3)
            {
                if (!indicesOrange.Contains(contact.ParticleAIndex))
                {
                    indicesOrange.Add(contact.ParticleAIndex);
                    indicesOrange.Add(contact.ParticleBIndex);
                }
            }
            else if (contact.ParticleAUserData == 2 && contact.ParticleBUserData == 3)
            {
                if (!indicesGreen.Contains(contact.ParticleAIndex))
                {
                    indicesGreen.Add(contact.ParticleAIndex);
                    indicesGreen.Add(contact.ParticleBIndex);
                }
            }
        }
        if (indicesGreen.Count > 0)
        {
            indicesGreen.Insert(0, indicesGreen.Count);
            LPAPIParticles.SetSelectedParticleColor(sys.GetPtr(), indicesGreen.ToArray(), 100, 255, 100, 133);
            LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(), indicesGreen.ToArray(), 4);
        }
        if (indicesOrange.Count > 0)
        {
            indicesOrange.Insert(0, indicesOrange.Count);
            LPAPIParticles.SetSelectedParticleColor(sys.GetPtr(), indicesOrange.ToArray(), 250, 175, 100, 133);
            LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(), indicesOrange.ToArray(), 4);
        }
        if (indicesPurple.Count > 0)
        {
            indicesPurple.Insert(0, indicesPurple.Count);
            LPAPIParticles.SetSelectedParticleColor(sys.GetPtr(), indicesPurple.ToArray(), 175, 100, 255, 133);
            LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(), indicesPurple.ToArray(), 4);
        }



        for (int i = 1; i < 4; i++)
        {
            List<int> indices = new List<int>();
            foreach (var contact in contactslist)
            {
                if (contact.ParticleAUserData == 0 && contact.ParticleBUserData == i)
                {
                    if (!indices.Contains(contact.ParticleAIndex))
                    {
                        indices.Add(contact.ParticleAIndex);
                    }
                }
            }
            if (indices.Count > 0)
            {
                indices.Insert(0, indices.Count);
                LPAPIParticles.SetSelectedParticleColor(sys.GetPtr(), indices.ToArray(),r[i-1],g[i-1],b[i-1],a[i-1]);
                LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(), indices.ToArray(), i);
            }
        }
        
    }
}
