using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenEnventory : MonoBehaviour, IPointerClickHandler
{
    public List<GameObject> resorses;
    public GameObject trowDown;
    public GameObject trowUp;

    void Start()
    {
        trowUp.SetActive(true);
        trowDown.SetActive(false);
        for (int i = 0; i < resorses.Count; i++)
        {
            resorses[i].SetActive(trowDown.activeSelf);
        }
    }

    public void Switsh()
    {
        trowUp.SetActive(!trowUp.activeSelf);
        trowDown.SetActive(!trowDown.activeSelf);
       
        for (int i = 0; i < resorses.Count; i++)
        {
            resorses[i].SetActive(trowDown.activeSelf);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        trowUp.SetActive(!trowUp.activeSelf);
        trowDown.SetActive(!trowDown.activeSelf);
       
        for (int i = 0; i < resorses.Count; i++)
        {
            resorses[i].SetActive(trowDown.activeSelf);
        }
    }
}
