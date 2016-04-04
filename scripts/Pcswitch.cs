using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pcswitch : MonoBehaviour
{
    protected bool State = false;
    public bool getState()
    {
        return State;
    }
    public void setState(bool t)
    {
        State = t;
    }
  
}

