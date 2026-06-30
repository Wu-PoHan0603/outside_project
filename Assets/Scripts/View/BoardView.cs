using UnityEngine;
using MatchGem.Core;

namespace MatchGem.View
{
    /// <summary>
    /// 棋盤和寶石的視覺整體
    /// </summary>
    public class BoardView : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private int _cellSize = 64; //底線 私變數
        [SerializeField] private float _pixelPerUnit = 64f;
        [SerializeField] private GemTile _tilePrefab;
        private GemTile[,] _tiles;
        private GridMapper _gridMapper;
        #endregion 基本參數

        #region 公開屬性
        /// <summary>
        /// 單一格像素尺寸
        /// </summary>
        public int CellSize => _cellSize; //唯讀 讀的到改不到
        /// <summary>
        /// 一個Unit單位的對應像素值
        /// </summary>
        public float PixePerUnit => _pixelPerUnit;
        /// <summary>
        /// 單一格在世界座標的比例
        /// </summary>
        public float CellWorldSize => _cellSize / _pixelPerUnit;
        #endregion 公開屬性

        #region 公開方法
        /// <summary>
        /// 依棋盤資料建立全部Tile視覺
        /// </summary>
        /// <param name="board">棋盤資料</param>
        public void Build(BoardModel board, GridMapper gridMapper)
        {
            _gridMapper = gridMapper;
            //清理舊的視覺資料
            //ClearTiles();
            //產生與資料相同的視覺
            _tiles = new GemTile[board.Width, board.Height];

            for (int y = 0; y < board.Height; y++)
            {
                for (int x = 0; x < board.Width; x++)
                {
                    _tiles[x,y] = CreateTile(x, y);
                    _tiles[x, y].SetGem(board.GetGem(x, y));
                }
            }
        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 依照定位實例化寶石磚
        /// </summary>
        /// <param name="x">座標X</param>
        /// <param name="y">座標Y</param>
        /// <returns>寶石磚</returns>
        private GemTile CreateTile(int x, int y)
        {
            Vector3 position = new Vector3(x * CellWorldSize, y * CellWorldSize, 0);  
            return Instantiate(_tilePrefab, position, Quaternion.identity, transform);
            //四元數.不翻轉 transform繼承相關腳本物件
        }

        public void ClearTiles()
        {
            //Destroy(transform.GetChild(0).gameObject);
            Debug.Log(transform.childCount);
            //一種連發的 if
            /*while (transform.childCount > 0)
            {
                //不斷刪除子物件,直到歸0為止
                Destroy(transform.GetChild(0).gameObject);
            }*/
        }
        #endregion 私有方法

        #region 私有方法
        # endregion 私有方法

    }

}
