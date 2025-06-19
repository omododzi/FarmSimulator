using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
   public static Magazine Instance;
   [Header("Text")]
   public TMP_Text summAppleText;
   public TMP_Text summTreesText;
   public TMP_Text summRockText;
   public TMP_Text summCarrotText;
   public TMP_Text summMangoText;
   public TMP_Text summWatermamilonText;
   public TMP_Text summCornText;
   public TMP_Text summMushroomText;
   public TMP_Text summPumpkinText;
   [Header("Summ")]
   public int summApple;
   public int summTrees;
   public int summRock;
   public int summCarrot;
   public int summMango;
   public int summWatermamilon;
   public int summCorn;
   public int summMushroom;
   public int summPumpkin;

   void Awake()
   {
      Instance = this;
   }
   void LateUpdate()
   {
      summAppleText.text = (summApple * Enventory.Instance.applesHave).ToString();
      summTreesText.text = (summTrees * Enventory.Instance.treesHave).ToString();
      summRockText.text = (summRock * Enventory.Instance.rocksHave).ToString();
      summCarrotText.text = (summCarrot * Enventory.Instance.carrotsHave).ToString();
      summMangoText.text = (summMango * Enventory.Instance.mangosHave).ToString();
      summWatermamilonText.text = (summWatermamilon * Enventory.Instance.watermalonnHave).ToString();
      summCornText.text = (summCorn * Enventory.Instance.cornsHave).ToString();
      summMushroomText.text = (summMushroom * Enventory.Instance.mushroomsHave).ToString();
      summPumpkinText.text = (summPumpkin * Enventory.Instance.pumpkinsHave).ToString();
   }

   public void SellProduct(string product)
   {
      switch (product)
      {
         case "Apples":
            Enventory.Instance.Money += summApple * Enventory.Instance.applesHave;
            Enventory.Instance.applesHave = 0;
            break;
         case "Trees":
            Enventory.Instance.Money += summTrees * Enventory.Instance.treesHave;
            Enventory.Instance.treesHave = 0;
            break;
         case "Rock":
            Enventory.Instance.Money += summRock * Enventory.Instance.rocksHave;
            Enventory.Instance.rocksHave = 0;
            break;
         case "Carrot":
            Enventory.Instance.Money += summCarrot * Enventory.Instance.carrotsHave;
            Enventory.Instance.carrotsHave = 0;
            break;
         case "Mango":
            Enventory.Instance.Money += summMango * Enventory.Instance.mangosHave;
            Enventory.Instance.mangosHave = 0;
            break;
         case "Watermamilon":
            Enventory.Instance.Money += summWatermamilon;
            Enventory.Instance.watermalonnHave = 0;
            break;
         case "Corn":
            Enventory.Instance.Money += summCorn * Enventory.Instance.cornsHave;
            Enventory.Instance.cornsHave = 0;
            break;
         case "Mushrooms":
            Enventory.Instance.Money += summMushroom * Enventory.Instance.mushroomsHave;
            Enventory.Instance.mushroomsHave = 0;
            break;
         case "Pumpkin":
            Enventory.Instance.Money += summPumpkin * Enventory.Instance.pumpkinsHave;
            Enventory.Instance.pumpkinsHave = 0;
            break;
      }
   }
}
