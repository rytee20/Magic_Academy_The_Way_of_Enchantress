using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlchemyStrategy : ILearningStrategy
{
    public void Study()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(1, 8);
            sceduleManager.GetPlayer().ReducionEnergyPoints(8);
            Debug.Log("Studying Alchemy");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Practice()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(1, 12);
            sceduleManager.GetPlayer().ReducionEnergyPoints(11);
            Debug.Log("Practicind Alchemy");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Rest()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(1, 3);
            sceduleManager.GetPlayer().IncreaseEnergyPoints(13);
            Debug.Log("Resting Alchemy");
        }
        else Debug.Log("No Game Was Found");
    }

    public SubjectType GetSubjectType()
    {
        return SubjectType.Alchemy;
    }
}
