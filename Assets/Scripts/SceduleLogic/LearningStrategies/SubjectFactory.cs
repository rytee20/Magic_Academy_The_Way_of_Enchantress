using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubjectType
{
    Spellcasting = 0,
    Alchemy = 1,
    Divination = 2
}

public class SubjectFactory
{
    public ILearningStrategy CreateSubject(SubjectType type)
    {
        switch (type)
        {
            case SubjectType.Spellcasting:
                return new SpellcastingStrategy();
            case SubjectType.Alchemy:
                return new AlchemyStrategy();
            case SubjectType.Divination:
                return new DivinationStrategy();
            default:
                throw new ArgumentException("Unknown subject type");
        }
    }
}
