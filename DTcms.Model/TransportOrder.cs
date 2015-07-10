using System;
using System.Collections.Generic;
using System.Text;

namespace DTcms.Model
{
    public class TransportOrder
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
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// DispatchTime
        /// </summary>		
        private DateTime _dispatchtime;
        public DateTime DispatchTime
        {
            get { return _dispatchtime; }
            set { _dispatchtime = value; }
        }
        /// <summary>
        /// FactDispatchTime
        /// </summary>		
        private DateTime _factdispatchtime;
        public DateTime FactDispatchTime
        {
            get { return _factdispatchtime; }
            set { _factdispatchtime = value; }
        }
        /// <summary>
        /// TimeLimit
        /// </summary>		
        private int _timelimit;
        public int TimeLimit
        {
            get { return _timelimit; }
            set { _timelimit = value; }
        }
        /// <summary>
        /// ReceiptTime
        /// </summary>		
        private DateTime? _receipttime;
        public DateTime? ReceiptTime
        {
            get { return _receipttime; }
            set { _receipttime = value; }
        }
        /// <summary>
        /// WarningTime
        /// </summary>		
        private DateTime? _warningtime;
        public DateTime? WarningTime
        {
            get { return _warningtime; }
            set { _warningtime = value; }
        }
        /// <summary>
        /// BackTime
        /// </summary>		
        private DateTime? _backtime;
        public DateTime? BackTime
        {
            get { return _backtime; }
            set { _backtime = value; }
        }
        /// <summary>
        /// FactBackTime
        /// </summary>		
        private DateTime? _factbacktime;
        public DateTime? FactBackTime
        {
            get { return _factbacktime; }
            set { _factbacktime = value; }
        }
        /// <summary>
        /// DriverId
        /// </summary>		
        private int _driverid;
        public int DriverId
        {
            get { return _driverid; }
            set { _driverid = value; }
        }
        /// <summary>
        /// Advance
        /// </summary>		
        private decimal _advance;
        public decimal Advance
        {
            get { return _advance; }
            set { _advance = value; }
        }
        /// <summary>
        /// Payee
        /// </summary>		
        private string _payee;
        public string Payee
        {
            get { return _payee; }
            set { _payee = value; }
        }
        /// <summary>
        /// Repayment
        /// </summary>		
        private decimal _repayment;
        public decimal Repayment
        {
            get { return _repayment; }
            set { _repayment = value; }
        }
        /// <summary>
        /// FactRepayment
        /// </summary>		
        private decimal _factrepayment;
        public decimal FactRepayment
        {
            get { return _factrepayment; }
            set { _factrepayment = value; }
        }
        /// <summary>
        /// CarriageUnitPrice
        /// </summary>		
        private decimal _carriageunitprice;
        public decimal CarriageUnitPrice
        {
            get { return _carriageunitprice; }
            set { _carriageunitprice = value; }
        }
        /// <summary>
        /// Carriage
        /// </summary>		
        private decimal _carriage;
        public decimal Carriage
        {
            get { return _carriage; }
            set { _carriage = value; }
        }
        /// <summary>
        /// FactCarriage
        /// </summary>		
        private decimal _factcarriage;
        public decimal FactCarriage
        {
            get { return _factcarriage; }
            set { _factcarriage = value; }
        }
        /// <summary>
        /// CostTotal
        /// </summary>		
        private decimal _costtotal;
        public decimal CostTotal
        {
            get { return _costtotal; }
            set { _costtotal = value; }
        }
        /// <summary>
        /// Profit
        /// </summary>		
        private decimal _profit;
        public decimal Profit
        {
            get { return _profit; }
            set { _profit = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
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
        /// CustomerRemarks
        /// </summary>		
        private string _customerremarks;
        public string CustomerRemarks
        {
            get { return _customerremarks; }
            set { _customerremarks = value; }
        }
        /// <summary>
        /// HaulwayRemarks
        /// </summary>		
        private string _haulwayremarks;
        public string HaulwayRemarks
        {
            get { return _haulwayremarks; }
            set { _haulwayremarks = value; }
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
        /// FactTotalPrice
        /// </summary>		
        private decimal _facttotalprice;
        public decimal FactTotalPrice
        {
            get { return _facttotalprice; }
            set { _facttotalprice = value; }
        }
        /// <summary>
        /// TotalPrice
        /// </summary>		
        private decimal _totalprice;
        public decimal TotalPrice
        {
            get { return _totalprice; }
            set { _totalprice = value; }
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
        /// FactDispatchCount
        /// </summary>		
        private decimal _factdispatchcount;
        public decimal FactDispatchCount
        {
            get { return _factdispatchcount; }
            set { _factdispatchcount = value; }
        }
        /// <summary>
        /// DispatchCount
        /// </summary>		
        private decimal _dispatchcount;
        public decimal DispatchCount
        {
            get { return _dispatchcount; }
            set { _dispatchcount = value; }
        }
        /// <summary>
        /// ReceivedWeight
        /// </summary>		
        private decimal _receivedweight;
        public decimal ReceivedWeight
        {
            get { return _receivedweight; }
            set { _receivedweight = value; }
        }
        /// <summary>
        /// UnloadingWeight
        /// </summary>		
        private decimal _unloadingweight;
        public decimal UnloadingWeight
        {
            get { return _unloadingweight; }
            set { _unloadingweight = value; }
        }
        /// <summary>
        /// ArriveDate
        /// </summary>		
        private DateTime? _arrivedate;
        public DateTime? ArriveDate
        {
            get { return _arrivedate; }
            set { _arrivedate = value; }
        }
        /// <summary>
        /// FactArriveDate
        /// </summary>		
        private DateTime? _factarrivedate;
        public DateTime? FactArriveDate
        {
            get { return _factarrivedate; }
            set { _factarrivedate = value; }
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
        /// Weight
        /// </summary>		
        private decimal _weight;
        public decimal Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        /// <summary>
        /// Weight
        /// </summary>		
        private decimal _factWeight;
        public decimal FactWeight
        {
            get { return _factWeight; }
            set { _factWeight = value; }
        }
        /// <summary>
        /// LoadingDate
        /// </summary>		
        private DateTime? _loadingdate;
        public DateTime? LoadingDate
        {
            get { return _loadingdate; }
            set { _loadingdate = value; }
        }
    }
}
