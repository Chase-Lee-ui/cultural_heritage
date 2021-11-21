using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject teleporter;

    public void TeleporterOn()
    {
        teleporter.SetActive(true);
    }
}
