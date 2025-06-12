using UnityEngine;

public class IslandOpen : MonoBehaviour
{
   [Header("Ресурсы для открытия острова")]
   public int treesWont;
   public int rocksWont;
   public int mushroomsWont;
   public int carrotsWont;
   public int watermalonnWont;
   public int applesWont;
   public int pumpkinsWont;
   public int mangoWont;
   public int cornsWont;
   
   public bool isopen = false;

   void Start()
   {
      if (!isopen)
      {
         for (int i = 0; i < transform.childCount; i++)
         {
            transform.GetChild(i).gameObject.SetActive(false);
         }
      }
   }

   public void CheckResourses(int trees,int rocs,int mushrooms,int carrots,int watermalonn,int apples,int pumpkins,int mango,int corns)
   {
      Debug.Log("sdada");
      if (trees >= treesWont &&
          rocs >= rocksWont &&
          mushrooms >= mushroomsWont &&
          carrots >= carrotsWont &&
          watermalonn >= watermalonnWont &&
          apples >= applesWont &&
          pumpkins >= pumpkinsWont &&
          mango >= mangoWont &&
          corns >= cornsWont)
      {
         isopen = true;
         for (int i = 0; i < transform.childCount; i++)
         {
            transform.GetChild(i).gameObject.SetActive(true);
         }
      }
      gameObject.GetComponent<BoxCollider>().enabled = false;
      
   }
}
