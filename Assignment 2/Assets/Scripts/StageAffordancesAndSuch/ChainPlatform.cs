using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPlatform : StandingOnPlat
{
    protected override void AdditionalUpdates()
    {
        rigid.MoveRotation(0); //Literally exists for the sole purpose of keeping the chain platform level
    }
}
