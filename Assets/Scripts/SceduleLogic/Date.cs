using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date
{
    public void DateWithCharacter(int characterIndex)
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().ChangeRelationshipPoints(5, characterIndex);
            sceduleManager.GetPlayer().IncreaseEnergyPoints(5);
            //Debug.Log("Studying Spellcasting");
        }
        else Debug.Log("No Game Was Found");
    }
}
