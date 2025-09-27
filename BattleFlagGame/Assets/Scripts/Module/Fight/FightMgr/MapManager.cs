using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// ��ͼ������ �洢��ͼ�������Ϣ
/// </summary>
public class MapManager
{
    private Tilemap tileMap;

    public Block[,] mapArr;

    public int RowCount;//��ͼ��
    public int ColCount;//��ͼ��

    //��ʼ����ͼ��Ϣ
    public void Init()
    {
        tileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();

        //��ͼ��С�� ���Խ������Ϣд�����ñ��н�������
        RowCount = 12;
        ColCount = 20;

        mapArr = new Block[RowCount, ColCount];

        List<Vector3Int> tempPosArr = new List<Vector3Int>();//��ʱ��¼��Ƭ��ͼÿ�����ӵ�λ��

        //������Ƭ��ͼ
        foreach (var pos in tileMap.cellBounds.allPositionsWithin)
        {
            if (tileMap.HasTile(pos))
            {
                tempPosArr.Add(pos);
            }
        }

        //��һ�������λ��ת���ɶ�ά�����е�Block���д洢
        Object prefabObj = Resources.Load("Model/block");
        for (int i = 0; i < tempPosArr.Count; i++)
        {
            int row = i / ColCount;
            int col = i % ColCount;
            Block b = (Object.Instantiate(prefabObj) as GameObject).AddComponent<Block>();
            b.RowIndex = row;
            b.ColIndex = col;
            b.transform.position = tileMap.CellToWorld(tempPosArr[i]) + new Vector3(0.5f, 0.5f, 0);
            mapArr[row, col] = b;
        }
    }
    public BlockType GetBlockType(int row, int col)
    {
        return mapArr[row, col].Type;
    }

    //��ʾ�ƶ�������
    public void ShowStepGrid(ModelBase model, int step)
    {
        _BFS bfs = new _BFS(RowCount, ColCount);

        List<_BFS.Point> points = bfs.Search(model.RowIndex, model.ColIndex, step);

        for (int i = 0; i < points.Count; i++)
        {
            mapArr[points[i].RowIndex, points[i].ColIndex].ShowGrid(Color.green);
        }
    }

    //�����ƶ�������
    public void HideStepGrid(ModelBase model, int step)
    {
        _BFS bfs = new _BFS(RowCount, ColCount);

        List<_BFS.Point> points = bfs.Search(model.RowIndex, model.ColIndex, step);

        for (int i = 0; i < points.Count; i++)
        {
            mapArr[points[i].RowIndex, points[i].ColIndex].HideGrid();
        }
    }
}