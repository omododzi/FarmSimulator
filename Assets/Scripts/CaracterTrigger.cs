using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterTrigger : MonoBehaviour
{
   private CharacterMovement characterMovement;
   public Animator animator;
   public List<string> plants = new List<string>()
   {
      "Mushroom","Apples","Mango","Corns","Watermelon","Pumpkin","Carrot"
   };
   private bool stayInPlant = false;
   private bool stayInTree = false;
   private bool stayInRock = false;
   
   [SerializeField] Resours resources;
   void Start()
   {
      characterMovement = GetComponent<CharacterMovement>();
   }
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Island"))
      {
         IslandOpen open = other.gameObject.GetComponent<IslandOpen>();
         open.CheckResourses();
      }
      if (plants.Contains(other.gameObject.tag))
      {
         stayInPlant = true;
         resources = other.gameObject.GetComponent<Resours>();
      }

      if (other.CompareTag("Tree") )
      {
         stayInTree = true;
         resources = other.gameObject.GetComponent<Resours>();
      }

      if (other.CompareTag("Rock"))
      {
         stayInRock = true;
         resources = other.gameObject.GetComponent<Resours>();
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (plants.Contains(other.gameObject.tag))
      {
         stayInPlant = false;
      }

      if (other.CompareTag("Tree") )
      {
         stayInTree = false;
      }

      if (other.CompareTag("Rock"))
      {
         stayInRock = false;
      }
   }

   private void FixedUpdate()
   {
      if (Input.GetKeyDown(KeyCode.E)&& characterMovement.canMove)
      {
         if (stayInPlant)
         {
            animator.SetTrigger("Plants");
            StartCoroutine(InAnimation("Plants"));
         }else if (stayInTree)
         {
            animator.SetTrigger("Tree");
            StartCoroutine(InAnimation("Tree"));
         }else if (stayInRock)
         {
            animator.SetTrigger("Rock");
            StartCoroutine(InAnimation("Rock"));
         }
      }
   }

   public void ButtonGerResourses()
   {
      if (characterMovement.canMove)
      {
         if (stayInPlant)
         {
            animator.SetTrigger("Plants");
            StartCoroutine(InAnimation("Plants"));
         }else if (stayInTree)
         {
            animator.SetTrigger("Tree");
            StartCoroutine(InAnimation("Tree"));
         }else if (stayInRock)
         {
            animator.SetTrigger("Rock");
            StartCoroutine(InAnimation("Rock"));
         }
      }
   }
   

   IEnumerator InAnimation(string nameanim)
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
            timeanim = 7f;
            break;
      }
      yield return new WaitForSeconds(timeanim);
      resources.TakeDamage();
      characterMovement.canMove = true;
   }
}
