using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scedule : MonoBehaviour
{
    public List<SlotButton> sceduleSlots;

    private List<CharacterType> characterTypes;
    private Date dateing;

    private List<ILearningStrategy> dailyActivities;
    private List<ActionType> actionTypes;
    private List<Image> sceduleImages;

    private enum ActionType
    {
        Study = 0,
        Practicie = 1,
        Rest = 2,
        Date = 3
    }

    void Start()
    {
        dailyActivities = new List<ILearningStrategy>();
        actionTypes = new List<ActionType>();
        sceduleImages = new List<Image>();
        characterTypes = new List<CharacterType>();

        dateing = new Date();

        foreach (var slot in sceduleSlots)
        {
            GameObject overlayObject = new GameObject("OverlayImage");
            overlayObject.transform.SetParent(slot.transform);
            overlayObject.transform.localPosition = Vector3.zero;
            overlayObject.transform.localScale = Vector3.one;
            overlayObject.transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);

            slot.CreateImage(overlayObject);
        }
    }

    public void AddActivityToSlot(int actionIndex, Image image, ILearningStrategy activity)
    {
        //Debug.Log(activity);
        dailyActivities.Add(activity);
        characterTypes.Add(CharacterType.Null);
        actionTypes.Add((ActionType)actionIndex);
        sceduleImages.Add(image);

        UpdateSlots();
    }

    public void AddDateToSlot(int actionIndex, Image image, int characterIndex)
    {
        dailyActivities.Add(null);
        //Debug.Log(characterIndex);
        characterTypes.Add((CharacterType)characterIndex);
        actionTypes.Add((ActionType)actionIndex);
        sceduleImages.Add(image);

        UpdateSlots();
    }

    public void RemoveActivity(int index)
    {
        dailyActivities.RemoveAt(index);
        actionTypes.RemoveAt(index);
        sceduleImages.RemoveAt(index);
        characterTypes.RemoveAt(index);

        UpdateSlots();
    }

    public void RemoveActivities()
    {
        dailyActivities.Clear();
        actionTypes.Clear();
        sceduleImages.Clear();
        characterTypes.Clear();

        UpdateSlots();
    }

    private void UpdateSlots()
    {
        for (int i = 0; i < sceduleSlots.Count; i++)
        {
            if (i < sceduleImages.Count) 
                sceduleSlots[i].SetImage(sceduleImages[i]);
            else 
                sceduleSlots[i].RemoveImage();
        }
    }

    public void PerformingActivities()
    {
        for (int i = 0; i < sceduleSlots.Count; i++)
        {
            if (i < dailyActivities.Count)
            {
                switch (actionTypes[i])
                {
                    case ActionType.Study:
                        dailyActivities[i].Study();
                        break;
                    case ActionType.Practicie:
                        dailyActivities[i].Practice();
                        break;
                    case ActionType.Rest:
                        dailyActivities[i].Rest();
                        break;
                    case ActionType.Date:
                        if (characterTypes[i] != CharacterType.Null)
                        {
                            dateing.DateWithCharacter((int)characterTypes[i]);
                            //Debug.Log("Встречаемся "+ (int)characterTypes[i]);
                        }
                        break;
                    default:
                        throw new ArgumentException("Unknown action type");
                }
            }
            else break;
        }

        RemoveActivities();

        //Debug.Log("отчистка");
    }

    public void HideSlots()
    {
        for (int i = sceduleSlots.Count-1; i > sceduleSlots.Count-3; i--)
        {
            sceduleSlots[i].gameObject.SetActive(false);
        }
    }

    public void ReturnSlots()
    {
        for (int i = sceduleSlots.Count - 3; i < sceduleSlots.Count; i++)
        {
            sceduleSlots[i].gameObject.SetActive(true);
        }
    }

    public bool CanAddActivityToSlot()
    {
        for(int i = 0; i < sceduleSlots.Count; i++)
        {
            if (!IndexExists<Image>(sceduleImages,i) && sceduleSlots[i].gameObject.activeSelf) return true;
        }
        return false;
    }

    private static bool IndexExists<T>(List<T> list, int index)
    {
        return index >= 0 && index < list.Count;
    }

}
