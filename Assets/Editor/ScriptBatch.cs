using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using System.IO;
using System;


public class ScriptBatch : MonoBehaviour {
    public static void MyBuild ()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        List<string> enabledScenePathnames = new List<string>();

        foreach (var buildSettingScene in EditorBuildSettings.scenes)
        {
            enabledScenePathnames.Add(buildSettingScene.path);
        }

        buildPlayerOptions.scenes = enabledScenePathnames.ToArray();
        //buildPlayerOptions.locationPathName = Path.Combine("Build", DateTime.Now.ToString("_MM-dd-yyyy HH--mm--ss"));
        buildPlayerOptions.locationPathName = "Build";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        if( summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Hooray! We conquered the universe!!!!! xD xD xD xD");
        } else
        {
            Debug.Log("Entropy conquered us instead... Dx Dx Dx");
        }
    }
}
