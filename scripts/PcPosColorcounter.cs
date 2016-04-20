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
            float _min = System.Math.Min(System.Math.Min(_Color.r, _Color.g), _Color.b);
            float min = System.Math.Min(System.Math.Min(p._Color.r, p._Color.g), p._Color.b);
            float thetaA, thetaB;
            if (_max - _min < 0.0001||max - min < 0.0001)
            {
                if (particleThreshold==0)
                    ParticleNumber++;
                 return ParticleNumber != 0;
            }
            
            if (_Color.g < _Color.b)
                thetaA = 360.0f - (_max - _Color.r + _Color.g - _min + _Color.b - _min) / (_max - _min) * 60.0f;
            else
                thetaA = (_max - _Color.r + _Color.g - _min + _Color.b - _min) / (_max - _min) * 60.0f;
            if (_Color.g < _Color.b)
                thetaB = 360.0f - (max - p._Color.r + p._Color.g - min + p._Color.b - min) / (max - min) * 60.0f;
            else
                thetaB = (max - p._Color.r + p._Color.g - min + p._Color.b - min) / (max - min) * 60.0f;
            float diffence = Mathf.Abs(thetaA-thetaB);
            if (diffence > 180)
                diffence = 360 - diffence;
            if (diffence < colorTolerance)
                ParticleNumber++;
            else
                Debug.Log(diffence);
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
