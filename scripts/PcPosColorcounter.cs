using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PcPosColorcounter : PcPartileFilter
{
	// Update is called once per frame
    Color _Color = LPColors.DefaultParticleCol;
    public SpriteRenderer gem;
    public float colorTolerance;
    public LPFixtureBox box;
    public Pcswitch mySwitch;
    public int particleThreshold = 0;
    //override
    float areaLeftTopX;
    float areaLeftTopY;
    float areaRightBottomX;
    float areaRightBottomY;
    void Start()
    {
        _Color = gem.color;
        areaLeftTopX = box.transform.position.x + box.Offset.x;
        areaRightBottomX = box.transform.position.x + box.Size.x  + box.Offset.x;
        areaRightBottomY = box.transform.position.y + box.Offset.y;
        areaLeftTopY = box.transform.position.y + box.Size.y + box.Offset.y;
        ParticleNumber = 0;
    }
    public override bool matchFilter(LPParticle p)
    {
        if (p.Position.x > areaLeftTopX && p.Position.x < areaRightBottomX && p.Position.y > areaRightBottomY && p.Position.y < areaLeftTopY)
        {
            float diffence = System.Math.Abs(_Color.a - p._Color.a) + System.Math.Abs(_Color.g - p._Color.g) + System.Math.Abs(_Color.b - p._Color.b);
            if (diffence<colorTolerance)
                ParticleNumber++;
        }
        return ParticleNumber != 0;
    }

    public override void initialise2()
    {
        this.ParticleNumber = 0;
    }

    public override void execute()
    {
        mySwitch.setState(ParticleNumber >= particleThreshold);
    }
}
