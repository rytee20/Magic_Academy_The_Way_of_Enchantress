using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellcastingStrategy : ILearningStrategy
{

    public void Study()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(0,7);
            sceduleManager.GetPlayer().ReducionEnergyPoints(10);
            Debug.Log("Studying Spellcasting");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Practice()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(0, 15);
            sceduleManager.GetPlayer().ReducionEnergyPoints(16);
            Debug.Log("Practicing Spellcasting");
        }
        else Debug.Log("No Game Was Found");
    }

    public void Rest()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints(0, 2);
            sceduleManager.GetPlayer().IncreaseEnergyPoints(9);
            Debug.Log("Resting Spellcasting");
        }
        else Debug.Log("No Game Was Found");
    }

    public SubjectType GetSubjectType()
    {
        return SubjectType.Spellcasting;
    }
}
