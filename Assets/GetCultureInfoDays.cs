using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

public class GetCultureInfoDays : MonoBehaviour
{
    public void ShowDays()
    {
        //Create a couple of test cultures using the new CultureInfo constructor
        CultureInfo[] newCultures = {new CultureInfo("de-DE"),
                                     new CultureInfo("en-US"),
                                     new CultureInfo("en-GB"),
                                     new CultureInfo("es-ES"),
                                     new CultureInfo("fr-FR"),
                                     new CultureInfo("nl-NL")};

        //Alternative way to create Cultures using CultureInfo.CreateSpecificCulture to ensure it isn't an issue with the constructor
        CultureInfo[] createCultures = {CultureInfo.CreateSpecificCulture("de-DE"),
                                        CultureInfo.CreateSpecificCulture("en-US"),
                                        CultureInfo.CreateSpecificCulture("en-GB"),
                                        CultureInfo.CreateSpecificCulture("es-ES"),
                                        CultureInfo.CreateSpecificCulture("fr-FR"),
                                        CultureInfo.CreateSpecificCulture("nl-NL")};

        //Loop through all the cultures created with the constructor
        Debug.Log("New CultureInfo: ");
        foreach (CultureInfo culture in newCultures)
        {
            //Loop through, and print the names of the days of the week in their respective language
            //On Windows this will print the expected result of 7 weekdays, on Android an 8th empty entry is appended.
            foreach (string day in culture.DateTimeFormat.DayNames)
            {
                Debug.Log(culture.Name + ": " + day);
            }
            Debug.Log("----------------");
        }

        Debug.Log("<color=blue>############</color>");

        //Loop through all the cultures created with CreateSpecificCulture method
        foreach (CultureInfo culture in createCultures)
        {
            //Loop through, and print, the names of the days of the week in their respective language
            //On Windows this will print the expected result of 7 weekdays, on Android an 8th empty entry is appended.
            foreach (string day in culture.DateTimeFormat.DayNames)
            {
                Debug.Log(culture.Name + ": " + day);
            }
            Debug.Log("----------------");
        }

        Debug.Log("<color=blue>############</color>");


        //Loop through, and print, the names of the days of the week based on the cultureInfo.CurrentCulture
        //This prints the expected 7 days of the week on both Windows and Android
        Debug.LogFormat("using current culture ({0}):", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.DayNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }
    }
}

