using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public GameEndingObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player )
        {

        }
    }
}




