using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    [Serializable]
    public class DOHuanLuyenThuViecThucTap : DOPhieu
    {
        private long id;
        private long R_id;
        private long tths;
        private int SoNgay;
        private DateTime? NgayBatDau;
        private DateTime? NgayKetThuc;
        private string GhiChu;
        public DOHuanLuyenThuViecThucTap() { }
        public DOHuanLuyenThuViecThucTap(long ID,long R_ID, long TTHS_ID,int SoNgay, DateTime? NGAYBATDAU, DateTime? NGAYKETTHUC,string GHICHU)
        {
            this.id = ID;
            this.R_id = R_ID;
            this.tths = TTHS_ID;
            this.SoNgay = SoNgay;
            this.NgayBatDau = NGAYBATDAU;
            this.NgayKetThuc = NGAYKETTHUC;
            this.GhiChu = GHICHU;
        }
        
        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public long GetID() {return id;}
        public long R_ID
        {
            get { return this.R_id; }
            set { this.R_id = value; }
        }
        public long GetR_ID() { return R_id; }

        public long TTHS_ID
        {
            get { return this.tths; }
            set { this.tths = value; }
        }
        public long GetTTHS_ID() { return this.tths; }
        public int SO_NGAY
        {
            get { return this.SoNgay; }
            set { this.SoNgay = value; }
        }
        public int GetSO_NGAY() { return this.SoNgay; }
        public DateTime? NGAY_BAT_DAU
        {
            get { return this.NgayBatDau; }
            set { this.NgayBatDau = value; }
        }
        public DateTime? GetNGAY_BAT_DAU() { return this.NgayBatDau; }
        public DateTime? NGAY_KET_THUC
        {
            get { return this.NgayKetThuc; }
            set { this.NgayKetThuc = value; }
        }
        public DateTime? GetNGAY_KET_THUC() { return this.NgayKetThuc; }
        private DataSet _DetailDataSet;

        public DataSet DetailDataSet
        {
            get { return _DetailDataSet; }
            set { _DetailDataSet = value; }
        }
        public string GHI_CHU
        {
            get { return this.GhiChu; }
            set { this.GhiChu = value; }
        }
        public string GetGHI_CHU() { return this.GhiChu; }
        
    }
}
