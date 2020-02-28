using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : ObjectScript, IInteraction
{
    public void ObjectInteraction()
    {
        if (LevelManager.Instance.ui.taskSet1Progression == 1 && LevelManager.Instance.day == 0)
        {
            LevelManager.Instance.ui.UpdateToDo();
            LevelManager.Instance.ui.taskSet1Progression = 0;
        }
        else if (LevelManager.Instance.ui.eggsFound == 2 && LevelManager.Instance.day == 1)
        {
            LevelManager.Instance.ui.UpdateToDo();
        }
        else if (LevelManager.Instance.ui.taskSet1Progression == 1 && LevelManager.Instance.day == 2)
        {
            LevelManager.Instance.ui.UpdateToDo();
        }
    }
}
