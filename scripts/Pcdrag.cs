using UnityEngine;
using System.Collections;

public class Pcdrag : Button
{
    public bool dragable=false;
    void Start()
    {
        if (!dragable)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(Color.cyan,Color.blue,0.2f);
        }
    }
    public void dragged(Vector2 position)
    {
        if (dragable)
        {
            LPJointMouse jm = GetComponent<LPJointMouse>();
            jm.SetTarget(position);
        }
    }
    public bool getOn()
    {
        return On;
    }
    public override Button BeOnClicked()
    {
        On = true;
        return this;
    }

    public override void BeOffClicked()
    {
        On = false;
    }
}