namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a =
            {
            { 1,5,6,5,8,5,5},
            { 1,5,5,5,5,7,1},
            { 0,1,7,5,3,7,1},
            { 1,5,5,5,5,7,3},
            };
            Array.Sort(a);
            Console.WriteLine(Array2DSameSearch.StarSameSearch(a, new Vector2(2, 3)));
        }
    }
    class Array2DSameSearch
    {
        /// <summary>
        /// 查找星状路径是否存在相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int StarSameSearch(int[,] array, Vector2 startPos)
            => HorizontalSameSearch(array, startPos) - 1 + VerticalSameSearch(array, startPos) - 1 + DiagonalsSameSearch(array, startPos);
        /// <summary>
        /// 向右查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int RightSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, Vector2.right, new Vector2(0, array.GetLength(1) - 1), (x, y) => x.Y < y.Y);
        /// <summary>
        /// 向左查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int LeftSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, Vector2.left, Vector2.zero, (x, y) => x.Y > 0);
        /// <summary>
        /// 向上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int UpSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, Vector2.down, Vector2.zero, (x, y) => x.X > 0);
        /// <summary>
        /// 向下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int DownSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, Vector2.up, new Vector2(array.GetLength(0) - 1, 0), (x, y) => x.X < y.X);
        /// <summary>
        /// 向右上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int RightUpSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, new Vector2(-1,1), new Vector2(0, array.GetLength(1) - 1), (x, y) => x.X > 0 && x.Y < y.Y);
        /// <summary>
        /// 向右下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int RightDownSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, new Vector2(1,1), new Vector2(array.GetLength(0) - 1, array.GetLength(1)-1), (x, y) => x.X < y.X && x.Y < y.Y);
        /// <summary>
        /// 向左上查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int LeftUpSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, new Vector2(-1,-1), Vector2.zero, (x, y) => x.X > 0 && x.Y > 0);
        /// <summary>
        /// 向左下查找相同元素
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int LeftDownSameSearch(int[,] array, Vector2 startPos)
            => LoopBody(array, startPos, new Vector2(1,-1), new Vector2(array.GetLength(0) - 1, 0), (x, y) => x.X < y.X && x.Y > 0);
        /// <summary>
        /// 横轴相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int HorizontalSameSearch(int[,] array, Vector2 startPos)
            => LeftSameSearch(array, startPos) + RightSameSearch(array, startPos) - 1;
        /// <summary>
        /// 纵轴相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int VerticalSameSearch(int[,] array, Vector2 startPos)
            => UpSameSearch(array, startPos) + DownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 右对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int DiagonalRightSameSearch(int[,] array, Vector2 startPos)
            => RightUpSameSearch(array, startPos) + RightDownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 左对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int DiagonalLeftSameSearch(int[,] array, Vector2 startPos)
            => LeftUpSameSearch(array, startPos) + LeftDownSameSearch(array, startPos) - 1;
        /// <summary>
        /// 对角线相同元素寻找
        /// </summary>
        /// <returns>相同个数(包含本体)</returns>
        public static int DiagonalsSameSearch(int[,] array, Vector2 startPos)
            => DiagonalLeftSameSearch(array, startPos) + DiagonalRightSameSearch(array, startPos) - 1;
        private static int LoopBody(int[,] array, Vector2 startPos, Vector2 searchDir, Vector2 comparisonValue, Func<Vector2, Vector2, bool> loopCondition)
        {
            int count = 1;
            Vector2 p = startPos;
            while (loopCondition(p, comparisonValue))
            {
                p += searchDir;
                if (array[p.X, p.Y] == array[startPos.X, startPos.Y])
                    count++;
                else break;
            }
            return count;
        }
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
        public static readonly Vector2 zero = new(0, 0);
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }
    }
}
