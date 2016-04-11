using UnityEngine;
using System.Collections;

public class PcWinCounter : PcPartileFilter{
    public LPFixtureBox box;
    public Texture2D celeste;
    public Texture2D blue;
    //override
    float areaLeftTopX;
    float areaLeftTopY;
    float areaRightBottomX;
    float areaRightBottomY;
    void Start()
    {
        areaLeftTopX = box.transform.position.x - box.Size.x/2 + box.Offset.x-0.01f;
        areaRightBottomX = box.transform.position.x + box.Size.x / 2 + box.Offset.x + 0.01f;
        areaRightBottomY = box.transform.position.y - box.Size.y / 2 + box.Offset.y - 0.01f;
        areaLeftTopY = box.transform.position.y + box.Size.y / 2 + box.Offset.y + 0.01f;
        ParticleNumber = 0;
    }
    override public void initialise2()
    {
        ParticleNumber = 0;
    }
    override public void  execute()
    {
        if (ParticleNumber > 15)
        {
            int nextscene = Application.loadedLevel + 1;
            if (nextscene > Application.levelCount - 1) nextscene = 0;
            Application.LoadLevel(nextscene);
        }
    }
    //override
    override public bool matchFilter(LPParticle p)
    {
        if (p.Position.x > areaLeftTopX && p.Position.x < areaRightBottomX && p.Position.y > areaRightBottomY && p.Position.y < areaLeftTopY)
            ParticleNumber++;
        return ParticleNumber != 0;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width / 20, Screen.height / 2), blue);
        GUI.DrawTexture(new Rect(-Screen.width / 100, -Screen.height / 400, Screen.width / 20 + Screen.width / 50, Mathf.Min(Screen.height / 2, Screen.height / 2f / 15f * ParticleNumber)), celeste);
    }
}
