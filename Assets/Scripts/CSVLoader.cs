using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader
{
    //Reference file
    private TextAsset csvFile;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = { "\",\""};

    public void LoadCSV() {
        csvFile = Resources.Load<TextAsset>("Localisation");

    }

    public Dictionary<string, string> GetDictionaryValues(string attributeID) {

        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string[] lines = csvFile.text.Split(lineSeperator);

        int attributeIndex = -1;

        string[] headers = lines[0].Split(fieldSeperator, StringSplitOptions.None);

        //Get attributeIndex -> get dictionary of specific language
        for (int i = 0; i < headers.Length; i++) {
            if (headers[i].Contains(attributeID)) {
                attributeIndex = i;
                break;
            }
        }

        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

        //For each line in csv, parse it and store the corresponding value in dictionary
        for (int i = 1; i < lines.Length; i++) {
            string line = lines[i];

            string[] fields = CSVParser.Split(line);

            for (int j = 1; j < fields.Length; j++) {
                fields[j] = fields[j].TrimStart(' ', surround);
                fields[j] = fields[j].TrimEnd(surround);
            }

            if (fields.Length > attributeIndex) {
                var key = fields[0];

                if (dictionary.ContainsKey(key)) { continue; }

                var value = fields[attributeIndex];

                dictionary.Add(key, value);
            }
        }

        return dictionary;
    }
}
