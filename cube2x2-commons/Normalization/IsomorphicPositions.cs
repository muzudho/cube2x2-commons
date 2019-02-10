namespace Grayscale.Cube2X2Commons
{
    /// <summary>
    /// 24個の同型の局面。
    /// </summary>
    public class IsomorphicPositions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsomorphicPositions"/> class.
        /// </summary>
        private IsomorphicPositions()
        {
            this.Phase = new Position[Order];
            this.HandX = new int[Order];
            this.HandY = new int[Order];
            this.HandZ = new int[Order];
        }

        /// <summary>
        /// Gets 同型の局面数。
        /// </summary>
        public static int Order
        {
            get
            {
                return 6 * 4;
            }
        }

        /// <summary>
        /// Gets 同型の局面は 24個。
        /// </summary>
        public Position[] Phase { get; private set; }

        /// <summary>
        /// Gets 持ち替え。X方向に 90°回した回数。
        /// </summary>
        public int[] HandX { get; private set; }

        /// <summary>
        /// Gets 持ち替え。Y方向に 90°回した回数。
        /// </summary>
        public int[] HandY { get; private set; }

        /// <summary>
        /// Gets 持ち替え。Z方向に 90°回した回数。
        /// </summary>
        public int[] HandZ { get; private set; }

        /// <summary>
        /// 生成。
        /// </summary>
        /// <param name="sourcePosition">元となる局面。</param>
        /// <returns>同型の局面。</returns>
        public static IsomorphicPositions Parse(Position sourcePosition)
        {
            var result = new IsomorphicPositions();

            result.CreateAllIsomorphic(sourcePosition);

            return result;
        }

        /// <summary>
        /// 正規化をする。
        /// つまり、24個の局面を作り、そのうち代表的な１つを選ぶ。
        /// </summary>
        /// <param name="handle">回す箇所。</param>
        /// <returns>局面と、回す箇所。</returns>
        public (Position, int) Normalize(int handle)
        {
            // 局面文字列を作成する。
            var isomorphicText = new string[IsomorphicPositions.Order];
            for (int i = 0; i < IsomorphicPositions.Order; i++)
            {
                isomorphicText[i] = this.Phase[i].BoardText;
            }

            // 辞書順ソートする。
            System.Array.Sort(isomorphicText);

            /*
            // 確認表示。
            for (int i = 0; i < StateSize; i++)
            {
                Trace.WriteLine(string.Format(
                    CultureInfo.CurrentCulture,
                    "{0} {1}",
                    i,
                    isomorphicText[i]));
            }
            */

            // 代表の局面。
            var normalizedBoardText = isomorphicText[0];

            // 何番目のものか。
            int normalizedIndex = 0;
            for (; normalizedIndex < IsomorphicPositions.Order; normalizedIndex++)
            {
                if (normalizedBoardText == isomorphicText[normalizedIndex])
                {
                    break;
                }
            }

            // 今回 回そうと思っていたハンドルを変更します。
            var normalizedHandle = this.RotateHand(normalizedIndex, handle);

            return (Position.Parse(normalizedBoardText), normalizedHandle);
        }

        /// <summary>
        /// 24個の同型局面を作成する。
        /// </summary>
        /// <param name="sourcePosition">元となる局面。</param>
        private void CreateAllIsomorphic(Position sourcePosition)
        {
            int isomorphicIndex = 0;

            // 色は関係ない。
            for (int firstRotation = 0; firstRotation < 6; firstRotation++)
            {
                for (int secondRotation = 0; secondRotation < 4; secondRotation++)
                {
                    this.Phase[isomorphicIndex] = this.CreateIsomorphic(sourcePosition, isomorphicIndex, firstRotation, secondRotation);
                    isomorphicIndex++;

                    // Console.WriteLine("isomorphicIndex: " + isomorphicIndex);
                }
            }
        }

        /// <summary>
        /// 同型を作ります。
        /// </summary>
        /// <param name="sourcePosition">元となる局面。</param>
        /// <param name="isomorphicIndex">同型の要素番号。</param>
        /// <param name="firstRotation">最初の6面のうちの1つ。</param>
        /// <param name="secondRotation">次の4面のうちの1つ。</param>
        /// <returns>局面。</returns>
        private Position CreateIsomorphic(Position sourcePosition, int isomorphicIndex, int firstRotation, int secondRotation)
        {
            var position = Position.Clone(sourcePosition);

            // 色は関係ない。
            switch (firstRotation)
            {
                case 0:
                    // そのまま。
                    break;

                case 1:
                    // +X に1回 倒す。
                    position.RotateView(2);
                    this.HandX[isomorphicIndex] += 1;
                    break;

                case 2:
                    // +X に1回 倒す。
                    position.RotateView(2);
                    this.HandX[isomorphicIndex] += 1;

                    // +Z に1回 回す。
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 1;
                    break;

                case 3:
                    // +X に1回 倒す。
                    position.RotateView(2);
                    this.HandX[isomorphicIndex] += 1;

                    // +Z に2回 回す。
                    position.RotateView(1);
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 2;
                    break;

                case 4:
                    // +X に1回 倒す。
                    position.RotateView(2);
                    this.HandX[isomorphicIndex] += 1;

                    // +Z に3回 回す。
                    position.RotateView(1);
                    position.RotateView(1);
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 3;
                    break;

                case 5:
                    // +X に2回 倒す。
                    position.RotateView(2);
                    position.RotateView(2);
                    this.HandX[isomorphicIndex] += 2;
                    break;

                default:
                    break;
            }

            // 色は関係ない。
            switch (secondRotation)
            {
                case 0:
                    break;

                case 1:
                    // +Z に1回 回す。
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 1;
                    break;

                case 2:
                    // +Z に2回 回す。
                    position.RotateView(1);
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 2;
                    break;

                case 3:
                    // +Z に3回 回す。
                    position.RotateView(1);
                    position.RotateView(1);
                    position.RotateView(1);
                    this.HandZ[isomorphicIndex] += 3;
                    break;

                default:
                    break;
            }

            return position;
        }

        /// <summary>
        /// 今回 回そうと思っていたハンドルを変更します。
        /// </summary>
        /// <param name="isomorphicIndex">同型の要素番号。</param>
        /// <param name="handle">回す箇所。</param>
        /// <returns>視角を変えたあとの、回す箇所。</returns>
        private int RotateHand(int isomorphicIndex, int handle)
        {
            var rotateButtonGroup = new RotateButtonGroup();
            for (int iView = 0; iView < this.HandX[isomorphicIndex]; iView++)
            {
                // +X
                rotateButtonGroup.RotateView(2);
            }

            for (int iView = 0; iView < this.HandY[isomorphicIndex]; iView++)
            {
                // +Y
                rotateButtonGroup.RotateView(0);
            }

            for (int iView = 0; iView < this.HandZ[isomorphicIndex]; iView++)
            {
                // +Z
                rotateButtonGroup.RotateView(1);
            }

            // 視角を変えたので、対応するハンドルの位置が変わる。
            return rotateButtonGroup.LabelArray[handle];
        }
    }
}
