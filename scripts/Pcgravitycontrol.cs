using UnityEngine;
using System.Collections;

public class Pcgravitycontrol : MonoBehaviour {
    [Tooltip("The world with that gravity")]
    public LPManager world;
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        float theta;
        if (Mathf.Abs(Input.acceleration.y) > 0.001)
            theta = Mathf.Atan(Input.acceleration.x / Input.acceleration.y);
        else theta = Mathf.Atan(Input.acceleration.x*100);
        if (theta > Mathf.PI*49 / 100)
            theta = Mathf.PI*49 / 100;
        else if (theta < -Mathf.PI*12 / 25)
            theta = -Mathf.PI*12 / 25;
        LPAPIWorld.SetWorldGravity(world.GetPtr(), -Mathf.Sin(theta) * 7, -Mathf.Cos(theta) * 7);
	}
}
