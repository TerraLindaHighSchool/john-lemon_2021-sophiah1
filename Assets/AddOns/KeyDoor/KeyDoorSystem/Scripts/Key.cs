using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private TouchScreenKeyboardType keyType;

    public enum KeyType
    {
        Red,
        Green,
        Blue,

    }

}
