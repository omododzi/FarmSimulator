using System.Collections;
using UnityEngine;

public class Mushrooms : MonoBehaviour
{
    private bool destroyed = false;
    public GameObject destroyedprefab;
    public int maxDrop;
    public int minDrop;
    public float HP = 1;
    public float respawnTime;
    private CaracterTrigger player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CaracterTrigger>();
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
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        if (destroyedprefab != null)
        {
            destroyedprefab.SetActive(true);
        }
        
        GiveResourse();
        yield return new WaitForSeconds(respawnTime);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        if (destroyedprefab != null)
        {
            destroyedprefab.SetActive(false);
        }
      
    }

    public void GiveResourse()
    {
        int resourse = Random.Range(minDrop, maxDrop);
        player.mushroomsHave += resourse;
    }
}
