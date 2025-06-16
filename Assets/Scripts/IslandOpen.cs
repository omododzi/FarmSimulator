using UnityEngine;

public class IslandOpen : MonoBehaviour
{
   public Enventory Inventory;
   [Header("Ресурсы для открытия острова")]
   [SerializeField] int moneyWont;
   
   public bool isopen = false;
   
   public BoxCollider[] boxColliders;

   void Start()
   {
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
