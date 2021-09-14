using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip pickedUpAudio;
    [SerializeField]
    private GameObject body;
    private AudioSource audioSource;
    private bool pickedUp;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PickedUp() {
        if (pickedUp) return;
        audioSource.PlayOneShot(pickedUpAudio);
        pickedUp = true;
        body.SetActive(false);
        Destroy(gameObject, 1.5f);
    }
    
}
