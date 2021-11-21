using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArtifact : MonoBehaviour
{
    [SerializeField] private string artifactName;
    private bool collectedArtifact;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bool artifactFound = PlayerPrefs.GetInt(artifactName, 0) == 1;
        Debug.Log(artifactFound);
        sr.enabled = artifactFound;
    }
}
