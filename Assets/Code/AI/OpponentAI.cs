using Code.GameManager;
using UnityEngine;

namespace Code.AI
{
    [CreateAssetMenu]
    public class OpponentAI : ScriptableObject
    {
        [Range(0,1)]
        public float LevelOfDishonesty = 0.5f;

        private Shape[] shapesPool = new Shape[100];
        
        public Shape GetRandomMove()
        {
            System.Array allShapes = System.Enum.GetValues(typeof(Shape));

            return (Shape)allShapes.GetValue(Random.Range(0, allShapes.Length));
        }

        public Shape GetShapeWithPrediction(Shape playerShape)
        {
            GenerateShapesPoolWithDishonestyLevel(LevelOfDishonesty, playerShape);

            return (Shape)shapesPool.GetValue(Random.Range(0, shapesPool.Length));
        }

        private void GenerateShapesPoolWithDishonestyLevel(float dishonesty, Shape targetShape)
        {
            int countOfWinShapes = Mathf.RoundToInt(100 * dishonesty);
            Shape shapeForWin = GetShapeForWin(targetShape);

            for (int i = 0; i < shapesPool.Length; i++)
            {
                if (i < countOfWinShapes)
                {
                    shapesPool[i] = shapeForWin;
                }
                else
                {
                    shapesPool[i] = GetRandomMove();
                }
            }
        }

        private Shape GetShapeForWin(Shape shape)
        {
            int shapeIndex = (int) shape;
            shapeIndex++;
            
            if (shapeIndex == 3)
            {
                shapeIndex = 0;
            }

            return (Shape) shapeIndex;
        }
    }
}
