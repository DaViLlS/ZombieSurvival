using System;
using _Project.Development.Core.PersonsCore.AI;
using _Project.Development.ZombieSurvivalCore.Persons.MainCharacter;
using UnityEngine;
using Zenject;

namespace _Project.Development.ZombieSurvivalCore.Persons.NPCs.Enemies
{
    public class EnemyVision : MonoBehaviour
    {
        public event Action OnCharacterDetected;
        
        [Inject] private Character character;
        
        [SerializeField] private Transform currentEyes;
        [SerializeField] private float visibleAngle;
        [SerializeField] private float visibleDistance;
        [SerializeField] private LayerMask visibleMask;
        
        /*public virtual List<T> GetVisibleUnits<T>(Comparer<T> comparer) where T : BasePerson
        {
            List<T> result = new List<T>();
            
            foreach (T unit in UnitsManager.Instance.GetUnits<T>())
            {
                if (unit != null && unit != this.unit && unit.enabled && comparer(unit) && IsVisibleUnit(unit))
                {
                    result.Add(unit);
                }
            }
            
            return result;
        }*/

        private void FixedUpdate()
        {
            if (IsCharacterVisible())
            {
                OnCharacterDetected?.Invoke();
            }
        }

        public virtual bool IsCharacterVisible()
        {
            bool result = ViewUtility.IsVisibleUnit(character, currentEyes, visibleAngle, visibleDistance, visibleMask);
// SENSORS        
            /*if (!result)
            {

                foreach (AiSensorBase sensor in sensors)
                {
                    if (sensor != null)
                    {
                        if (sensor.DetectTarget<T>(unit))
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }*/
// END SENSORS
            return result;
        }
    }
}