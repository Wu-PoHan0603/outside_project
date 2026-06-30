using MatchGem.Core;
using MatchGem.View;
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
        [SerializeField] private int _wigth = 8;
        [SerializeField] private int _height = 8;
        private BoardModel _boardModel;

        #endregion 基本參數

        #region 生命週期
        void Start()
        {
            _boardModel = new BoardModel(_wigth, _height);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _wigth; x++)
                {
                    _boardModel.SetGem(x, y, (GemType)Random.Range(0, 6));
                }
            }

            _boardView.Build(_boardModel);
            
        }
        #endregion 生命週期

}
}
