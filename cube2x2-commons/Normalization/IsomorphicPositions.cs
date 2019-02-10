namespace Grayscale.Cube2X2Commons
{
    using System.Collections.Generic;

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
            this.Phase = new IsomorphicPosition[Order];
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
        public IsomorphicPosition[] Phase { get; private set; }

        /// <summary>
        /// 生成。
        /// </summary>
        /// <param name="onePosition">同型局面のうち、どれか１つの局面。</param>
        /// <returns>同型のすべての局面。</returns>
        public static IsomorphicPositions Parse(Position onePosition)
        {
            var result = new IsomorphicPositions();

            // １回目は、仮に24局面作成する。
            result.CreateAllIsomorphic(onePosition);

            // 基準局面を取得する。
            var normalizedPosition = result.Normalize();

            // 確認表示。
            System.Diagnostics.Trace.WriteLine(string.Format(
                System.Globalization.CultureInfo.CurrentCulture,
                "^ NormalizedPosition: `{0}`.",
                normalizedPosition.BoardText));

            // 基準局面を使って、24局面作成する。
            result.CreateAllIsomorphic(normalizedPosition);

            // 局面文字列を作成する。
            var isomorphicText = new string[IsomorphicPositions.Order];
            for (int i = 0; i < IsomorphicPositions.Order; i++)
            {
                isomorphicText[i] = result.Phase[i].Position.BoardText;
            }

            // 確認表示。
            for (int i = 0; i < IsomorphicPositions.Order; i++)
            {
                System.Diagnostics.Trace.WriteLine(string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "^ {0}: {1} IndexOf {2}.",
                    i,
                    isomorphicText[i],
                    result.IndexOf(Position.Parse(isomorphicText[i]))));
            }

            // 辞書順ソートする。
            System.Array.Sort(isomorphicText);

            // 確認表示。
            for (int i = 0; i < IsomorphicPositions.Order; i++)
            {
                System.Diagnostics.Trace.WriteLine(string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "+ {0}: {1} IndexOf {2}.",
                    i,
                    isomorphicText[i],
                    result.IndexOf(Position.Parse(isomorphicText[i]))));
            }

            // 辞書順ソートに合わせて、配列の要素を並び替える。
            for (int phaseExpected = 0; phaseExpected < IsomorphicPositions.Order; phaseExpected++)
            {
                var phaseActual = result.IndexOf(Position.Parse(isomorphicText[phaseExpected]));

                result.Swap(phaseExpected, phaseActual);
            }

            // 確認表示。
            for (var i = 0; i < IsomorphicPositions.Order; i++)
            {
                var phaseBoardText = result.Phase[i].Position.BoardText;
                System.Diagnostics.Trace.WriteLine(string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "- {0}: {1} IndexOf {2}.",
                    i,
                    phaseBoardText,
                    result.IndexOf(Position.Parse(phaseBoardText))));
            }

            return result;
        }

        /// <summary>
        /// 同型のうち、基準の１つを選んで返す。
        /// </summary>
        /// <returns>局面と、回す箇所。</returns>
        public Position Normalize()
        {
            // 辞書順に並んでいる。
            return this.Phase[0].Position;
        }

        /// <summary>
        /// 同型要素番号を取得。
        /// </summary>
        /// <param name="onePosition">同型局面のうち、どれか１つの局面。</param>
        /// <returns>同型要素番号。無ければ -1。</returns>
        public int IndexOf(Position onePosition)
        {
            var onePositionText = onePosition.BoardText;

            // 一致する同型番号を取得。
            var phase = 0;
            var successful = false;
            for (; phase < IsomorphicPositions.Order; phase++)
            {
                var phaseBoardText = this.Phase[phase].Position.BoardText;

                if (phaseBoardText == onePositionText)
                {
                    successful = true;
                    break;
                }
            }

            if (!successful)
            {
                return -1;
            }

            return phase;
        }

        /// <summary>
        /// 代表局面のボタン グループが 昇順に並んでいるものとして、
        /// 同型のうち、ある１つの局面について、ボタン グループを返す。
        /// </summary>
        /// <param name="onePosition">同型局面のうち、どれか１つの局面。</param>
        /// <returns>局面と、回す箇所。</returns>
        public RotateButtonGroup ExchangeRotateButtonGroup(Position onePosition)
        {
            var phase = this.IndexOf(onePosition);

            if (phase == -1)
            {
                throw new MyApplicationException("Not found isomorphic.");
            }

            // ボタングループを回します。
            var rotateButtonGroup = new RotateButtonGroup();

            foreach (var direction in this.Phase[phase].DirectionList)
            {
                switch (direction)
                {
                    case Direction.PlusX:
                        // +X
                        rotateButtonGroup.RotateView(2);
                        break;
                    case Direction.PlusY:
                        // +Y
                        rotateButtonGroup.RotateView(0);
                        break;
                    case Direction.PlusZ:
                        // +Z
                        rotateButtonGroup.RotateView(1);
                        break;
                    default:
                        // エラー。
                        return null;
                }
            }

            return rotateButtonGroup;
        }

        /// <summary>
        /// 入れ替える。
        /// </summary>
        /// <param name="phaseA">要素番号A。</param>
        /// <param name="phaseB">要素番号B。</param>
        private void Swap(int phaseA, int phaseB)
        {
            IsomorphicPosition temp = this.Phase[phaseB];
            this.Phase[phaseB] = this.Phase[phaseA];
            this.Phase[phaseA] = temp;
        }

        /// <summary>
        /// 24個の同型局面を作成する。
        /// </summary>
        /// <param name="sourcePosition">元となる局面。</param>
        private void CreateAllIsomorphic(Position sourcePosition)
        {
            int phase = 0;

            // 色は関係ない。
            for (int secondRotation = 0; secondRotation < 4; secondRotation++)
            {
                for (int firstRotation = 0; firstRotation < 6; firstRotation++)
                {
                    this.Phase[phase] = this.CreateIsomorphic(sourcePosition, firstRotation, secondRotation);
                    phase++;

                    // Console.WriteLine("isomorphicIndex: " + isomorphicIndex);
                }
            }
        }

        /// <summary>
        /// 同型を作ります。
        /// </summary>
        /// <param name="sourcePosition">元となる局面。</param>
        /// <param name="firstRotation">最初の6面のうちの1つ。</param>
        /// <param name="secondRotation">次の4面のうちの1つ。</param>
        /// <returns>局面。</returns>
        private IsomorphicPosition CreateIsomorphic(Position sourcePosition, int firstRotation, int secondRotation)
        {
            var pos = Position.Clone(sourcePosition);
            var directionList = new List<Direction>();

            // 色は関係ない。
            switch (firstRotation)
            {
                case 0:
                    // そのまま。
                    break;

                case 1:
                    // +X に1回 倒す。
                    pos.RotateView(2);
                    directionList.Add(Direction.PlusX);
                    break;

                case 2:
                    // +X に1回 倒す。
                    pos.RotateView(2);
                    directionList.Add(Direction.PlusX);

                    // +Z に1回 回す。
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    break;

                case 3:
                    // +X に1回 倒す。
                    pos.RotateView(2);
                    directionList.Add(Direction.PlusX);

                    // +Z に2回 回す。
                    pos.RotateView(1);
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    break;

                case 4:
                    // +X に1回 倒す。
                    pos.RotateView(2);
                    directionList.Add(Direction.PlusX);

                    // +Z に3回 回す。
                    pos.RotateView(1);
                    pos.RotateView(1);
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    break;

                case 5:
                    // +X に2回 倒す。
                    pos.RotateView(2);
                    pos.RotateView(2);
                    directionList.Add(Direction.PlusX);
                    directionList.Add(Direction.PlusX);
                    break;

                default:
                    // エラー。
                    return null;
            }

            // 色は関係ない。
            switch (secondRotation)
            {
                case 0:
                    // そのまま。
                    break;

                case 1:
                    // +Z に1回 回す。
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    break;

                case 2:
                    // +Z に2回 回す。
                    pos.RotateView(1);
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    break;

                case 3:
                    // +Z に3回 回す。
                    pos.RotateView(1);
                    pos.RotateView(1);
                    pos.RotateView(1);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    directionList.Add(Direction.PlusZ);
                    break;

                default:
                    // エラー。
                    return null;
            }

            return new IsomorphicPosition(pos, directionList);
        }
    }
}
