using System.Collections.Generic;
using UnityEngine;

namespace _Project.Development.Core.PersonsCore
{
    public class BasePerson : MonoBehaviour
    {
        [SerializeField] private List<Transform> visiblePoints;
        
        public List<Transform> VisiblePoints => visiblePoints;
    }
}