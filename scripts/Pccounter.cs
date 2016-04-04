using UnityEngine;
using System.Collections;

public class Pccounter : MonoBehaviour
{
    public Texture2D celeste;
    public Texture2D blue;
    float areaLeftTopX;
    float areaLeftTopY;
    float areaRightBottomX;
    float areaRightBottomY;
    int particles;
    LPManager lpman;

    // Use this for initialization
    void Start()
    {
        lpman = FindObjectOfType<LPManager>();
        StartCoroutine("howmany");
    }

   
    IEnumerator howmany()
    {
        LPFixtureBox box = GetComponent<LPFixtureBox>();
        areaLeftTopX = transform.position.x - box.Size.x / 2-0.1f;
        areaRightBottomX = transform.position.x + box.Size.x / 2 + 0.1f;
        areaRightBottomY = transform.position.y - box.Size.y / 2 - 0.1f;
        areaLeftTopY = transform.position.y + box.Size.y / 2 + 0.1f;
        Debug.Log(areaLeftTopX);
        Debug.Log(areaRightBottomX);
        Debug.Log(areaRightBottomY);
        Debug.Log(areaLeftTopY);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            int count = 0;
            if (lpman.ParticleSystems.Length == 1)
            {
                foreach (LPParticle p in lpman.ParticleSystems[0].Particles)
                {
                    if (p.Position.x > areaLeftTopX && p.Position.x < areaRightBottomX && p.Position.y > areaRightBottomY && p.Position.y < areaLeftTopY)
                        count++;
                }
                //count = lpman.ParticleSystems[0].Particles.Length;
            }
            else if (lpman.ParticleSystems.Length > 1)
            {
                foreach (LPParticleSystem sys in lpman.ParticleSystems)
                {
                    
                }
            }
            particles = count;
           
        }
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width / 20, Screen.height / 2), blue);
        GUI.DrawTexture(new Rect(-Screen.width / 100, -Screen.height/400, Screen.width / 20 + Screen.width / 50, Mathf.Min(Screen.height / 2,Screen.height / 2f / 15f * particles)), celeste);
    }
}