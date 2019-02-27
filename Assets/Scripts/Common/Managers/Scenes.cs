using System;
using System.Collections.Generic;
using Common.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Managers
{
    public class Scenes : MonoBehaviour
    {
        private static List<Scene> scenes;
        private static int goToSceneNumber = -1;
        public static int currentScene { get; protected set; }

        public static void Init()
        {
            currentScene = -1;
            scenes = new List<Scene>();
            SceneManager.sceneLoaded += onSceneLoaded;
            SceneManager.sceneUnloaded += onSceneUnloaded;
        }
    
        public static void loadScene(int sceneNumber)
        {
            Scene scene = getSceneByNumber(sceneNumber);
            if(!scene.isLoaded)
                SceneManager.LoadSceneAsync(getSceneName(sceneNumber), LoadSceneMode.Additive);
        }
    
        public static void unLoadScene(int sceneNumber)
        {
            Scene scene = getSceneByNumber(sceneNumber);
            if(scene.isLoaded)
                SceneManager.UnloadSceneAsync(getSceneName(sceneNumber));
        }

        // called second
        private static void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if(scenes.Contains(scene))
                return;
            scenes.Add(scene);
            // go to loaded scene if needed
            if (goToSceneNumber >= 0 && scene.name == getSceneName(goToSceneNumber))
            {
                moveScene(scene);
                currentScene = goToSceneNumber;
                goToSceneNumber = -1;
            }
            
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
        
            // activate scene
            SceneManager.SetActiveScene(scene);
            scene.GetRootGameObjects()[0].SetActive(true);
            
            // move player to new scene
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            SceneManager.MoveGameObjectToScene(player, scene);
           
            // spawn player
            GameObject spawn = GameObject.FindGameObjectWithTag("Spawn");
            if(spawn)
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
        
        public static void loadMain()
        {
            foreach(Scene scene in scenes)
            {
                SceneManager.UnloadSceneAsync(scene);
            }

            currentScene = -1;
            SceneManager.UnloadSceneAsync("main");
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }

    }
}
