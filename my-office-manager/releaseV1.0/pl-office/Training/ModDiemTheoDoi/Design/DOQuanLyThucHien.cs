
namespace DTO
{
    public class DOQuanLyThucHien
    {
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand _gridBand;
        private DevExpress.XtraGrid.GridControl _gridControl;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView _gridView;
        private DevExpress.XtraBars.BarEditItem _barTime;
        private DevExpress.XtraEditors.ListBoxControl _listBTD;
        public DOQuanLyThucHien() { }
        public DOQuanLyThucHien(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand, DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, DevExpress.XtraBars.BarEditItem barTime, DevExpress.XtraEditors.ListBoxControl listBTD)
        {
            _gridBand = gridBand;
            _gridControl = gridControl;
            _gridView = gridView;
            _barTime = barTime;
            _listBTD = listBTD;
        }

        public DevExpress.XtraEditors.ListBoxControl listBTD
        {
            get { return this._listBTD; }
            set { this._listBTD = value; }
        }
        public DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand
        {
            get { return this._gridBand; }
            set { this._gridBand = value; }
        }
        public DevExpress.XtraBars.BarEditItem barTime
        {
            get { return this._barTime; }
            set { this._barTime = value; }
        }
        public DevExpress.XtraGrid.GridControl gridControl
        {
            get { return this._gridControl; }
            set { this._gridControl = value; }
        }
        public DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView
        {
            get { return this._gridView; }
            set { this._gridView = value; }
        }

    }
}
