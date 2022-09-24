using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " new PlaceableItem", menuName = "Item/PlaceableItem")]
public class PlacedObjectTypeSO : ScriptableObject
{
    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
        }
    }

    public enum Dir
    {
        Down,
        Left,
        Up,
        Right,
    }

    public string nameString;
    public Transform prefab; 
    public int length;
    public int height;

    [SerializeField] private bool canRotate;

    public int GetRotationAngle(Dir dir)
    {
        if (canRotate)
        {
            switch (dir)
            {
                default:
                case Dir.Down: 
                    return 0;
                case Dir.Left: 
                    return 90;
                case Dir.Up: 
                    return 180;
                case Dir.Right: 
                    return 270;
            }
        }
        return 0;
    }

    public Vector2Int GetRotationOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down:
                //try { prefab = prefabRotationModels[0]; } catch { Debug.LogError("No rotated model"); }
                return new Vector2Int(0, 0);
            case Dir.Left:
                //try { prefab = prefabRotationModels[1]; } catch { Debug.LogError("No rotated model"); }
                return new Vector2Int(0, length);
            case Dir.Up:
                //try { prefab = prefabRotationModels[2]; } catch { Debug.LogError("No rotated model"); }
                return new Vector2Int(length, height);
            case Dir.Right:
                //try { prefab = prefabRotationModels[3]; } catch { Debug.LogError("No rotated model"); }
                return new Vector2Int(height, 0);
        }
    }

    //Offset is where in coordinate system building is placed
    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();

        if (canRotate) dir = Dir.Down;

        switch (dir)
        {
            default:
            case Dir.Down:  
            case Dir.Up:
                for (int x = 0; x < length; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
            case Dir.Left:
            case Dir.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < length; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
        }
        return gridPositionList;
    }
}
