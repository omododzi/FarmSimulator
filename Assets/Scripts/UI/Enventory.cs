using System;
using UnityEngine;
using TMPro;
public class Enventory: MonoBehaviour
{
    public static Enventory instance;
    
    public int treesHave;
    public int rocksHave;
    public int mushroomsHave;
    public int carrotsHave;
    public int watermalonnHave;
    public int applesHave;
    public int pumpkinsHave;
    public int mangosHave;
    public int cornsHave;
    public int Money;

    public int damage = 1;
    
    public TMP_Text treesText;
    public TMP_Text rocksText;
    public TMP_Text mushroomsText;
    public TMP_Text carrotsText;
    public TMP_Text watermalonnText;
    public TMP_Text applesText;
    public TMP_Text pumpkinsText;
    public TMP_Text mangosText;
    public TMP_Text cornsText;
    public TMP_Text MoneyText;
    

    private void LateUpdate()
    {
        treesText.text = treesHave.ToString();
        rocksText.text = rocksHave.ToString();
        mushroomsText.text = mushroomsHave.ToString();
        carrotsText.text = carrotsHave.ToString();
        watermalonnText.text = watermalonnHave.ToString();
        applesText.text = applesHave.ToString();
        pumpkinsText.text = pumpkinsHave.ToString();
        mangosText.text = mangosHave.ToString();
        cornsText.text = cornsHave.ToString();
        MoneyText.text = Money.ToString();
    }
}
