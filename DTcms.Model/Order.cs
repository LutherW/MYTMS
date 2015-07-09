using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class Order
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// TransportOrderId
        /// </summary>		
        private int _transportorderid;
        public int TransportOrderId
        {
            get { return _transportorderid; }
            set { _transportorderid = value; }
        }
        /// <summary>
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// AcceptOrderTime
        /// </summary>		
        private DateTime _acceptordertime;
        public DateTime AcceptOrderTime
        {
            get { return _acceptordertime; }
            set { _acceptordertime = value; }
        }
        /// <summary>
        /// ArrivedTime
        /// </summary>		
        private DateTime _arrivedtime;
        public DateTime ArrivedTime
        {
            get { return _arrivedtime; }
            set { _arrivedtime = value; }
        }
        /// <summary>
        /// ShipperId
        /// </summary>		
        private int _shipperid;
        public int ShipperId
        {
            get { return _shipperid; }
            set { _shipperid = value; }
        }
        /// <summary>
        /// ReceiverId
        /// </summary>		
        private int _receiverid;
        public int ReceiverId
        {
            get { return _receiverid; }
            set { _receiverid = value; }
        }
        /// <summary>
        /// ContractNumber
        /// </summary>		
        private string _contractnumber;
        public string ContractNumber
        {
            get { return _contractnumber; }
            set { _contractnumber = value; }
        }
        /// <summary>
        /// LoadingAddress
        /// </summary>		
        private string _loadingaddress;
        public string LoadingAddress
        {
            get { return _loadingaddress; }
            set { _loadingaddress = value; }
        }
        /// <summary>
        /// UnloadingAddress
        /// </summary>		
        private string _unloadingaddress;
        public string UnloadingAddress
        {
            get { return _unloadingaddress; }
            set { _unloadingaddress = value; }
        }
        /// <summary>
        /// GoodsId
        /// </summary>		
        private int _goodsid;
        public int GoodsId
        {
            get { return _goodsid; }
            set { _goodsid = value; }
        }
        /// <summary>
        /// IsCharteredCar
        /// </summary>		
        private int _ischarteredcar;
        public int IsCharteredCar
        {
            get { return _ischarteredcar; }
            set { _ischarteredcar = value; }
        }
        /// <summary>
        /// Quantity
        /// </summary>		
        private decimal _quantity;
        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        /// <summary>
        /// DispatchedCount
        /// </summary>		
        private decimal _dispatchedcount;
        public decimal DispatchedCount
        {
            get { return _dispatchedcount; }
            set { _dispatchedcount = value; }
        }
        /// <summary>
        /// Haulway
        /// </summary>		
        private string _haulway;
        public string Haulway
        {
            get { return _haulway; }
            set { _haulway = value; }
        }
        /// <summary>
        /// LoadingCapacityRunning
        /// </summary>		
        private decimal _loadingcapacityrunning;
        public decimal LoadingCapacityRunning
        {
            get { return _loadingcapacityrunning; }
            set { _loadingcapacityrunning = value; }
        }
        /// <summary>
        /// NoLoadingCapacityRunning
        /// </summary>		
        private decimal _noloadingcapacityrunning;
        public decimal NoLoadingCapacityRunning
        {
            get { return _noloadingcapacityrunning; }
            set { _noloadingcapacityrunning = value; }
        }
        /// <summary>
        /// BillNumber
        /// </summary>		
        private string _billnumber;
        public string BillNumber
        {
            get { return _billnumber; }
            set { _billnumber = value; }
        }
        /// <summary>
        /// WeighbridgeNumber
        /// </summary>		
        private string _weighbridgenumber;
        public string WeighbridgeNumber
        {
            get { return _weighbridgenumber; }
            set { _weighbridgenumber = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// CreateDateTime
        /// </summary>		
        private DateTime _createdatetime;
        public DateTime CreateDateTime
        {
            get { return _createdatetime; }
            set { _createdatetime = value; }
        }
        /// <summary>
        /// Remarks
        /// </summary>		
        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        /// <summary>
        /// IsWeightNote
        /// </summary>		
        private bool _isweightnote;
        public bool IsWeightNote
        {
            get { return _isweightnote; }
            set { _isweightnote = value; }
        }
        /// <summary>
        /// IsAllotted
        /// </summary>		
        private bool _isallotted;
        public bool IsAllotted
        {
            get { return _isallotted; }
            set { _isallotted = value; }
        }
        /// <summary>
        /// UnitPrice
        /// </summary>		
        private decimal _unitprice;
        public decimal UnitPrice
        {
            get { return _unitprice; }
            set { _unitprice = value; }
        }
        /// <summary>
        /// Weight
        /// </summary>		
        private decimal _weight;
        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        /// <summary>
        /// Freight
        /// </summary>		
        private decimal _freight;
        public decimal Freight
        {
            get { return _freight; }
            set { _freight = value; }
        }
        /// <summary>
        /// HandlingCharge
        /// </summary>		
        private decimal _handlingcharge;
        public decimal HandlingCharge
        {
            get { return _handlingcharge; }
            set { _handlingcharge = value; }
        }

    }
}
