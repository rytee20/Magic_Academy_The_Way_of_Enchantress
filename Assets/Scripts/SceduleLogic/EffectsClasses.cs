using UnityEngine;
using UnityEngine.EventSystems;

public class EffectsClasses : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverElement; // Элемент, который будет появляться при наведении

    void Start()
    {
        if (hoverElement != null)
        {
            hoverElement.SetActive(false); // Скрываем элемент при старте
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverElement != null)
        {
            hoverElement.SetActive(true); // Показываем элемент при наведении
            UpdateHoverElementPosition();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoverElement != null)
        {
            hoverElement.SetActive(false); // Скрываем элемент при уходе мышки
        }
    }

    void UpdateHoverElementPosition()
    {
        // Обновляем позицию элемента, чтобы он появлялся рядом с основным элементом
        Vector3 offset = new Vector3(170, 0, 0); // Смещение элемента (можно настроить)
        hoverElement.transform.position = transform.position + offset;
    }
}
