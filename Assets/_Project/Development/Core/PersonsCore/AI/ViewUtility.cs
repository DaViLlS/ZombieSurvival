using UnityEngine;

namespace _Project.Development.Core.PersonsCore.AI
{
    public static class ViewUtility
    {
        public static bool IsVisibleUnit<T>(T unit, Transform from, float angle, float distance, LayerMask mask) where T : BasePerson
        {
            var result = false;
            
            if (unit != null)
            {
                foreach (var visiblePoint in unit.VisiblePoints)
                {
                    if (IsVisibleObject(from, visiblePoint.position, unit.gameObject, angle, distance, mask))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        
        public static bool IsVisibleObject(Transform from, Vector3 point, GameObject target, float angle, float distance, LayerMask mask)
        {
            bool result = false;
            
            if (IsAvailablePoint(from, point, angle, distance))
            {
                var direction = point - from.position;
                var ray = new Ray(from.position, direction);
                
                if (Physics.Raycast(ray, out var hit, distance, mask.value))
                {
                    if (hit.collider.gameObject == target)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        
        public static bool IsAvailablePoint(Transform from, Vector3 point, float angle, float distance)
        {
            var result = false;

            if (from != null && Vector3.Distance(from.position, point) <= distance)
            {
                var direction = point - from.position;
                var dot = Vector3.Dot(from.forward, direction.normalized);
                
                if (dot < 1)
                {
                    var angleRadians = Mathf.Acos(dot);
                    var angleDeg = angleRadians * Mathf.Rad2Deg;
                    result = angleDeg <= angle;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }
    }
}