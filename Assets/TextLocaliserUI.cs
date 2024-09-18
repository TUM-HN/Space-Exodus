using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * Providing text in multiple languages requires two scripts(LocalisationSystem, CSVLoader) and dictionary csv files. 
 * TextLocaliserUI is the final script, responsible only for converting the input text into the corresponding language.
 * This script is form: https://www.youtube.com/watch?v=c-dzg4M20wY
 */

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    TextMeshProUGUI textField;

    public string key;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }

    private void Update()
    {
        string value = LocalisationSystem.GetLocalisedValue(key);
        textField.text = value;
    }

}
