using Code.GameManager;
using UnityEngine;

namespace Code.AI
{
    [CreateAssetMenu]
    public class OpponentAI : ScriptableObject
    {
        public Shape GetRandomMove()
        {
            System.Array allShapes = System.Enum.GetValues(typeof(Shape));

            return (Shape)allShapes.GetValue(Random.Range(0, allShapes.Length));
        }
    }
}
