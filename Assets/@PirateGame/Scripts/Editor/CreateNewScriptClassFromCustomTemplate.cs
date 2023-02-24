using UnityEditor;
using UnityEngine;

public class CreateNewScriptClassFromCustomTemplate
{
    private const string pathToModelTemplate = "Assets/@PirateGame/Scripts/ScriptTemplates/ModelTemplate.cs.txt";
    private const string pathToViewTemplate = "Assets/@PirateGame/Scripts/ScriptTemplates/ViewTemplate.cs.txt";
    private const string pathToControllerTemplate = "Assets/@PirateGame/Scripts/ScriptTemplates/ControllerTemplate.cs.txt";
    private const string pathToEnumTemplate = "Assets/@PirateGame/Scripts/ScriptTemplates/EnumTemplate.cs.txt";
    private const string pathToScriptableObjectTemplate = "Assets/@PirateGame/Scripts/ScriptTemplates/ScriptableObjectTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/Script Templates/Create New Model Script", isValidateFunction: false, priority: 51)]
    public static void CreateModelScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToModelTemplate, "Model.cs");
    }

    [MenuItem(itemName: "Assets/Create/Script Templates/Create New View Script", isValidateFunction: false, priority: 51)]
    public static void CreateViewScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToViewTemplate, "View.cs");
    }

    [MenuItem(itemName: "Assets/Create/Script Templates/Create New Controller Script", isValidateFunction: false, priority: 51)]
    public static void CreateControllerScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToControllerTemplate, "Controller.cs");
    }

    [MenuItem(itemName: "Assets/Create/Script Templates/Create New Enum Script", isValidateFunction: false, priority: 51)]
    public static void CreateEnumScript ()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToEnumTemplate, "Enum.cs");
    }

    [MenuItem(itemName: "Assets/Create/Script Templates/Create New Scriptable Object Script", isValidateFunction: false, priority: 51)]
    public static void CreateScriptableObjectScript ()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToScriptableObjectTemplate, "ScriptableObject.cs");
    }
}