using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class Order
    {
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_Order");
            strSql.Append(" where ");
            strSql.Append(" Id = SQL2012Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_Order(");
            strSql.Append("TransportOrderId,Code,AcceptOrderTime,ArrivedTime,ShipperId,ReceiverId,ContractNumber,LoadingAddress,UnloadingAddress,GoodsId,IsCharteredCar,Quantity,DispatchedCount,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,BillNumber,WeighbridgeNumber,Status,CreateDateTime,Remarks,IsWeightNote,IsAllotted,UnitPrice,Weight,Freight,HandlingCharge");
            strSql.Append(") values (");
            strSql.Append("SQL2012TransportOrderId,SQL2012Code,SQL2012AcceptOrderTime,SQL2012ArrivedTime,SQL2012ShipperId,SQL2012ReceiverId,SQL2012ContractNumber,SQL2012LoadingAddress,SQL2012UnloadingAddress,SQL2012GoodsId,SQL2012IsCharteredCar,SQL2012Quantity,SQL2012DispatchedCount,SQL2012Haulway,SQL2012LoadingCapacityRunning,SQL2012NoLoadingCapacityRunning,SQL2012BillNumber,SQL2012WeighbridgeNumber,SQL2012Status,SQL2012CreateDateTime,SQL2012Remarks,SQL2012IsWeightNote,SQL2012IsAllotted,SQL2012UnitPrice,SQL2012Weight,SQL2012Freight,SQL2012HandlingCharge");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("SQL2012TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ShipperId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ReceiverId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("SQL2012Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012IsWeightNote", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012IsAllotted", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Freight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012HandlingCharge", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.TransportOrderId;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.AcceptOrderTime;
            parameters[3].Value = model.ArrivedTime;
            parameters[4].Value = model.ShipperId;
            parameters[5].Value = model.ReceiverId;
            parameters[6].Value = model.ContractNumber;
            parameters[7].Value = model.LoadingAddress;
            parameters[8].Value = model.UnloadingAddress;
            parameters[9].Value = model.GoodsId;
            parameters[10].Value = model.IsCharteredCar;
            parameters[11].Value = model.Quantity;
            parameters[12].Value = model.DispatchedCount;
            parameters[13].Value = model.Haulway;
            parameters[14].Value = model.LoadingCapacityRunning;
            parameters[15].Value = model.NoLoadingCapacityRunning;
            parameters[16].Value = model.BillNumber;
            parameters[17].Value = model.WeighbridgeNumber;
            parameters[18].Value = model.Status;
            parameters[19].Value = model.CreateDateTime;
            parameters[20].Value = model.Remarks;
            parameters[21].Value = model.IsWeightNote;
            parameters[22].Value = model.IsAllotted;
            parameters[23].Value = model.UnitPrice;
            parameters[24].Value = model.Weight;
            parameters[25].Value = model.Freight;
            parameters[26].Value = model.HandlingCharge;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Order set ");

            strSql.Append(" TransportOrderId = SQL2012TransportOrderId , ");
            strSql.Append(" Code = SQL2012Code , ");
            strSql.Append(" AcceptOrderTime = SQL2012AcceptOrderTime , ");
            strSql.Append(" ArrivedTime = SQL2012ArrivedTime , ");
            strSql.Append(" ShipperId = SQL2012ShipperId , ");
            strSql.Append(" ReceiverId = SQL2012ReceiverId , ");
            strSql.Append(" ContractNumber = SQL2012ContractNumber , ");
            strSql.Append(" LoadingAddress = SQL2012LoadingAddress , ");
            strSql.Append(" UnloadingAddress = SQL2012UnloadingAddress , ");
            strSql.Append(" GoodsId = SQL2012GoodsId , ");
            strSql.Append(" IsCharteredCar = SQL2012IsCharteredCar , ");
            strSql.Append(" Quantity = SQL2012Quantity , ");
            strSql.Append(" DispatchedCount = SQL2012DispatchedCount , ");
            strSql.Append(" Haulway = SQL2012Haulway , ");
            strSql.Append(" LoadingCapacityRunning = SQL2012LoadingCapacityRunning , ");
            strSql.Append(" NoLoadingCapacityRunning = SQL2012NoLoadingCapacityRunning , ");
            strSql.Append(" BillNumber = SQL2012BillNumber , ");
            strSql.Append(" WeighbridgeNumber = SQL2012WeighbridgeNumber , ");
            strSql.Append(" Status = SQL2012Status , ");
            strSql.Append(" CreateDateTime = SQL2012CreateDateTime , ");
            strSql.Append(" Remarks = SQL2012Remarks , ");
            strSql.Append(" IsWeightNote = SQL2012IsWeightNote , ");
            strSql.Append(" IsAllotted = SQL2012IsAllotted , ");
            strSql.Append(" UnitPrice = SQL2012UnitPrice , ");
            strSql.Append(" Weight = SQL2012Weight , ");
            strSql.Append(" Freight = SQL2012Freight , ");
            strSql.Append(" HandlingCharge = SQL2012HandlingCharge  ");
            strSql.Append(" where Id=SQL2012Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("SQL2012Id", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012ShipperId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ReceiverId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("SQL2012Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012Status", SqlDbType.Int,4) ,            
                        new SqlParameter("SQL2012CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("SQL2012Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("SQL2012IsWeightNote", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012IsAllotted", SqlDbType.Bit,1) ,            
                        new SqlParameter("SQL2012UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012Freight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("SQL2012HandlingCharge", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.TransportOrderId;
            parameters[2].Value = model.Code;
            parameters[3].Value = model.AcceptOrderTime;
            parameters[4].Value = model.ArrivedTime;
            parameters[5].Value = model.ShipperId;
            parameters[6].Value = model.ReceiverId;
            parameters[7].Value = model.ContractNumber;
            parameters[8].Value = model.LoadingAddress;
            parameters[9].Value = model.UnloadingAddress;
            parameters[10].Value = model.GoodsId;
            parameters[11].Value = model.IsCharteredCar;
            parameters[12].Value = model.Quantity;
            parameters[13].Value = model.DispatchedCount;
            parameters[14].Value = model.Haulway;
            parameters[15].Value = model.LoadingCapacityRunning;
            parameters[16].Value = model.NoLoadingCapacityRunning;
            parameters[17].Value = model.BillNumber;
            parameters[18].Value = model.WeighbridgeNumber;
            parameters[19].Value = model.Status;
            parameters[20].Value = model.CreateDateTime;
            parameters[21].Value = model.Remarks;
            parameters[22].Value = model.IsWeightNote;
            parameters[23].Value = model.IsAllotted;
            parameters[24].Value = model.UnitPrice;
            parameters[25].Value = model.Weight;
            parameters[26].Value = model.Freight;
            parameters[27].Value = model.HandlingCharge;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_Order ");
            strSql.Append(" where Id=SQL2012Id");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_Order ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.Order GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, TransportOrderId, Code, AcceptOrderTime, ArrivedTime, ShipperId, ReceiverId, ContractNumber, LoadingAddress, UnloadingAddress, GoodsId, IsCharteredCar, Quantity, DispatchedCount, Haulway, LoadingCapacityRunning, NoLoadingCapacityRunning, BillNumber, WeighbridgeNumber, Status, CreateDateTime, Remarks, IsWeightNote, IsAllotted, UnitPrice, Weight, Freight, HandlingCharge  ");
            strSql.Append("  from mtms_Order ");
            strSql.Append(" where Id=SQL2012Id");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.Order model = new DTcms.Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransportOrderId"].ToString() != "")
                {
                    model.TransportOrderId = int.Parse(ds.Tables[0].Rows[0]["TransportOrderId"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["AcceptOrderTime"].ToString() != "")
                {
                    model.AcceptOrderTime = DateTime.Parse(ds.Tables[0].Rows[0]["AcceptOrderTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArrivedTime"].ToString() != "")
                {
                    model.ArrivedTime = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivedTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShipperId"].ToString() != "")
                {
                    model.ShipperId = int.Parse(ds.Tables[0].Rows[0]["ShipperId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiverId"].ToString() != "")
                {
                    model.ReceiverId = int.Parse(ds.Tables[0].Rows[0]["ReceiverId"].ToString());
                }
                model.ContractNumber = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                model.LoadingAddress = ds.Tables[0].Rows[0]["LoadingAddress"].ToString();
                model.UnloadingAddress = ds.Tables[0].Rows[0]["UnloadingAddress"].ToString();
                if (ds.Tables[0].Rows[0]["GoodsId"].ToString() != "")
                {
                    model.GoodsId = int.Parse(ds.Tables[0].Rows[0]["GoodsId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsCharteredCar"].ToString() != "")
                {
                    model.IsCharteredCar = int.Parse(ds.Tables[0].Rows[0]["IsCharteredCar"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DispatchedCount"].ToString() != "")
                {
                    model.DispatchedCount = decimal.Parse(ds.Tables[0].Rows[0]["DispatchedCount"].ToString());
                }
                model.Haulway = ds.Tables[0].Rows[0]["Haulway"].ToString();
                if (ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString() != "")
                {
                    model.LoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString() != "")
                {
                    model.NoLoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString());
                }
                model.BillNumber = ds.Tables[0].Rows[0]["BillNumber"].ToString();
                model.WeighbridgeNumber = ds.Tables[0].Rows[0]["WeighbridgeNumber"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDateTime"].ToString() != "")
                {
                    model.CreateDateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDateTime"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["IsWeightNote"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsWeightNote"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsWeightNote"].ToString().ToLower() == "true"))
                    {
                        model.IsWeightNote = true;
                    }
                    else
                    {
                        model.IsWeightNote = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsAllotted"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsAllotted"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsAllotted"].ToString().ToLower() == "true"))
                    {
                        model.IsAllotted = true;
                    }
                    else
                    {
                        model.IsAllotted = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Freight"].ToString() != "")
                {
                    model.Freight = decimal.Parse(ds.Tables[0].Rows[0]["Freight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HandlingCharge"].ToString() != "")
                {
                    model.HandlingCharge = decimal.Parse(ds.Tables[0].Rows[0]["HandlingCharge"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM mtms_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM mtms_Order ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

    }
}
