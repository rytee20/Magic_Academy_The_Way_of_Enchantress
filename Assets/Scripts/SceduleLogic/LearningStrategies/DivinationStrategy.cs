using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivinationStrategy : ILearningStrategy
{
    public void Study()
    {
        SceduleManager ceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (ceduleManager != null)
        {
            ceduleManager.GetPlayer().SetStudyPoints(2, 7);
            ceduleManager.GetPlayer().ReducionEnergyPoints(5);
            Debug.Log("Studying Divination");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Practice()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(2, 10);
            sceduleManager.GetPlayer().ReducionEnergyPoints(7);
            Debug.Log("Practicind Divination");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Rest()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(2, 5);
            sceduleManager.GetPlayer().IncreaseEnergyPoints(10);
            Debug.Log("Resting Divination");
        }
        else Debug.Log("No Game Was Found");
    }

    public SubjectType GetSubjectType()
    {
        return SubjectType.Divination;
    }
}
