using Unity.Mathematics;
using UnityEngine;

namespace MatchGem.Core
{
    /// <summary>
    /// [Struct]棋盤格的座標
    /// </summary>
    public struct CellCoord
    {
        #region 基本參數
        /// <summary>
        /// 水平座標 只能get
        /// </summary>
        public int X { get; }
        /// <summary>
        /// 垂直座標 只能get
        /// </summary>
        public int Y { get; }
        #endregion 基本參數

        #region 建構式
        public CellCoord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion 建構式
    }

}