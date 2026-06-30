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
            _cellWorldSize = Math.Max(0.1f, cellWorldSize); 
        }
        #endregion 建構式

        #region 公開方式
        #endregion 公開方式
    }

}
