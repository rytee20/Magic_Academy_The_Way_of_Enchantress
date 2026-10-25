using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    public int slotIndex;
    private Image image;

    public void OnButtonClick()
    {
        //Debug.Log("SlotButton");
        Scedule scedule = FindObjectOfType<Scedule>();
        if (image != null && scedule != null) 
            scedule.RemoveActivity(slotIndex);
    }

    public void CreateImage(GameObject obj)
    {
        image = obj.GetComponent<Image>();
        if (image == null) 
            image = obj.AddComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

    public void SetImage(Image im)
    {
        image.sprite = im.sprite;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
    }

    public void RemoveImage()
    {
        image.sprite = null;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }
}
