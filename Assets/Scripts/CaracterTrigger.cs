using System;
using System.Collections;
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
   private CharacterMovement characterMovement;
   
   public Animator animator;

   void Start()
   {
      characterMovement = GetComponent<CharacterMovement>();
   }
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
          other.gameObject.CompareTag("Carrot"))
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
            case "Carrot":
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
      if (Input.GetKeyDown(KeyCode.E)&& characterMovement.canMove)
      {
         if(puntshTree){animator.SetTrigger("Tree"); StartCoroutine(InAnimation(trees,"Tree"));
         }
         if(puntshMushroom){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(mushrooms,"Plants"));}
         if(puntshApples){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(apple,"Plants"));}
         if(puntshMangos){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(mango,"Plants"));}
         if(puntshCorns){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(corn,"Plants"));}
         if(puntshRocs){animator.SetTrigger("Rock");
            StartCoroutine(InAnimation(rocks,"Rock"));}
         if(puntshWatermelon){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(watrmelon,"Plants"));}
         if(puntshPumpkins){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(pumpkin,"Plants"));}
         if(puntshCarrots){animator.SetTrigger("Plants");
            StartCoroutine(InAnimation(carrots,"Plants"));}
      }
   }

   IEnumerator InAnimation(MonoBehaviour scobj, string nameanim)
   {
      characterMovement.canMove = false;
      float timeanim = 0;
      switch (nameanim)
      {
         case "Tree":
            timeanim = 2.4f;
            break;
         case "Rock":
            timeanim = 3.20f;
            break;
         case "Plants":
            timeanim = 6f;
            break;
      }
      yield return new WaitForSeconds(timeanim);
      switch (scobj)
      {
         case Trees:
            trees.HP -= damage;
            break;
         case Mushrooms:
            mushrooms.HP -= damage;
            break;
         case Rocs:
            rocks.HP -= damage;
            break;
         case Carrots:
            carrots.HP -= damage;
            break;
         case Pumpkin:
            pumpkin.HP -= damage;
            break;
         case Mango:
            mango.HP -= damage;
            break;
         case Corn:
            corn.HP -= damage;
            break;
         case Watrmelon:
            watrmelon.HP -= damage;
            break;
         case Apple:
            apple.HP -= damage;
            break;
         
      }
      characterMovement.canMove = true;
   }
}
