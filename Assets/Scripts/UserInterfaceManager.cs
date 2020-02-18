using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    public Text toDoListLine1;
    public Text toDoListLine2;
    public Text toDoListLine3;

    //public Text bedText;

    public Image sleepImage;
    public Image FinalImage;

    public int taskSet1Progression = 0;

    public int eggsFound;

    //public bool showBedText = false;

    private bool bedReady;

    private bool petFed = false;

    public void UpdateToDo()
    {
        switch (LevelManager.Instance.day)
        {
            case 0:
                switch (taskSet1Progression)
                {
                    case 0:
                        toDoListLine1.text = "Check on main water system. - Finished";
                        toDoListLine2.text = "Go to rest.";
                        break;
                    case 1:
                        LevelManager.Instance.NewDay();
                        SetTextForNextDay();
                        break;
                }

                taskSet1Progression++;
                break;
            case 1:

                if( taskSet1Progression == 1 )
                {
                    toDoListLine1.text = "Feed your pet chicken. - Finished";
                    petFed = true;
                }

                toDoListLine2.text = "Find eggs and put them in the basket. Eggs found " + eggsFound + "/2";

                if ( bedReady )
                {
                    LevelManager.Instance.NewDay();
                    SetTextForNextDay();
                }
                else if ( eggsFound == 2 && petFed )
                {
                    toDoListLine3.text = "Go to rest.";
                    bedReady = true;
                }
                break;
            case 2:
                switch (taskSet1Progression)
                {
                    case 0:
                        toDoListLine1.text = "Set climate control system. - Finished";
                        toDoListLine2.text = "Go to rest.";
                        break;
                    case 1:
                        LevelManager.Instance.NewDay();
                        SetTextForNextDay();
                        break;
                }

                taskSet1Progression++;
                break;
        }
    }

    public void SetTextForNextDay()
    {
        switch (LevelManager.Instance.day)
        {
            case 1:
                toDoListLine1.text = "Feed your pet chicken.";
                toDoListLine2.text = "Find eggs and put them in the basket. Eggs found 0/2";
                break;
            case 2:
                toDoListLine1.text = "Set climate control system.";
                toDoListLine2.text = "";
                toDoListLine3.text = "";
                break;
            case 3:
                FinalImage.gameObject.SetActive(true);
                toDoListLine1.text = "Investigate hull disruption";
                toDoListLine2.text = "";
                break;
        }
    }

    public IEnumerator SetNightImage()
    {
        sleepImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        sleepImage.gameObject.SetActive(false);
    }
}