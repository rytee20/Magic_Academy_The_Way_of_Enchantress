using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LearningStrategyDecorator : ILearningStrategy
{
    protected ILearningStrategy decoratedStrategy;

    public LearningStrategyDecorator(ILearningStrategy decoratedStrategy)
    {
        this.decoratedStrategy = decoratedStrategy;
    }

    public virtual void Study()
    {
        decoratedStrategy.Study();
    }

    public virtual void Practice()
    {
        decoratedStrategy.Practice();
    }

    public virtual void Rest()
    {
        decoratedStrategy.Rest();
    }

    public SubjectType GetSubjectType()
    {
        return decoratedStrategy.GetSubjectType();
    }
}

public class EnhancedLearningStrategy : LearningStrategyDecorator
{
    public EnhancedLearningStrategy(ILearningStrategy decoratedStrategy) : base(decoratedStrategy) { }

    public override void Study()
    {
        base.Study();

        EnhanceStudy();
    }

    private void EnhanceStudy()
    {
        SceduleManager sceduleManager = GameObject.FindObjectOfType<SceduleManager>();
        if (sceduleManager != null)
        {
            sceduleManager.GetPlayer().SetStudyPoints((int)base.GetSubjectType(), Random.Range(1, 16));
        }
        else
        {
            Debug.Log("No Game Was Found");
        }

        //Debug.Log("Enhancing Study");
    }
}


