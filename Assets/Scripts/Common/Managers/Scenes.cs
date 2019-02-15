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
    private static int currentScene = -1;

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
            currentScene = goToSceneNumber;
            goToSceneNumber = -1;
        }
        else
            scene.GetRootGameObjects()[0].SetActive(false);
            
    }
    private static void onSceneUnloaded(Scene scene)
    {
        scenes.Remove(scene);
    }

    private static void moveScene(Scene scene)
    {
        // hide old scene
        Scene oldScene = getSceneByNumber(currentScene);
        oldScene.GetRootGameObjects()[0].SetActive(false);
        
        // move player to new scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
            SceneManager.MoveGameObjectToScene(player, scene);
        
        // activate scene
        SceneManager.SetActiveScene(scene);
        scene.GetRootGameObjects()[0].SetActive(true);
        
        // spawn player
        GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
        spawn.GetComponent<Spawn>().spawn(player);
        

    }
    
    public static void goToScene(int sceneNumber)
    {
        Scene scene = getSceneByNumber(sceneNumber);
        if (scene.isLoaded)
        {
            moveScene(scene);
            currentScene = sceneNumber;
            goToSceneNumber = -1;
        }
        else
            goToSceneNumber = sceneNumber;
    }

    private static String getSceneName(int sceneNumber)
    {
        if (sceneNumber < 0)
            return "main";
        return "Scene" + sceneNumber;
    }

    private static Scene getSceneByNumber(int sceneNumber)
    {
        return SceneManager.GetSceneByName(getSceneName(sceneNumber));
    }
}
