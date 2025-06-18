using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Resours : MonoBehaviour
{
    private Enventory env;
    [Header("How many Resourses & time to respawn & hp")]
    [SerializeField] float respawnTime = 1f;
    [SerializeField] int resourses = 1;
    [SerializeField] float HP = 1;
    [SerializeField] private float basehp;
    
    [Header("State")]public bool destroyed = false;
    
    [Header("Settings")]
    [SerializeField] BoxCollider[] boxColliders;
    [SerializeField] MeshRenderer[] meshRenderers;
    [SerializeField] GameObject DestroyedObject;
    [SerializeField] SphereCollider[] sphereCollider;
    
    
    void Start()
    {
        env = GameObject.FindGameObjectWithTag("Player").GetComponent<Enventory>();
        basehp = HP;
        if (DestroyedObject!=null)
        {
            DestroyedObject.SetActive(false);
        }
        if (destroyed)
        {
            SetOffoll();
        }
    }

    IEnumerator Respawn()
    {
        SetOffoll();
        yield return new WaitForSeconds(respawnTime);
        HP = basehp;
        SetOnOll();
    }

    void SetOffoll()
    {
     

        if (meshRenderers != null)
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].enabled = false;
            }
        }

        if (DestroyedObject != null)
        {
            DestroyedObject.SetActive(true);
        }

        if (sphereCollider != null)
        {
            for (int i = 0; i < sphereCollider.Length; i++)
            {
                sphereCollider[i].enabled = false;
            }
        }
    }

    void SetOnOll()
    {
       

        if (meshRenderers != null)
        {
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].enabled = true;
            }
        }

        if (DestroyedObject != null)
        {
            DestroyedObject.SetActive(false);
        }
        if (sphereCollider != null)
        {
            for (int i = 0; i < sphereCollider.Length; i++)
            {
                sphereCollider[i].enabled = true;
            }
        }
    }

    public void TakeDamage()
    {
        HP -= env.damage;
        if (HP <=0)
        {
            StartCoroutine(Respawn());
            string tagobj = gameObject.tag;
            switch (tagobj)
            {
                case "Tree":
                    env.treesHave += resourses;
                    break;
                case "Mushroom":
                    env.mushroomsHave += resourses;
                    break;
                case "Apples":
                    env.applesHave += resourses;
                    break;
                case "Mango":
                    env.mangosHave += resourses;
                    break;
                case "Corns":
                   env.cornsHave += resourses;
                    break;
                case "Rocks":
                    env.rocksHave += resourses;
                    break;
                case "Watermelon":
                   env.watermalonnHave += resourses;
                    break;
                case "Pumpkin":
                   env.pumpkinsHave += resourses;
                    break;
                case "Carrot":
                    env.carrotsHave += resourses;
                    break;
                
            }

            StartCoroutine(Respawn());
        }
    }
}
