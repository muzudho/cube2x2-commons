namespace Grayscale.Cube2X2Commons
{
    using System.Collections.Generic;

    /// <summary>
    /// 同型の局面。
    /// </summary>
    public class IsomorphicPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IsomorphicPosition"/> class.
        /// </summary>
        /// <param name="position">局面。</param>
        /// <param name="directionList">持ち替えた順序。</param>
        public IsomorphicPosition(
            Position position,
            List<Direction> directionList)
        {
            this.Position = position;
            this.DirectionList = directionList;
        }

        /// <summary>
        /// Gets 同型の局面は 24個。
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// Gets 持ち替えた順序。
        /// </summary>
        public List<Direction> DirectionList { get; private set; }
    }
}
