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
        CultureInfo[] newCultures = {//new CultureInfo("de-DE"),
                                     //new CultureInfo("en-US"),
                                     //new CultureInfo("en-GB"),
                                     //new CultureInfo("es-ES"),
                                     //new CultureInfo("fr-FR"),
                                     new CultureInfo("nl-NL")};

        //Alternative way to create Cultures using CultureInfo.CreateSpecificCulture to ensure it isn't an issue with the constructor
        CultureInfo[] createCultures = {CultureInfo.CreateSpecificCulture("de-DE"),
                                        CultureInfo.CreateSpecificCulture("en-US"),
                                        CultureInfo.CreateSpecificCulture("en-GB"),
                                        CultureInfo.CreateSpecificCulture("es-ES"),
                                        CultureInfo.CreateSpecificCulture("fr-FR"),
                                        CultureInfo.CreateSpecificCulture("nl-NL")};

        //Loop through all the cultures created with the constructor
        Debug.Log("New CultureInfo weekdays: ");
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

        Debug.Log("Abbreviated days: ");
        foreach (CultureInfo culture in newCultures)
        {
            foreach (string dayAbr in culture.DateTimeFormat.AbbreviatedDayNames)
            {
                Debug.Log(culture.Name + ": " + dayAbr);
            }
        }

        Debug.Log("<color=blue>############</color>");

        Debug.Log("New CultureInfo genitive months: ");
        foreach (var culture in newCultures)
        {
            foreach (var shortestDay in culture.DateTimeFormat.ShortestDayNames)
            {
                Debug.Log(culture.Name + ": " + shortestDay);
            }
        }

        Debug.Log("<color=blue>############</color>");

        Debug.Log("New CultureInfo months: ");
        foreach (var culture in newCultures)
        {
            foreach (var month in culture.DateTimeFormat.MonthNames)
            {
                Debug.Log(culture.Name + ": " + month);
            }
        }

        Debug.Log("<color=blue>############</color>");

        Debug.Log("New CultureInfo months abbreviated: ");
        foreach (var culture in newCultures)
        {
            foreach (var month in culture.DateTimeFormat.AbbreviatedMonthNames)
            {
                Debug.Log(culture.Name + ": " + month);
            }
        }

        Debug.Log("<color=blue>############</color>");

        Debug.Log("New CultureInfo genitive months: ");
        foreach (var culture in newCultures)
        {
            foreach (var month in culture.DateTimeFormat.MonthGenitiveNames)
            {
                Debug.Log(culture.Name + ": " + month);
            }
        }

        Debug.Log("<color=blue>############</color>");

        Debug.Log("New CultureInfo Calendar Eras ");
        foreach (var culture in newCultures)
        {
            foreach (var era in culture.Calendar.Eras)
            {
                Debug.Log(culture.Name + ": " + era);
            }
        }

        Debug.Log("<color=blue>############</color>");

        //Uncomment the following foreach loop to observe that the issue also persists when using CreateSpecificCulture to create cultures.

        ////Loop through all the cultures created with CreateSpecificCulture method
        //foreach (CultureInfo culture in createCultures)
        //{
        //    //Loop through, and print, the names of the days of the week in their respective language
        //    //On Windows this will print the expected result of 7 weekdays, on Android an 8th empty entry is appended.
        //    foreach (string day in culture.DateTimeFormat.DayNames)
        //    {
        //        Debug.Log(culture.Name + ": " + day);
        //    }
        //    Debug.Log("----------------");
        //}

        //Debug.Log("<color=blue>############</color>");

        Debug.Log("<color=red>###### CurrentCulture ######</color>");

        //Loop through, and print, the names of the days of the week based on the cultureInfo.CurrentCulture
        //This prints the expected 7 days of the week on both Windows and Android
        Debug.LogFormat("using current culture ({0}) Days:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.DayNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) abrdays:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) shortest days:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.ShortestDayNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) Months:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.MonthNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) Months abbreviated:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) genitive months:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }

        Debug.LogFormat("using current culture ({0}) era:", CultureInfo.CurrentCulture.Name);
        foreach (var item in CultureInfo.CurrentCulture.Calendar.Eras)
        {
            Debug.Log(CultureInfo.CurrentCulture.Name + ": " + item);
        }
    }
}

