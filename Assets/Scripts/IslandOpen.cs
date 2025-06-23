using UnityEngine;
using YG;

public class IslandOpen : MonoBehaviour
{
   public Enventory Inventory;
   [Header("Ресурсы для открытия острова")]
   [SerializeField] int moneyWont;
   
   public bool isopen = false;
   
   public BoxCollider[] boxColliders;

   void Start()
   {
      if (YandexGame.savesData.openedLevels != null && YandexGame.savesData.openedLevels.Count > 0)
      {
         if (YandexGame.savesData.openedLevels.Contains(gameObject))
         {
            isopen = true;
         }
      }
      Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Enventory>();
      if (!isopen)
      {
         for (int i = 0; i < transform.childCount; i++)
         {
            transform.GetChild(i).gameObject.SetActive(false);
         }

         for (int i = 0; i < boxColliders.Length; i++)
         {
            boxColliders[i].enabled = true;
         }
      }
      else
      {
         for (int i = 0; i < boxColliders.Length; i++)
         {
            boxColliders[i].enabled = false;
         }
      }
   }

   public void CheckResourses()
   {
      if (Inventory.Money >= moneyWont)
      {
         YGADD.TryShowFullscreenAdWithChance(100);
         YandexGame.savesData.openedLevels.Add(gameObject);
         YandexGame.SaveProgress();
         Inventory.Money -= moneyWont;
         isopen = true;
         for (int i = 0; i < transform.childCount; i++)
         {
            transform.GetChild(i).gameObject.SetActive(true);
         }
         for (int i = 0; i < boxColliders.Length; i++)
         {
            boxColliders[i].enabled = false;
         }
      }
   }
}
