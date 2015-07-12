using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class Order
    {

        private readonly DTcms.DAL.Order dal = new DTcms.DAL.Order();
        public Order()
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
        public int Add(DTcms.Model.Order model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Order model)
        {
            return dal.Update(model);
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
        public DTcms.Model.Order GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public DTcms.Model.Order GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_OrderModel-" + Id;
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
        //        catch{}
        //    }
        //    return (DTcms.Model.Order)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        public DataSet GetPrintList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetPrintList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DTcms.Model.Order> DataTableToList(DataTable dt)
        {
            List<DTcms.Model.Order> modelList = new List<DTcms.Model.Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DTcms.Model.Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DTcms.Model.Order();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["TransportOrderId"].ToString() != "")
                    {
                        model.TransportOrderId = int.Parse(dt.Rows[n]["TransportOrderId"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["AcceptOrderTime"].ToString() != "")
                    {
                        model.AcceptOrderTime = DateTime.Parse(dt.Rows[n]["AcceptOrderTime"].ToString());
                    }
                    if (dt.Rows[n]["ArrivedTime"].ToString() != "")
                    {
                        model.ArrivedTime = DateTime.Parse(dt.Rows[n]["ArrivedTime"].ToString());
                    }
                    if (dt.Rows[n]["ShipperId"].ToString() != "")
                    {
                        model.ShipperId = int.Parse(dt.Rows[n]["ShipperId"].ToString());
                    }
                    if (dt.Rows[n]["ReceiverId"].ToString() != "")
                    {
                        model.ReceiverId = int.Parse(dt.Rows[n]["ReceiverId"].ToString());
                    }
                    model.ContractNumber = dt.Rows[n]["ContractNumber"].ToString();
                    model.LoadingAddress = dt.Rows[n]["LoadingAddress"].ToString();
                    model.UnloadingAddress = dt.Rows[n]["UnloadingAddress"].ToString();
                    if (dt.Rows[n]["GoodsId"].ToString() != "")
                    {
                        model.GoodsId = int.Parse(dt.Rows[n]["GoodsId"].ToString());
                    }
                    if (dt.Rows[n]["IsCharteredCar"].ToString() != "")
                    {
                        model.IsCharteredCar = int.Parse(dt.Rows[n]["IsCharteredCar"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = decimal.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["DispatchedCount"].ToString() != "")
                    {
                        model.DispatchedCount = decimal.Parse(dt.Rows[n]["DispatchedCount"].ToString());
                    }
                    model.Haulway = dt.Rows[n]["Haulway"].ToString();
                    if (dt.Rows[n]["LoadingCapacityRunning"].ToString() != "")
                    {
                        model.LoadingCapacityRunning = decimal.Parse(dt.Rows[n]["LoadingCapacityRunning"].ToString());
                    }
                    if (dt.Rows[n]["NoLoadingCapacityRunning"].ToString() != "")
                    {
                        model.NoLoadingCapacityRunning = decimal.Parse(dt.Rows[n]["NoLoadingCapacityRunning"].ToString());
                    }
                    model.BillNumber = dt.Rows[n]["BillNumber"].ToString();
                    model.WeighbridgeNumber = dt.Rows[n]["WeighbridgeNumber"].ToString();
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    if (dt.Rows[n]["CreateDateTime"].ToString() != "")
                    {
                        model.CreateDateTime = DateTime.Parse(dt.Rows[n]["CreateDateTime"].ToString());
                    }
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();
                    if (dt.Rows[n]["IsWeightNote"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsWeightNote"].ToString() == "1") || (dt.Rows[n]["IsWeightNote"].ToString().ToLower() == "true"))
                        {
                            model.IsWeightNote = true;
                        }
                        else
                        {
                            model.IsWeightNote = false;
                        }
                    }
                    if (dt.Rows[n]["IsAllotted"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAllotted"].ToString() == "1") || (dt.Rows[n]["IsAllotted"].ToString().ToLower() == "true"))
                        {
                            model.IsAllotted = true;
                        }
                        else
                        {
                            model.IsAllotted = false;
                        }
                    }
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["Weight"].ToString() != "")
                    {
                        model.Weight = decimal.Parse(dt.Rows[n]["Weight"].ToString());
                    }
                    if (dt.Rows[n]["Freight"].ToString() != "")
                    {
                        model.Freight = decimal.Parse(dt.Rows[n]["Freight"].ToString());
                    }
                    if (dt.Rows[n]["HandlingCharge"].ToString() != "")
                    {
                        model.HandlingCharge = decimal.Parse(dt.Rows[n]["HandlingCharge"].ToString());
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

        public DataSet GetFullList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetFullList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

    }
}
