using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterTrigger : MonoBehaviour
{
   private CharacterMovement characterMovement;
   public Animator animator;
   private Resours resours;
   public List<string> plants = new List<string>()
   {
      "Mushroom","Apple","Mango","Corns","Watermelon","Pumpkin","Carrot","Corn"
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
        
         resours = other.GetComponent<Resours>();
         stayInPlant = true;
         resources = other.gameObject.GetComponent<Resours>();
      }

      if (other.gameObject.CompareTag("Corn")||other.gameObject.CompareTag("Apple")||other.gameObject.CompareTag("Carrot"))
      {
         resours = other.GetComponent<Resours>();
         stayInPlant = true;
         resources = other.gameObject.GetComponent<Resours>();
      }

      if (other.CompareTag("Tree") )
      {
         resours = other.GetComponent<Resours>();
         stayInTree = true;
         resources = other.gameObject.GetComponent<Resours>();
      }

      if (other.CompareTag("Rock"))
      {
         resours = other.GetComponent<Resours>();
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
      if (other.gameObject.CompareTag("Corn")||other.gameObject.CompareTag("Apple")||other.gameObject.CompareTag("Carrot"))
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
         
         if (stayInPlant && !resours.destroyed)
         {
            animator.SetTrigger("Plants");
            StartCoroutine(InAnimation("Plants"));
         }else if (stayInTree&& !resours.destroyed)
         {
            animator.SetTrigger("Tree");
            StartCoroutine(InAnimation("Tree"));
         }else if (stayInRock&& !resours.destroyed)
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
         if (stayInPlant&& !resours.destroyed)
         {
            animator.SetTrigger("Plants");
            StartCoroutine(InAnimation("Plants"));
         }else if (stayInTree&& !resours.destroyed)
         {
            animator.SetTrigger("Tree");
            StartCoroutine(InAnimation("Tree"));
         }else if (stayInRock&& !resours.destroyed)
         {
            animator.SetTrigger("Rock");
            StartCoroutine(InAnimation("Rock"));
         }
      }
   }
   

   IEnumerator InAnimation(string nameanim)
   {
      animator.SetBool("iswalk",false);
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
            timeanim = 6.5f;
            break;
      }
      yield return new WaitForSeconds(timeanim);
      resources.TakeDamage();
      characterMovement.canMove = true;
   }
}
