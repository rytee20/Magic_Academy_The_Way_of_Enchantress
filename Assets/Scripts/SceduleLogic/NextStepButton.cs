using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStepButton : MonoBehaviour
{
    public void NextStep()
    {
        Game game = FindObjectOfType<Game>();
        Scedule scedule = FindObjectOfType<Scedule>();
        SceduleManager sceduleManager = FindObjectOfType<SceduleManager>();
        if (scedule != null && sceduleManager!= null)
        {
            scedule.PerformingActivities();
            sceduleManager.GetPlayer().GetAllStudyPoints();
            sceduleManager.CompleteSchedule();
        }
    }
}
