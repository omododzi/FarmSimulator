using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().enabled = false;
        Magazine.Instance.SellProduct(gameObject.transform.parent.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
}
