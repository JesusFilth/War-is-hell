//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Core.GameSession;

namespace IJunior.TypedScenes
{
    using UnityEngine.SceneManagement;
    
    
    public class GameLevel : TypedScene
    {
        
        private const string _sceneName = "GameLevel";
        
        public static void Load(GameMode argument, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            LoadScene(_sceneName, loadSceneMode, argument);
        }
        
        public static UnityEngine.AsyncOperation LoadAsync(GameMode argument, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            return LoadScene(_sceneName, loadSceneMode, argument);
        }
    }
}
