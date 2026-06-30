using MatchGem.Core;
using System;
using System.Net;
using UnityEngine;

namespace MatchGem.Inputs
{
    /// <summary>
    /// 棋盤輸入操作偵測
    /// </summary>
    public class BoardInput : MonoBehaviour
    {
        #region 外部事件連接
        public Action<CellCoord, CellCoord> SwapAction;
        #endregion 外部事件連接

        #region 基本參數
        [SerializeField] private Camera _camera;
        private GridMapper _gridMapper;
        private readonly PointerInputReader _PIR = new PointerInputReader();
        /// <summary>
        /// 是否拖曳中
        /// </summary>
        private bool _isDragging;
        /// <summary>
        /// 是否有選取寶石物件
        /// </summary>
        private bool _hasSelected;
        private float _dragThreshold;
        /// <summary>
        /// 開始拖曳的位置(螢幕上)
        /// </summary>
        private Vector2 _dragStarPos;
        private Vector2 _dragDelta;
        private CellCoord _selectedCoord;
        private CellCoord _dragStarCoord;
        private CellCoord _targetCoord;
        #endregion 基本參數

        #region 狀態參數
        private bool IsReady => _camera != null && _gridMapper != null;
        #endregion 狀態參數

        #region 公開方法
        public void Configure(GridMapper gridMapper, float cellSize = 1f)
        {
            _gridMapper = gridMapper;
            _dragThreshold = cellSize * 0.6f;
            //以防萬一攝影機忘記設定
            if(_camera == null) _camera = Camera.main;
        }
        #endregion 公開方法

        #region UNITY生命週期
        void Update()
        {
            if(!IsReady) return;
            //準備完成:隨時監看輸入操作
            if(_PIR.TryGetPointerDown(out Vector2 downPos)) BeginPointer(downPos);
            if (_PIR.TryGetPointerDown(out Vector2 upPos)) EndPointer(upPos);
        }
        #endregion UNITY生命週期

        #region 私有方法
        /// <summary>
        /// 按下的起始邏輯
        /// </summary>
        /// <param name="downPos">按下的位置</param>
        private void BeginPointer(Vector2 downPos)
        {
            Debug.Log("點擊~");
            _isDragging = true;
            _dragStarPos = downPos;
            _dragStarCoord = _gridMapper.ToCell(_dragStarPos);
        }
        /// <summary>
        /// 鬆開的結束邏輯
        /// </summary>
        /// <param name="downPos">鬆開的位置</param>
        private void EndPointer(Vector2 upPos)
        {
            Debug.Log("鬆開~");
            _isDragging = false;
            _dragDelta = upPos - _dragStarPos;
            if(_dragDelta.magnitude >= _dragThreshold)
            {//拖曳交換
                _targetCoord = GetTargetCoord();
                //if (SwapAction != null) SwapAction();
                SwapAction?.Invoke(_dragStarCoord,  _targetCoord);//執行被委託的功能
            }
            else
            {//點擊:選取 or 交換
                SelectOrSwap();
            }
        }

        /// <summary>
        /// 取得拖曳後的目標Coord
        /// </summary>
        /// <returns>目標Coord</returns>
        private CellCoord GetTargetCoord()
        {
            if (Math.Abs(_dragDelta.x) > Math.Abs(_dragDelta.y))
            {//橫移:絕對值計算比較 X 是否大於 Y
                return new CellCoord(_dragStarCoord.X + (_dragDelta.x > 0 ? 1 : -1), _dragStarCoord.Y);
            }
            else
            {//直移:絕對值計算比較 Y 是否大於 X
                return new CellCoord(_dragStarCoord.X, _dragStarCoord.Y + (_dragDelta.y > 0 ? 1 : -1));
            }

        }
        /// <summary>
        /// 選取或交換
        /// </summary>
        private void SelectOrSwap()
        {
            if (!_hasSelected)
            {//進入選取狀態
                _hasSelected = true;
                _selectedCoord = _dragStarCoord;
            }
            else
            {//選取交換
                _hasSelected = false;
                SwapAction?.Invoke(_selectedCoord, _targetCoord);
            }
        }
        #endregion 私有方法
    }

}
