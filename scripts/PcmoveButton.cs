using UnityEngine;
using System.Collections;

public class PcmoveButton : Pcdrag
{
    bool activated = false;
	// Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public override Button BeOnClicked()
    {
        On = true;
        return this;
    }
    

    public override void BeOffClicked()
    {
        On = false;
        activated = !activated;
        LPFixture Mycollider = GetComponent<LPFixture>();
        LPBody Mybody = GetComponent<LPBody>();
        if (activated)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            Mycollider.Disable();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Mycollider.Initialise(Mybody); 
        }
    }
}
