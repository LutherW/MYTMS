using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class TransportOrder
    {

        private readonly DTcms.DAL.TransportOrder dal = new DTcms.DAL.TransportOrder();
        public TransportOrder()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.TransportOrder model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.TransportOrder model)
        {
            return dal.Update(model);
        }

        public bool Update(DTcms.Model.TransportOrder model, IList<Model.Order> orders, IList<Model.Consumption> consumptions)
        {
            return dal.Update(model, orders, consumptions);
        }

        public bool Update(int id, DateTime warningTime) 
        {
            return dal.Update(id, warningTime);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.TransportOrder GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.TransportOrder GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_TransportOrderModel-" + Id;
        //    object objModel = DTcms.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = DTcms.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                DTcms.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (DTcms.Model.TransportOrder)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet GetTotalList(string strWhere)
        {
            return dal.GetTotalList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        public DataSet GetSelectList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetSelectList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.TransportOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.TransportOrder> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.TransportOrder> modelList = new List<DTcms.Model.TransportOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.TransportOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DTcms.Model.TransportOrder();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["DispatchTime"].ToString() != "")
                    {
                        model.DispatchTime = DateTime.Parse(dt.Rows[n]["DispatchTime"].ToString());
                    }
                    if (dt.Rows[n]["FactDispatchTime"].ToString() != "")
                    {
                        model.FactDispatchTime = DateTime.Parse(dt.Rows[n]["FactDispatchTime"].ToString());
                    }
                    if (dt.Rows[n]["TimeLimit"].ToString() != "")
                    {
                        model.TimeLimit = int.Parse(dt.Rows[n]["TimeLimit"].ToString());
                    }
                    if (dt.Rows[n]["ReceiptTime"].ToString() != "")
                    {
                        model.ReceiptTime = DateTime.Parse(dt.Rows[n]["ReceiptTime"].ToString());
                    }
                    if (dt.Rows[n]["WarningTime"].ToString() != "")
                    {
                        model.WarningTime = DateTime.Parse(dt.Rows[n]["WarningTime"].ToString());
                    }
                    if (dt.Rows[n]["BackTime"].ToString() != "")
                    {
                        model.BackTime = DateTime.Parse(dt.Rows[n]["BackTime"].ToString());
                    }
                    if (dt.Rows[n]["FactBackTime"].ToString() != "")
                    {
                        model.FactBackTime = DateTime.Parse(dt.Rows[n]["FactBackTime"].ToString());
                    }
                    if (dt.Rows[n]["DriverId"].ToString() != "")
                    {
                        model.DriverId = int.Parse(dt.Rows[n]["DriverId"].ToString());
                    }
                    if (dt.Rows[n]["Advance"].ToString() != "")
                    {
                        model.Advance = decimal.Parse(dt.Rows[n]["Advance"].ToString());
                    }
                    model.Payee = dt.Rows[n]["Payee"].ToString();
                    if (dt.Rows[n]["Repayment"].ToString() != "")
                    {
                        model.Repayment = decimal.Parse(dt.Rows[n]["Repayment"].ToString());
                    }
                    if (dt.Rows[n]["FactRepayment"].ToString() != "")
                    {
                        model.FactRepayment = decimal.Parse(dt.Rows[n]["FactRepayment"].ToString());
                    }
                    if (dt.Rows[n]["CarriageUnitPrice"].ToString() != "")
                    {
                        model.CarriageUnitPrice = decimal.Parse(dt.Rows[n]["CarriageUnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["Carriage"].ToString() != "")
                    {
                        model.Carriage = decimal.Parse(dt.Rows[n]["Carriage"].ToString());
                    }
                    if (dt.Rows[n]["FactCarriage"].ToString() != "")
                    {
                        model.FactCarriage = decimal.Parse(dt.Rows[n]["FactCarriage"].ToString());
                    }
                    if (dt.Rows[n]["CostTotal"].ToString() != "")
                    {
                        model.CostTotal = decimal.Parse(dt.Rows[n]["CostTotal"].ToString());
                    }
                    if (dt.Rows[n]["Profit"].ToString() != "")
                    {
                        model.Profit = decimal.Parse(dt.Rows[n]["Profit"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.CustomerRemarks = dt.Rows[n]["CustomerRemarks"].ToString();
                    model.HaulwayRemarks = dt.Rows[n]["HaulwayRemarks"].ToString();
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    if (dt.Rows[n]["FactTotalPrice"].ToString() != "")
                    {
                        model.FactTotalPrice = decimal.Parse(dt.Rows[n]["FactTotalPrice"].ToString());
                    }
                    if (dt.Rows[n]["TotalPrice"].ToString() != "")
                    {
                        model.TotalPrice = decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
                    }
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["FactDispatchCount"].ToString() != "")
                    {
                        model.FactDispatchCount = decimal.Parse(dt.Rows[n]["FactDispatchCount"].ToString());
                    }
                    if (dt.Rows[n]["DispatchCount"].ToString() != "")
                    {
                        model.DispatchCount = decimal.Parse(dt.Rows[n]["DispatchCount"].ToString());
                    }
                    if (dt.Rows[n]["ReceivedWeight"].ToString() != "")
                    {
                        model.ReceivedWeight = decimal.Parse(dt.Rows[n]["ReceivedWeight"].ToString());
                    }
                    if (dt.Rows[n]["UnloadingWeight"].ToString() != "")
                    {
                        model.UnloadingWeight = decimal.Parse(dt.Rows[n]["UnloadingWeight"].ToString());
                    }
                    if (dt.Rows[n]["ArriveDate"].ToString() != "")
                    {
                        model.ArriveDate = DateTime.Parse(dt.Rows[n]["ArriveDate"].ToString());
                    }
                    if (dt.Rows[n]["FactArriveDate"].ToString() != "")
                    {
                        model.FactArriveDate = DateTime.Parse(dt.Rows[n]["FactArriveDate"].ToString());
                    }
                    if (dt.Rows[n]["LoadingCapacityRunning"].ToString() != "")
                    {
                        model.LoadingCapacityRunning = decimal.Parse(dt.Rows[n]["LoadingCapacityRunning"].ToString());
                    }
                    if (dt.Rows[n]["NoLoadingCapacityRunning"].ToString() != "")
                    {
                        model.NoLoadingCapacityRunning = decimal.Parse(dt.Rows[n]["NoLoadingCapacityRunning"].ToString());
                    }
                    if (dt.Rows[n]["Weight"].ToString() != "")
                    {
                        model.Weight = decimal.Parse(dt.Rows[n]["Weight"].ToString());
                    }
                    if (dt.Rows[n]["LoadingDate"].ToString() != "")
                    {
                        model.LoadingDate = DateTime.Parse(dt.Rows[n]["LoadingDate"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}
