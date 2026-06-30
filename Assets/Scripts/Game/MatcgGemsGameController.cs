using MatchGem.Core;
using MatchGem.View;
using MatchGem.Inputs;
using UnityEngine;

namespace MatchGems.Game
{
    /// <summary>
    /// 遊戲流程主程式(控制)
    /// </summary>
    public class MatcgGemsGameController : MonoBehaviour
    {
        #region 基本參數
        [SerializeField] private BoardView _boardView;
        [SerializeField] private BoardInput _boardInput;
        [SerializeField] private int _wigth = 8;
        [SerializeField] private int _height = 8;
        private BoardModel _boardModel;
        private GridMapper _gridMapper;

        #endregion 基本參數

        #region 生命週期
        void Start()
        {
            CreateBoard();
            CreateMapper();
            _boardView.Build(_boardModel, _gridMapper);
            ConfigureInput();
        }
        #endregion 生命週期

        #region 私有方法
        /// <summary>
        /// 建立棋盤
        /// </summary>
        private void CreateBoard()
        {
            _boardModel = new BoardModel(_wigth, _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _wigth; x++)
                {
                    _boardModel.SetGem(x, y, (GemType)Random.Range(0, 6));

                }
            }

        }

        /// <summary>
        /// 建立轉換器
        /// </summary>
        public void CreateMapper()
        {//建構Root物件座標即為原點
            _gridMapper = new GridMapper
                (_boardView.transform.position, _boardView.CellWorldSize);
        }

        public void ConfigureInput()
        {
            _boardInput.Configure(_gridMapper);//CellSize先走預設
            _boardInput.SwapAction = TrySwap;
        }

        /// <summary>
        /// 嘗試交換兩格的寶石資料
        /// </summary>
        /// <param name="from">起始</param>
        /// <param name="to">目標</param>
        private void TrySwap(CellCoord from, CellCoord to)
        {
            if (!_boardModel.IsInside(to)) return;
            if (!_boardModel.IsAdjacent(from, to)) return;
            _boardModel.SwapGems(from, to);
        }
        # endregion 私有方法
    }
}
