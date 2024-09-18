using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Providing text in multiple languages requires two scripts(LocalisationSystem, CSVLoader) and dictionary csv files. 
 * localisationUI provides a method called GetLocalisedValue to call the dictionary and initializes all necessary parameters 
 * if they haven't been initialized yet. Currently supported languages are English and Spanish.
 * 
 * This script is form: https://www.youtube.com/watch?v=c-dzg4M20wY
 */

public class LocalisationSystem
{
    public enum Language {
        English,
        Spanish
    }

    public static Language language;

    private static Dictionary<string, string> localisaedEN;
    private static Dictionary<string, string> localisaedES;

    public static bool isInit = false;

    public static void Init() {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();

        localisaedEN = csvLoader.GetDictionaryValues("en");
        localisaedES = csvLoader.GetDictionaryValues("es");

        if (PlayerPrefs.HasKey("language")) {
            language = (PlayerPrefs.GetInt("language") == 0 ? Language.English : Language.Spanish);
        } else {
            language = Language.English;
        }

        isInit = true;
    }

    public static string GetLocalisedValue(string key) {
        if (!isInit) { Init(); }

        string value = key;

        switch (language) {
            case Language.English:
                localisaedEN.TryGetValue('\"' + key + '\"', out value);
                break;
            case Language.Spanish:
                localisaedES.TryGetValue('\"' + key + '\"', out value);
                int position = value.IndexOf('"');
                value = value.Substring(0, position);
                break;
        }

        return value;
    }

    public static string DictionaryToString(Dictionary<string, string> dictionary)
    {
        string dictionaryString = "{";
        foreach (KeyValuePair<string, string> keyValues in dictionary)
        {
            dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
        }
        return dictionaryString.TrimEnd(',', ' ') + "}";
    }
}
