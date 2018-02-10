using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMS_InGame : GMS_GameManagerState {

    public override void StateUpdate()
    {
        x++;
        Debug.Log(x);

    }
    int x = 0;
}
