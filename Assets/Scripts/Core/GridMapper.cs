using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

namespace MatchGem.Core
{
    /// <summary>
    /// 棋盤與世界座標的轉換器
    /// </summary>
    public class GridMapper : MonoBehaviour
    {
        #region 基本參數
        private Vector3 _origin;
        private float _cellWorldSize;
        #endregion 基本參數

        #region 建構式
        /// <summary>
        /// 建立座標轉換器
        /// </summary>
        /// <param name="origin">原點</param>
        /// <param name="cellWorldSize">尺寸</param>
        public GridMapper(Vector3 origin, float cellWorldSize)
        {
            _origin = origin;
            _cellWorldSize = Mathf.Max(0.1f, cellWorldSize);
        }
        #endregion 建構式

        #region 公開方式
        /// <summary>
        /// 格子轉世界座標
        /// </summary>
        /// <param name="coord">格子座標</param>
        /// <returns></returns>
        public Vector3 ToWorld(CellCoord coord)
        {
            return _origin + new Vector3(coord.X * _cellWorldSize, coord.Y * _cellWorldSize, 0);
        }

        /// <summary>
        /// 世界座標轉格子
        /// </summary>
        /// <param name="worldPos">世界座標</param>
        /// <returns></returns>
        public CellCoord ToCell(Vector3 worldPos)
        {
            int x = (int)((worldPos - _origin).x / _cellWorldSize);
            int y = (int)((worldPos - _origin).y / _cellWorldSize);
            return new CellCoord(x, y);
        }
        #endregion 公開方式
    }

}
