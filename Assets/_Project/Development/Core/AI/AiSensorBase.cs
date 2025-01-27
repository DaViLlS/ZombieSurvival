using _Project.Development.Core.PersonsCore;

namespace _Project.Development.Core.AI
{
    public class AiSensorBase
    {
        public bool DetectTarget<T>(T unity) where T : BasePerson
        {
            return true;
        }
    }
}