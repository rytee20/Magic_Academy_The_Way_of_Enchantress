using UnityEngine;
using UnityEngine.UI;
using static TMPro.Examples.TMP_ExampleScript_01;

public class ActivityButton : MonoBehaviour
{
    public bool isItADate;
    public int characterIndex;

    public int actionIndex;
    public int activityIndex;
    public Image image;

    public Scedule scedule;
    private ILearningStrategy strategy;

    /*public void StartButtons()
    {
        SceduleManager sceduleManager = FindObjectOfType<SceduleManager>();

        if (sceduleManager != null)
        {
            strategy = sceduleManager.GetStrategy(activityIndex);
            Debug.Log(sceduleManager);
        }
        else
            Debug.LogError("Game instance not found in the scene.");
    }*/

    public void OnButtonClick()
    {
        SceduleManager sceduleManager = FindObjectOfType<SceduleManager>();

        if (sceduleManager != null)
        {
            strategy = sceduleManager.GetStrategy(activityIndex);
            //Debug.Log(sceduleManager);
        }
        else
            Debug.LogError("Game instance not found in the scene.");

        if (isItADate && scedule != null)
        {
            //Debug.Log(characterIndex);
            scedule.AddDateToSlot(3, image, characterIndex);
        }
        else 
        if (!isItADate && scedule != null && scedule.CanAddActivityToSlot())
        {
            //Debug.Log(strategy);
            scedule.AddActivityToSlot(actionIndex, image, strategy);
        }
    }
}
