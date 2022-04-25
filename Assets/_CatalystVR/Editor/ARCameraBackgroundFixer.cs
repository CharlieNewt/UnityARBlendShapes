using System;
using System.IO;
using UnityEditor;

[InitializeOnLoad]
public static class ARCameraBackgroundFixer
{
    static ARCameraBackgroundFixer()
    {
        if (ApplyFixIfNeeded())
        {
            AssetDatabase.Refresh();
        }
    }

    static bool ApplyFixIfNeeded()
    {
        var path =
            "Packages/com.unity.xr.arfoundation/Runtime/AR/ARCameraBackground.cs";
        var script = AssetDatabase.LoadAssetAtPath<MonoScript>(path);
        var text = script.text;
        if (text.Contains("AR_FOUNDATION_EDITOR_REMOTE"))
        {
            return false;
        }

        var index =
            text
                .IndexOf("commandBuffer.IssuePluginEvent(",
                StringComparison.Ordinal);
        var withFix =
            text
                .Insert(index,
                @"// AR_FOUNDATION_EDITOR_REMOTE: calling commandBuffer.IssuePluginEvent is crashing Unity Editor 2019.2 and freezing newer versions of Unity
           " +
                @"#if !UNITY_EDITOR
           ");
        withFix =
            withFix
                .Insert(withFix.IndexOf(";", index, StringComparison.Ordinal) +
                1,
                @"
           " + "#endif");
        File.WriteAllText(AssetDatabase.GetAssetPath(script), withFix);
        return true;
    }
}
