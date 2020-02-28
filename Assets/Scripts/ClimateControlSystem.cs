using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateControlSystem : ObjectScript, IInteraction
{
    public void ObjectInteraction()
    {
        if (LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 2)
        {
            LevelManager.Instance.ChangeLighting();
            LevelManager.Instance.ui.UpdateToDo();
        }
    }
}
