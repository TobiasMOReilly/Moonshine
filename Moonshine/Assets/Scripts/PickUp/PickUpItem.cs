using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {

    [SerializeField] private List<PickupInventoryItem> possiblePickups;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            //audioSource.Play();
            StartCoroutine(Play());
            int pickUpID = Random.Range(0, possiblePickups.Count-1);
            other.gameObject.GetComponent<PlayerState>().GetPlayerInventory().addItem(possiblePickups[pickUpID]);
            other.gameObject.GetComponent<PlayerState>().GetPlayer().jugsCollected += 1;
            Destroy(this.gameObject);
            
        }

    }
    IEnumerator Play()
    {
        audioSource.PlayOneShot(audioSource.clip);
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
