using UnityEngine;
using System.Collections;

public class PcSwitchedFixture : MonoBehaviour {
    [Tooltip("The activation")]
    public Pcswitch mypcswitch;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () 
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        LPFixture[] lpfs = GetComponents<LPFixture>();
        if (mypcswitch.getState())
        {
            if (sr.color != Color.gray)
            {
                foreach (LPFixture lpf in lpfs)
                    lpf.Disable();
            }
            sr.color = Color.gray;
        }
	}
}
