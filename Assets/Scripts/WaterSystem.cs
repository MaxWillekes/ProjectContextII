using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSystem : ObjectScript, IInteraction
{
    public void ObjectInteraction()
    {
        if (LevelManager.Instance.ui.taskSet1Progression == 0 && LevelManager.Instance.day == 0)
        {
            LevelManager.Instance.ui.UpdateToDo();
        }
    }
}
