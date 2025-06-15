using System.Collections;
using UnityEngine;

public class Corn : MonoBehaviour
{ private bool destroyed = false;
    public GameObject destroyedprefab;
    public int maxDrop;
    public int minDrop;
    public float HP = 1;
    private float basehp;
    public float respawnTime;
    private CaracterTrigger player;
    public bool isopen = true;
    public MeshRenderer[] children;
    void Start()
    {
        basehp = HP;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CaracterTrigger>();
        if (isopen)
        {
            destroyedprefab.SetActive(false);           
        }
        else
        {
            destroyedprefab.SetActive(true);
            for (int i = 0; i < children.Length; i++)
            {
                children[i].enabled = false;
            }
           
            StartCoroutine(Respawn());
        }
    }
    private void Update()
    {
        if (HP <= 0 && !destroyed)
        {
            destroyed = true;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].enabled = false;
        }
        BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
        if (destroyedprefab != null)
        {
            destroyedprefab.SetActive(true);
        }
        else
        {
            SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.enabled = false;
        }
        GiveResourse();
        
        yield return new WaitForSeconds(respawnTime);
        
        if (boxCollider != null)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].enabled = true;
            }
        } else
        {
            SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.enabled = true;
        }
        HP = basehp;
        gameObject.transform.GetComponentInChildren<MeshRenderer>().enabled  = true;
        if (destroyedprefab != null)
        {
            destroyedprefab.SetActive(false);
        }
      
    }

    public void GiveResourse()
    {
        int resourse = Random.Range(minDrop, maxDrop);
        player.cornsHave += resourse;
    }
}
