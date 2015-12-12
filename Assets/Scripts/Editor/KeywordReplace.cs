//Assets/Editor/KeywordReplace.cs
using System.Collections;
using UnityEditor;
using UnityEngine;

//Source: http://forum.unity3d.com/threads/c-script-template-how-to-make-custom-changes.273191/
public class KeywordReplace : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        string file = path.Substring(index);
        if (file != ".cs" && file != ".js" && file != ".boo") return;
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        file = System.IO.File.ReadAllText(path);

        file = file.Replace("#CREATIONDATE#", System.DateTime.Now + "");
        file = file.Replace("#PROJECTNAME#", PlayerSettings.productName);
        file = file.Replace("#SMARTDEVELOPERS#", PlayerSettings.companyName);

        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }
}
