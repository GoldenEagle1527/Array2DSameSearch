namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Array2DSameSearch sameSearch = new Array2DSameSearch();
            int[,] a =
            {
            { 1,1,6,7,8,3,5},
            { 1,5,5,7,5,7,1},
            { 1,1,7,5,3,7,1},
            { 1,5,5,9,5,7,3},
            { 1,6,9,3,8,0,3}
            };
            Console.WriteLine(sameSearch.StarSameSearch(a, new Vector2(2, 3)));
        }
    }
    class Array2DSameSearch
    {
        /// <summary>
        /// 查找星状路径是否存在相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int StarSameSearch(int[,] array, Vector2 startPos)
            =>HorizontalSameSearch(array, startPos)-1+VerticalSameSearch(array,startPos)-1+DiagonalsSameSearch(array,startPos);
        /// <summary>
        /// 向右查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int RightSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.Y < array.GetLength(1) - 1)
            {
                p += Vector2.right;
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向左查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int LeftSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.Y > 0)
            {
                p += Vector2.left;
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int UpSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X > 0)
            {
                p += Vector2.down;
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int DownSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X < array.GetLength(0) - 1)
            {
                p += Vector2.up;
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向右上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int RightUpSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X > 0 && p.Y < array.GetLength(1))
            {
                p += new Vector2(-1, 1);
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向右下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int RightDownSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X < array.GetLength(0) && p.Y < array.GetLength(1))
            {
                p += new Vector2(1, 1);
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向左上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int LeftUpSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X > 0 && p.Y > 0)
            {
                p += new Vector2(-1, -1);
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 向左下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int LeftDownSameSearch(int[,] array, Vector2 startPos)
        {
            int count = 1;
            Vector2 p = startPos;
            while (p.X < array.GetLength(0) && p.Y > 0)
            {
                p += new Vector2(1, -1);
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
        /// <summary>
        /// 横轴相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int HorizontalSameSearch(int[,] array, Vector2 startPos)
            => LeftSameSearch(array, startPos) + RightSameSearch(array, startPos) - 1;
        /// <summary>
        /// 纵轴相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int VerticalSameSearch(int[,] array, Vector2 startPos)
            => UpSameSearch(array, startPos) + DownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 右对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int DiagonalRightSameSearch(int[,] array, Vector2 startPos)
            => RightUpSameSearch(array, startPos) + RightDownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 左对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int DiagonalLeftSameSearch(int[,] array, Vector2 startPos)
            => LeftUpSameSearch(array, startPos) + LeftDownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public int DiagonalsSameSearch(int[,] array, Vector2 startPos)
            => DiagonalLeftSameSearch(array, startPos) + DiagonalRightSameSearch(array, startPos) - 1;
    }
    /// <summary>
    /// 自定义2维向量,如果在Unity中使用,需删除此类
    /// </summary>
    class Vector2
    {
        public int X, Y;
        public Vector2(int x, int y) { X = x; Y = y; }
        public static readonly Vector2 right = new(0, 1);
        public static readonly Vector2 left = new(0, -1);
        public static readonly Vector2 up = new(1, 0);
        public static readonly Vector2 down = new(-1, 0);
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
    }
}