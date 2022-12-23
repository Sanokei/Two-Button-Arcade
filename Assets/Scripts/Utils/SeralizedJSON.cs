using UnityEngine;
using UnityEditor;

namespace SeralizedJSONSystem{
    public static class SeralizedJSON<T> where T : ScriptableObject
    {
        // adding JSON Serialization (copy + paste from texticon.cs)
        internal static void LoadFromJSON(string path, out T instance){
            instance = ScriptableObject.CreateInstance<T>();
            JsonUtility.FromJsonOverwrite(System.IO.File.ReadAllText(path), instance);
            instance.hideFlags = HideFlags.HideAndDontSave;
        }

        internal static void LoadFromResources(string filename, out T instance){
            instance = (T)Resources.Load(filename);
            instance.hideFlags = HideFlags.HideAndDontSave;
        }
        internal static void SaveToJSON(T obj, string path) {
            System.IO.File.WriteAllText(path, JsonUtility.ToJson(obj, true));
        }

        // public
        public static void LoadScriptableObject(string filename, out T _instance)
        {
            string jsonPath = System.IO.Path.Combine(Application.persistentDataPath,UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,$"{filename}.json");
            string resourcesPath = "Computer/Icon/" + filename;

            T instance = ScriptableObject.CreateInstance<T>();
            if (System.IO.File.Exists(jsonPath))
            {
                LoadFromJSON(jsonPath, out _instance);
            }
            else
            {
                try
                {
                    Debug.LogError($"Could not load {typeof(T)} from ({jsonPath})\nLoading most recent from {resourcesPath} instead.");
                    LoadFromResources(resourcesPath, out _instance);
                }
                catch(System.Exception e)
                {
                    Debug.LogAssertion($"No {typeof(T)} file found.\n{e.Message}");
                    _instance = null;
                }
            }
        }
        
        public static void SaveScriptableObject(T scriptableObject, string filename) {
            string jsonPath = System.IO.Path.Combine(Application.persistentDataPath,UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,$"{filename}.json");
            SaveToJSON(scriptableObject, jsonPath);
        }
    }
}