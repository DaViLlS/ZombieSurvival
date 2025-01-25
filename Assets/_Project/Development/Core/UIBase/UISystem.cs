using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Development.Core.UIBase
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private List<Window> windows;
        [SerializeField] private List<Popup> popups;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            foreach (var window in windows)
            {
                window.Initialize(this);
            }
        }
        
        public void ShowWindow(string id)
        {
            windows.First(x => x.Id == id).Show();
        }

        public void HideWindow(string id)
        {
            windows.First(x => x.Id == id).Hide();
        }
    }
}