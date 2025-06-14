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
        if (destroyedprefab != null)
        {
            destroyedprefab.SetActive(true);
        }
        
        GiveResourse();
        yield return new WaitForSeconds(respawnTime);
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
