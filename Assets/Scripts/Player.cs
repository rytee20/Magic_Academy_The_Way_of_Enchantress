using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    private string playerName;

    private int energyPoints;
    private int divinationPoints;
    private int alchemyPoints;
    private int spellcastingPoints;

    private int dandalionPoints;
    private int magnusPoints;

    public Player()
    {
        energyPoints = 100;
        divinationPoints = 0;
        spellcastingPoints = 0;
        alchemyPoints = 0;
    }

    public void IncreaseEnergyPoints(int plusPoints)
    {
        energyPoints += plusPoints;
        if (energyPoints > 100) 
            energyPoints = 100;
    }

    public void ReducionEnergyPoints(int minusplusPoints)
    {
        energyPoints -= minusplusPoints;
    }

    public int GetEnergyPoints()
    {
        return energyPoints;
    }

    public void ChangeRelationshipPoints(int points, int character)
    {
        //Debug.Log(character);
        switch (character)
        {
            case 0:
                dandalionPoints += points;
                break;
            case 1:
                magnusPoints += points;
                break;
            default:
                throw new ArgumentException("Unknown character");
        }
    }

    public int GetDandalionPoints()
    {
        return dandalionPoints;
    }

    public int GetMagnusPoints()
    {
        return magnusPoints;
    }

    public void SetStudyPoints(int activityIndex, int plusPoints)
    {
        switch ((SubjectType)activityIndex)
        {
            case SubjectType.Spellcasting:
                spellcastingPoints += plusPoints;
                break;
            case SubjectType.Alchemy:
                alchemyPoints += plusPoints;
                break;
            case SubjectType.Divination:
                divinationPoints += plusPoints;
                break;
            default:
                throw new ArgumentException("Unknown subject type");
        }
    }

    public int GetStudyPoints(int activityIndex)
    {
        switch ((SubjectType)activityIndex)
        {
            case SubjectType.Spellcasting:
                return spellcastingPoints;
            case SubjectType.Alchemy:
                return alchemyPoints;
            case SubjectType.Divination:
                return divinationPoints;
            default:
                throw new ArgumentException("Unknown subject type");
        }
    }

    public string GetAllStudyPoints()
    {
        //Debug.Log("spellcastingPoints " + spellcastingPoints + "\nalchemyPoints " + alchemyPoints + "\ndivinationPoints " + divinationPoints);
        return "Опыт Чар: " + spellcastingPoints.ToString() + 
            "\nОпыт Алхимии: " + alchemyPoints.ToString() + 
            "\nОпыт Предсказаний: " + divinationPoints.ToString();
    }

    public string GetAllRelationsPoints()
    {
        //Debug.Log("spellcastingPoints " + spellcastingPoints + "\nalchemyPoints " + alchemyPoints + "\ndivinationPoints " + divinationPoints);
        return "Отношения с Дандалионом: " + dandalionPoints.ToString() +
            "\nОтношения с Магнусом: " + magnusPoints.ToString();
    }
}
