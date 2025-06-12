using System;
using UnityEngine;

public class CaracterTrigger : MonoBehaviour
{
   public int treesHave;
   public int rocksHave;
   public int mushroomsHave;
   public int carrotsHave;
   public int watermalonnHave;
   public int applesHave;
   public int pumpkinsHave;
   public int mangosHave;
   public int cornsHave;
   public int damage = 1;
   
   private bool puntshTree = false;
   private bool puntshMushroom = false;
   private bool puntshWatermelon = false;
   private bool puntshApples = false;
   private bool puntshRocs = false;
   private bool puntshCarrots = false;
   private bool puntshPumpkins = false;
   private bool puntshMangos = false;
   private bool puntshCorns = false;
   
   private Trees trees;
   private Mushrooms mushrooms;
   private Rocs rocks;
   private Corn corn;
   private Watrmelon watrmelon;
   private Apple apple;
   private Mango mango;
   private Pumpkin pumpkin;
   private Carrots carrots;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Island"))
      {
         Debug.Log(other.gameObject.name);
         IslandOpen open = other.gameObject.GetComponent<IslandOpen>();
         open.CheckResourses(treesHave,
            rocksHave,mushroomsHave,carrotsHave,watermalonnHave,applesHave,pumpkinsHave,mangosHave,cornsHave);
      }

      if (other.gameObject.CompareTag("Tree")||other.gameObject.CompareTag("Mushroom")||
          other.gameObject.CompareTag("Apple")||other.gameObject.CompareTag("Mango")||
          other.gameObject.CompareTag("Corn")||other.gameObject.CompareTag("Rock")||
          other.gameObject.CompareTag("Watermelon")||other.gameObject.CompareTag("Pumpkin")||
          other.gameObject.CompareTag("Carrots"))
      {
         string tag = other.gameObject.tag;
         switch (tag)
         {
            case "Tree":
               puntshTree = true;
               trees = other.gameObject.GetComponent<Trees>();
               break;
            case "Mushroom":
               puntshMushroom = true;
               mushrooms = other.gameObject.GetComponent<Mushrooms>();
               break;
            case "Apples":
               puntshApples = true;
               apple = other.gameObject.GetComponent<Apple>();
               break;
            case "Mango":
               puntshMangos = true;
               mango = other.gameObject.GetComponent<Mango>();
               break;
            case "Corns":
               puntshCorns = true;
               corn = other.gameObject.GetComponent<Corn>();
               break;
            case "Rocks":
               puntshRocs = true;
               rocks = other.gameObject.GetComponent<Rocs>();
               break;
            case "Watermelon":
               puntshWatermelon = true;
               watrmelon = other.gameObject.GetComponent<Watrmelon>();
               break;
            case "Pumpkin":
               puntshPumpkins = true;
               pumpkin = other.gameObject.GetComponent<Pumpkin>();
               break;
            case "Carrots":
            {
               puntshCarrots = true;
               carrots = other.gameObject.GetComponent<Carrots>();
               break;
            }
         }
      }
   }

   private void FixedUpdate()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         if(puntshTree){trees.HP -= damage;}
         if(puntshMushroom){mushrooms.HP -= damage;}
         if(puntshApples){apple.HP -= damage;}
         if(puntshMangos){mango.HP -= damage;}
         if(puntshCorns){corn.HP -= damage;}
         if(puntshRocs){rocks.HP -= damage;}
         if(puntshWatermelon){watrmelon.HP -= damage;}
         if(puntshPumpkins){pumpkin.HP -= damage;}
         if(puntshCarrots){carrots.HP -= damage;}
      }
   }
}
