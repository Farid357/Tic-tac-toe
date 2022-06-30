using UnityEngine;

namespace SceneLogic
{
    public sealed class SceneLoader : MonoBehaviour, ILoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private ScreenFade _screen;
        private ILoader _loaders;

        public void Exit()
        {
            Application.Quit();
        }

        private void Start()
        {
            _loaders = new FadeLoader(_screen);
        }

        public void Load(int sceneIndex)
        {
            _loaders.Load(sceneIndex);
        }
    }

    public enum SceneLoadMode
    {
        Fade
    }

    public interface ILoader
    {
        public void Load(int sceneIndex);
    }
}
