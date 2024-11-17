using UnityEngine;


namespace march3
{
    
public class GirdManager:MonoBehaviour
{
    public GirdPosition girdPrefab;
    
    
    private const int _width = 15, _height = 20;
    private GirdPosition[,] _grid;

    void Start()
    {
        _grid = new GirdPosition[_width, _height];
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = Instantiate(girdPrefab);
            }
        }
    }

    public GirdPosition Set(GameObject obj, Vector2 position)
    {
        int x = (int)position.x, y = (int)position.y;
        if (x < 0 || x >= _width || y < 0 || y >= _height)
        {
            return null;
        }

        if (_grid[x, y] != null)
        {
            return null;
        }

        if (_grid[x, y].Set(obj))
        {
            return _grid[x, y];
        }

        return null;
    }

    public bool Next()
    {
        for (int i = 0; i < _width; i++)
        {
            if (_grid[_width - 1,i] != null)
            {
                return false;
            }
        }

        for (int i = _height-1; i > 0; i--)
        {
            for (int j = 0; j < _width; j++)
            {
                _grid[i,j]=_grid[i-1,j];
            }
        }

        for (int i = 0; i < _width; i++)
        {
            _grid[0, 1] = null;
        }

        return true;
    }

    public Vector2 NearestGrid(Transform transform)
    {
        return new Vector2(1, 1);
    }
}

}