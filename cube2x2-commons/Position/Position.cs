namespace Grayscale.Cube2X2Commons
{
    using System;

    /// <summary>
    /// 局面。
    ///
    /// キューブは x方向に 360°回転できる。（90°が4回）
    /// 次に、y方向に 360°回転できる。（90°が4回）
    /// 次に、z方向に 360°回転できる。（90°が4回）
    /// また、 6 * 4 = 24 の局面は、同じ1つの局面に圧縮できる。
    ///
    /// 順序付けルールを決め、同型の64局面の中で 一番優先順位の高いものが、これになる。
    /// </summary>
    public class Position : AbstractPosition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        private Position()
        {
            this.TileColorArray = new int[24];
        }

        /// <summary>
        /// Gets or sets タイルの色の配列。
        /// </summary>
        public int[] TileColorArray { get; set; }

        /*
        /// <summary>
        /// 局面を生成。
        /// </summary>
        /// <param name="development">展開図。</param>
        /// <returns>局面。</returns>
        public static NormalizedPosition Build(DevelopmentTiles development)
        {
            return Parse(development.GetBoardText());
        }
         */

        /// <summary>
        /// 同じものを作る。
        /// </summary>
        /// <param name="source">元となる局面。</param>
        /// <returns>局面。</returns>
        public static Position Clone(Position source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var pos = new Position();

            System.Array.Copy(source.TileColorArray, pos.TileColorArray, source.TileColorArray.Length);

            return pos;
        }

        /// <summary>
        /// 局面を生成。
        /// </summary>
        /// <param name="position">局面文字列。</param>
        /// <returns>局面。</returns>
        public static Position Parse(string position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }

            // スラッシュを消して詰める。
            position = position.Replace("/", string.Empty);

            var pos = new Position();

            // 全ての色をセットする。
            for (int tile = 0; tile < 24; tile++)
            {
                pos.SetTileColor(tile, ColorHelper.GetNumberFromAlphabet(position[tile]));
            }

            return pos;
        }

        /*
        /// <summary>
        /// 展開図を更新（正規化）する。
        /// </summary>
        /// <param name="development">展開図。</param>
        public void Normalize(DevelopmentTiles development)
        {
            // 全ての色をセットする。
            for (int tile = 0; tile < 24; tile++)
            {
                switch (this.GetTileColor(tile))
                {
                    case 0:
                        development.SetTileColor(tile, Color.Pink);
                        break;
                    case 1:
                        development.SetTileColor(tile, Color.Lime);
                        break;
                    case 2:
                        development.SetTileColor(tile, Color.SkyBlue);
                        break;
                    case 3:
                        development.SetTileColor(tile, Color.Orange);
                        break;
                    case 4:
                        development.SetTileColor(tile, Color.Violet);
                        break;
                    case 5:
                        development.SetTileColor(tile, Color.LightGray);
                        break;
                    default:
                        break;
                }
            }
        }
        */

        /// <summary>
        /// タイルの色を返します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <returns>タイルの色。</returns>
        public override int GetTileColor(int tile)
        {
            return this.TileColorArray[tile];
        }

        /// <summary>
        /// タイルの色を設定します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <param name="color">色。</param>
        public override void SetTileColor(int tile, int color)
        {
            this.TileColorArray[tile] = color;
        }
    }
}
