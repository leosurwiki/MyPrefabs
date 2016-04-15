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
        areaLeftTopX = box.transform.position.x - box.Size.x / 2 * box.transform.lossyScale.x + box.Offset.x * box.transform.lossyScale.x;
        areaRightBottomX = box.transform.position.x + box.Size.x / 2 * box.transform.lossyScale.x + box.Offset.x * box.transform.lossyScale.x;
        areaRightBottomY = box.transform.position.y - box.Size.y / 2 * box.transform.lossyScale.y + box.Offset.y * box.transform.lossyScale.y;
        areaLeftTopY = box.transform.position.y + box.Size.y / 2 * box.transform.lossyScale.y + box.Offset.y * box.transform.lossyScale.y;
        ParticleNumber = 0;
    }
    public override bool matchFilter(LPParticle p)
    {
        if (p.Position.x > areaLeftTopX && p.Position.x < areaRightBottomX && p.Position.y > areaRightBottomY && p.Position.y < areaLeftTopY)
        {
            float _max = System.Math.Max(System.Math.Max(_Color.r, _Color.g), _Color.b);
            float max = System.Math.Max(System.Math.Max(p._Color.r, p._Color.g), p._Color.b);
            float diffence = System.Math.Abs(_Color.r * 255 / _max - p._Color.r * 255 / max)
                           + System.Math.Abs(_Color.g * 255 / _max - p._Color.g * 255 / max)
                           + System.Math.Abs(_Color.b * 255 / _max - p._Color.b * 255 / max);
            if (diffence < colorTolerance)
                ParticleNumber++;
            else
                Debug.Log(diffence );
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
