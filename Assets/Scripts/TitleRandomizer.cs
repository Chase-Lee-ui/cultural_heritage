using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleRandomizer : MonoBehaviour {

    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] titles;

    // Start is called before the first frame update
    void Start() {
        int randNum = Random.Range(0, titles.Length);
        textComponent.text = titles[randNum];
    }
}
