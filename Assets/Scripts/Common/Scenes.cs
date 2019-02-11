using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private static List<Scene> scenes;
    private static int goToSceneNumber = -1;

    public static void Init()
    {
        scenes = new List<Scene>();
        SceneManager.sceneLoaded += onSceneLoaded;
        SceneManager.sceneUnloaded += onSceneUnloaded;
    }
    
    public static void loadScene(int sceneNumber)
    {
        SceneManager.LoadSceneAsync(getSceneName(sceneNumber), LoadSceneMode.Additive);
    }
    
    public static void unLoadScene(int sceneNumber)
    {
        SceneManager.UnloadSceneAsync(getSceneName(sceneNumber));
    }

    // called second
    private static void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scenes.Add(scene);
        // go to loaded scene if needed
        if (goToSceneNumber >= 0 && scene.name == getSceneName(goToSceneNumber))
        {
            moveScene(scene);
            goToSceneNumber = -1;
        }
            
    }
    private static void onSceneUnloaded(Scene scene)
    {
        scenes.Remove(scene);
    }

    private static void moveScene(Scene scene)
    {
        // move player to new scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SceneManager.MoveGameObjectToScene(player, scene);
        
        // activate scene
        SceneManager.SetActiveScene(scene);
        
        // spawn player
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        spawn.GetComponent<Spawn>().spawn(player);
    }
    
    public static void goToScene(int sceneNumber)
    {
        Scene scene = SceneManager.GetSceneByName(getSceneName(sceneNumber));
        if (scene.isLoaded)
        {
            moveScene(scene);
            goToSceneNumber = -1;
        }
    }

    private static String getSceneName(int sceneNumber)
    {
        return "Scene" + sceneNumber;
    }
}
