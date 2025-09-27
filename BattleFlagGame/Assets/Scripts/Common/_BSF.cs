using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ������������㷨
/// </summary>
public class _BFS
{
    //������
    public class Point
    {
        public int RowIndex;//������
        public int ColIndex;//������
        public Point Father;//���ڵ� ��������·��

        public Point(int row, int col)
        {
            this.RowIndex = row;
            this.ColIndex = col;
        }

        public Point(int row, int col, Point father)
        {
            this.RowIndex = row;
            this.ColIndex = col;
            this.Father = father;
        }
    }

    public int RowCount;//������
    public int ColCount;//������

    //�ֵ�ṹ�洢���ҵ��ĵ㣨key:�������ƴ�ӵ��ַ�����value�������㣩
    public Dictionary<string, Point> finds;

    public _BFS(int row, int col)
    {
        finds = new Dictionary<string, Point>();
        this.RowCount = row;
        this.ColCount = col;
    }

    /// <summary>
    /// ������������
    /// </summary>
    /// <param name="row">��ʼ���������</param>
    /// <param name="col">��ʼ���������</param>
    /// <param name="step">����</param>
    /// <returns></returns>
    public List<Point> Search(int row, int col, int step)
    {
        //������������
        List<Point> searchs = new List<Point>();
        //��ʼ��
        Point startPoint = new Point(row, col);
        //����ʼ��洢����������
        searchs.Add(startPoint);
        //��ʼ��Ĭ�Ͽ�ʼ�Ѿ��ҵ����洢���Ѿ��ҵ����ֵ�
        finds.Add($"{row}_{col}", startPoint);

        //�����������൱�ڿ������Ĵ���
        for (int i = 0; i < step; i++)
        {
            //����һ����ʱ�ļ��ϣ����ڴ洢Ŀǰ�ҵ����������ĵ�
            List<Point> temps = new List<Point>();
            //������������
            for (int j = 0; j < searchs.Count; j++)
            {
                Point current = searchs[j];
                //���ҵ�ǰ������Χ�ĵ�
                FindAroundPoints(current, temps);
            }
            if (temps.Count == 0)
            {
                //��ʱ����һ���㶼�Ҳ������൱����·�ˣ�û��Ҫ��������
                break;
            }

            //�����ļ���Ҫ���
            searchs.Clear();

            //����ʱ���ϵĵ���ӵ���������
            searchs.AddRange(temps);
        }
        //�����ҵ��ĵ�ת���ɼ��ϣ�����
        return finds.Values.ToList();
    }

    //����Χ�ĵ� �������ң�������չ����б����ĵ㣩
    public void FindAroundPoints(Point current, List<Point> temps)
    {
        //��
        if (current.RowIndex - 1 >= 0)
        {
            AddFinds(current.RowIndex - 1, current.ColIndex, current, temps);
        }
        //��
        if (current.RowIndex + 1 < RowCount)
        {
            AddFinds(current.RowIndex + 1, current.ColIndex, current, temps);
        }
        //��
        if (current.ColIndex - 1 >= 0)
        {
            AddFinds(current.RowIndex, current.ColIndex - 1, current, temps);
        }
        //��
        if (current.ColIndex + 1 < ColCount)
        {
            AddFinds(current.RowIndex, current.ColIndex + 1, current, temps);
        }
    }

    //��ӵ����ҵ����ֵ�
    public void AddFinds(int row, int col, Point father, List<Point> temps)
    {
        //���ڲ��ҵĽڵ� �� ��Ӧ��ͼ���ӵ����Ʋ����ϰ�����ܼ��룬�����ֵ�
        if (finds.ContainsKey($"{row}_{col}") == false && GameApp.MapManager.GetBlockType(row, col) != BlockType.Obstacle)
        {
            Point p = new Point(row, col, father);

            //��ӵ����ҵ����ֵ�
            finds.Add($"{row}_{col}", p);
            //��ӵ���ʱ���� �����´μ�������
            temps.Add(p);
        }
    }
}