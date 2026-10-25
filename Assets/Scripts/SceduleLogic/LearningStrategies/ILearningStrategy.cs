using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ILearningStrategy
{
    void Study();
    void Practice();
    void Rest();
    SubjectType GetSubjectType();
}
