using System.Collections;
using UnityEngine;

public class Trees : MonoBehaviour
{
    private bool destroyed = false;
    public GameObject destroyedprefab;
    public int maxDrop;
    public int minDrop;
    public float HP = 1;
    private float basehp;
    public float respawnTime;
    private CaracterTrigger player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CaracterTrigger>();
        basehp = HP;
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
        gameObject.transform.GetComponentInChildren<MeshRenderer>().enabled = false;
        BoxCollider boxCollider = gameObject.transform.GetComponentInChildren<BoxCollider>();
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
            boxCollider.enabled = true;
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
        player.treesHave += resourse;
    }
}
