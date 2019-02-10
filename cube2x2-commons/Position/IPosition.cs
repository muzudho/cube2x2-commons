namespace Grayscale.Commons
{
    /// <summary>
    /// 局面。
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// Gets 盤面を、文字列で返す。
        /// </summary>
        /// <returns>局面</returns>
        string BoardText { get; }

        /// <summary>
        /// タイルの色を設定します。
        /// </summary>
        /// <param name="tile">タイル番号。</param>
        /// <param name="color">色。</param>
        void SetTileColor(int tile, int color);

        /// <summary>
        /// ゲーム開始状態に戻します。
        /// </summary>
        void SetNewGame();

        /// <summary>
        /// 90度回転。4つのタイルを、１つずらします。
        /// </summary>
        /// <param name="tileA">タイル1。</param>
        /// <param name="tileB">タイル2。</param>
        /// <param name="tileC">タイル3。</param>
        /// <param name="tileD">タイル4。</param>
        void Shift4(int tileA, int tileB, int tileC, int tileD);

        /// <summary>
        /// キューブを 90° ひねります。
        /// </summary>
        /// <param name="handle">回転箇所。</param>
        void RotateOnly(int handle);

        /// <summary>
        /// 見る角度を変えます。
        /// </summary>
        /// <param name="handle">回転箇所。</param>
        void RotateView(int handle);
    }
}
