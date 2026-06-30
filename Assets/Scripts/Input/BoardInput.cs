using MatchGem.Core;
using System;
using UnityEngine;

namespace MatchGem.Input
{
    /// <summary>
    /// 棋盤輸入操作偵測
    /// </summary>
    public class BoardInput : MonoBehaviour
    {
        #region 基本參數
        [SerializeField]private Camera _camera;
        private GridMapper _gridMapper;
        private readonly PointerInputReader _PIR = new PointerInputReader();
        #endregion 基本參數

        #region 公開方法
        public void Configure(GridMapper gridMapper)
        {
            _gridMapper = gridMapper;
        }
        #endregion 公開方法

        #region UNITY生命週期
        void Update()
        {
            //隨時監看輸入操作
        }
        #endregion UNITY生命週期
    }

}
