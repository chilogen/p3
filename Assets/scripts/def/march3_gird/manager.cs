using Unity.VisualScripting;
using UnityEngine;


namespace march3
{

    public class GirdManager
    {


        private const int Width = 15, Height = 23;
        private  GridPoint[,] _grid;
        public static readonly GirdManager Instance = new ();

        public void Init()
        {
            _grid = new GridPoint[Height, Width];
            var prefab = Resources.Load("march3/position_point");
            if (prefab == null)
            {
                Debug.Log("Prefab loaded error");
                return;
            }

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    _grid[y,x] = Object.Instantiate(prefab,new Vector3(-10*y,-12,10*x),Quaternion.identity).GetComponent<GridPoint>();
                }
            }
        }

        public GridPoint GetGirdPoint(Vector2 position)
        {
            int x = (int)position.x, y = (int)position.y;
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null;
            }

            return _grid[y, x];
        }

        public bool Next()
        {
            //failed on final line have obj
            for (var i = 0; i < Width; i++)
            {
                if (_grid[Height-1,i] .Occupy()!= null)
                {
                    return false;
                }
            }

            //move obj to next line
            for (var i = Height - 1; i > 0; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    _grid[i,j].SwapSon(_grid[i-1,j]);
                }
            }

            //new first line
            for (var i = 0; i < Width; i++)
            {
                _grid[0,i].RemoveSon();
                var newPie = PieObjPool.Instance.Get(null);
                _grid[0,i].SetSon(newPie);
            }

            return true;
        }

        public Vector2 NearestGrid(Transform transform)
        {
            return new Vector2(1, 1);
        }
    }
}