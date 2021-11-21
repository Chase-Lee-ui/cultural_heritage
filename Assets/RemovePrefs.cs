using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePrefs : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
