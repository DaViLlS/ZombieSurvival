using UnityEngine;

namespace _Project.Development.Core.UIBase
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private string id;
        
        protected UISystem UiSystem;
        
        public string Id => id;

        public virtual void Initialize(UISystem uiSystem)
        {
            UiSystem = uiSystem;
        }
        
        public abstract void Show();
        public abstract void Hide();
    }
}