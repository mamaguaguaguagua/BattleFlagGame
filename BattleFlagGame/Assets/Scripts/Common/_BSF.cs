using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//������������㷨
public class _BFS
{
    //������
    public class Point
    {
        public int RowIndex;//������
        public int ColIndex;//������
        public Point Father;//���ڵ� ��������·��
        public Point(int row, int column)
        {
            this.RowIndex = row;
            this.ColIndex = column;
        }
        public Point(int row, int column, Point father)
        {
            this.RowIndex = row;
            this.ColIndex = column;
            this.Father = father;
        }
    }

    public int RowCount;//������
    public int ColumnCount;//������

    public Dictionary<string, Point> finds;//�洢���ҵ��ĵ���ֵ�(key:�������ƴ�ӵ��ַ���,value:������)

    public _BFS(int row, int col)
    {
        finds = new Dictionary<string, Point>();
        this.RowCount = row;
        this.ColumnCount = col;
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
        //��ʼ��Ĭ�Ͽ�ʼ�Ѿ��ҵ�,�洢���Ѿ��ҵ����ֵ�
        finds.Add($"{row}_{col}", startPoint);

        //��������,�൱�ڿ������Ĵ���
        for (int i = 0; i < step; i++)
        {
            //����һ����ʱ�ļ���,���ڴ洢Ŀǰ�ҵ����������ĵ�
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
                //��ʱ����һ���㶼�Ҳ��� �൱����·��,û��Ҫ����������
                break;
            }
            //�����ļ���Ҫ���
            searchs.Clear();
            //����ʱ���ϵĵ���ӵ���������
            searchs.AddRange(temps);
        }

        //�����ҵ��ĵ�ת��Ϊ���� ����
        return finds.Values.ToList();
    }
    //����Χ�ĵ� �������� (������չ����б����ĵ�)
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
        if (current.ColIndex + 1 < ColumnCount)
        {
            AddFinds(current.RowIndex, current.ColIndex + 1, current, temps);
        }
    }
    //��ӵ����ҵ����ֵ�
    public void AddFinds(int row, int col, Point father, List<Point> temps)
    {
        //���ڲ��ҵĽڵ� �� ��Ӧ��ͼ���ӵ����Ͳ����ϰ��� ���ܼ��� �����ֵ�
        if (finds.ContainsKey($"{row}_{col}") == false && GameApp.MapManager.GetBlockType(row, col) != BlockType.Obstacle)
        {
            Point p = new Point(row, col, father);
            //��ӵ����ҵ����ֵ�
            finds.Add($"{row}_{col}", p);
            //��ӵ���ʱ����,�����´μ�������
            temps.Add(p);
        }
    }

    //Ѱ�ҿ��ƶ��ĵ� ���յ�����ĵ��·������
    public List<Point> FindMinPath(ModelBase model, int step, int endRowIndex, int endColIndex)
    {
        List<Point> results = Search(model.RowIndex, model.ColIndex, step);//������ƶ��ĵ�ļ���
        if (results.Count == 0)
        {
            return null;
        }
        else
        {
            Point minPoint = results[0];//Ĭ��һ����Ϊ��Ŀ���������
            int min_dis = Mathf.Abs(minPoint.RowIndex - endRowIndex) + Mathf.Abs(minPoint.ColIndex - endColIndex);
            for (int i = 1; i < results.Count; i++)
            {
                int temp_dis = Mathf.Abs(results[i].RowIndex - endRowIndex) + Mathf.Abs(results[i].ColIndex - endColIndex);
                if (temp_dis < min_dis)
                {
                    min_dis = temp_dis;
                    minPoint = results[i];
                }
            }

            List<Point> paths = new List<Point>();
            Point current = minPoint.Father;
            paths.Add(minPoint);

            while (current != null)
            {
                paths.Add(current);
                current = current.Father;
            }
            paths.Reverse();//����
            return paths;
        }
    }

}
