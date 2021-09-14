using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurtlesimCollider : MonoBehaviour
{
    public TwistPublisher twistPublisher;
    public TextMeshProUGUI text;
    private int coinCount;
    private void OnTriggerEnter(Collider other) {
        
        GameObject target = other.gameObject;
        if (target.tag == "Coin") {
            target.GetComponent<Coin>().PickedUp();
            twistPublisher.linearSpeed += 0.01f;
            coinCount ++;
            text.text = coinCount.ToString();
        }
    }

}
