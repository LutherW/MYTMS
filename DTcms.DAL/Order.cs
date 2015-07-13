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
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
            strSql.Append("TransportOrderId,Code,AcceptOrderTime,ArrivedTime,ShipperId,ReceiverId,ContractNumber,LoadingAddress,UnloadingAddress,GoodsId,IsCharteredCar,Quantity,DispatchedCount,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,BillNumber,WeighbridgeNumber,Status,CreateDateTime,Remarks,IsWeightNote,IsAllotted,UnitPrice,Weight,Freight,PaidFreight,UnpaidFreight,HandlingCharge");
            strSql.Append(") values (");
            strSql.Append("@TransportOrderId,@Code,@AcceptOrderTime,@ArrivedTime,@ShipperId,@ReceiverId,@ContractNumber,@LoadingAddress,@UnloadingAddress,@GoodsId,@IsCharteredCar,@Quantity,@DispatchedCount,@Haulway,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@BillNumber,@WeighbridgeNumber,@Status,@CreateDateTime,@Remarks,@IsWeightNote,@IsAllotted,@UnitPrice,@Weight,@Freight,@PaidFreight,@UnpaidFreight,@HandlingCharge");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ShipperId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceiverId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsWeightNote", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsAllotted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Freight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HandlingCharge", SqlDbType.Decimal,9) ,
                        new SqlParameter("@PaidFreight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnpaidFreight", SqlDbType.Decimal,9)
              
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
            parameters[27].Value = model.PaidFreight;
            parameters[28].Value = model.UnpaidFreight;

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

            strSql.Append(" TransportOrderId = @TransportOrderId , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" AcceptOrderTime = @AcceptOrderTime , ");
            strSql.Append(" ArrivedTime = @ArrivedTime , ");
            strSql.Append(" ShipperId = @ShipperId , ");
            strSql.Append(" ReceiverId = @ReceiverId , ");
            strSql.Append(" ContractNumber = @ContractNumber , ");
            strSql.Append(" LoadingAddress = @LoadingAddress , ");
            strSql.Append(" UnloadingAddress = @UnloadingAddress , ");
            strSql.Append(" GoodsId = @GoodsId , ");
            strSql.Append(" IsCharteredCar = @IsCharteredCar , ");
            strSql.Append(" Quantity = @Quantity , ");
            strSql.Append(" DispatchedCount = @DispatchedCount , ");
            strSql.Append(" Haulway = @Haulway , ");
            strSql.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
            strSql.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
            strSql.Append(" BillNumber = @BillNumber , ");
            strSql.Append(" WeighbridgeNumber = @WeighbridgeNumber , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" CreateDateTime = @CreateDateTime , ");
            strSql.Append(" Remarks = @Remarks , ");
            strSql.Append(" IsWeightNote = @IsWeightNote , ");
            strSql.Append(" IsAllotted = @IsAllotted , ");
            strSql.Append(" UnitPrice = @UnitPrice , ");
            strSql.Append(" Weight = @Weight , ");
            strSql.Append(" Freight = @Freight , ");
            strSql.Append(" PaidFreight = @PaidFreight , ");
            strSql.Append(" UnpaidFreight = @UnpaidFreight , ");
            strSql.Append(" HandlingCharge = @HandlingCharge  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ShipperId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceiverId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@GoodsId", SqlDbType.Int,4) ,            
                        new SqlParameter("@IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsWeightNote", SqlDbType.Bit,1) ,            
                        new SqlParameter("@IsAllotted", SqlDbType.Bit,1) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Freight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HandlingCharge", SqlDbType.Decimal,9),
                        new SqlParameter("@PaidFreight", SqlDbType.Decimal,9) ,
                        new SqlParameter("@UnpaidFreight", SqlDbType.Decimal,9) 
              
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
            parameters[28].Value = model.PaidFreight;
            parameters[29].Value = model.UnpaidFreight;
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

        public int UpdateField(SqlConnection conn, SqlTransaction trans, int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Order set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }

        public decimal GetTotalPrice(int transportOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(Freight) FROM mtms_Order WHERE TransportOrderId = " + transportOrderId + "");

            return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_Order ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
            strSql.Append("select Id, TransportOrderId, Code, AcceptOrderTime, ArrivedTime, ShipperId, ReceiverId, ContractNumber, LoadingAddress, UnloadingAddress, GoodsId, IsCharteredCar, Quantity, DispatchedCount, Haulway, LoadingCapacityRunning, NoLoadingCapacityRunning, BillNumber, WeighbridgeNumber, Status, CreateDateTime, Remarks, IsWeightNote, IsAllotted, UnitPrice, Weight, Freight, PaidFreight, UnpaidFreight, HandlingCharge  ");
            strSql.Append("  from mtms_Order ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
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
                if (ds.Tables[0].Rows[0]["PaidFreight"].ToString() != "")
                {
                    model.PaidFreight = decimal.Parse(ds.Tables[0].Rows[0]["PaidFreight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnpaidFreight"].ToString() != "")
                {
                    model.UnpaidFreight = decimal.Parse(ds.Tables[0].Rows[0]["UnpaidFreight"].ToString());
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

        public DataSet GetPrintList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*, B.Name AS GoodsName, B.CategoryName AS GoodsCategory, B.Variety AS GoodsVariety, ");
            strSql.Append("C.ShortName AS Shipper, D.ShortName AS Receiver, ");
            strSql.Append("E.Status AS TransportOrderStatus, E.DispatchTime AS DispatchTime, ");
            strSql.Append("F.RealName AS DriverName, F.CarNumber AS CarNumber, F.LinkTel AS DriverTel ");
            strSql.Append("FROM mtms_Order A ");
            strSql.Append("LEFT JOIN mtms_Goods B ON A.GoodsId = B.Id  ");
            strSql.Append("LEFT JOIN mtms_Customer C ON A.ShipperId = C.Id ");
            strSql.Append("LEFT JOIN mtms_Customer D ON A.ReceiverId = D.Id, ");
            strSql.Append("mtms_TransportOrder E  ");
            strSql.Append("LEFT JOIN mtms_Driver F ON E.DriverId = F.Id ");
            strSql.Append("WHERE A.TransportOrderId = E.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(filedOrder);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*, B.Name AS GoodsName, B.CategoryName AS GoodsCategory, B.Variety AS GoodsVariety, ");
            strSql.Append("C.ShortName AS Shipper, D.ShortName AS Receiver ");
            strSql.Append("FROM mtms_Order A ");
            strSql.Append("LEFT JOIN mtms_Goods B ON A.GoodsId = B.Id  ");
            strSql.Append("LEFT JOIN mtms_Customer C ON A.ShipperId = C.Id ");
            strSql.Append("LEFT JOIN mtms_Customer D ON A.ReceiverId = D.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //throw new Exception(PagingHelper.CreatePagingSql(1, pageSize, pageIndex, strSql.ToString(), filedOrder));
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetFullList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*, B.Name AS GoodsName, B.CategoryName AS GoodsCategory, B.Variety AS GoodsVariety, ");
            strSql.Append("C.ShortName AS Shipper, D.ShortName AS Receiver, ");
            strSql.Append("E.Status AS TransportOrderStatus, E.DispatchTime AS DispatchTime, ");
            strSql.Append("F.RealName AS DriverName, F.CarNumber AS CarNumber, F.LinkTel AS DriverTel ");
            strSql.Append("FROM mtms_Order A ");
            strSql.Append("LEFT JOIN mtms_Goods B ON A.GoodsId = B.Id  ");
            strSql.Append("LEFT JOIN mtms_Customer C ON A.ShipperId = C.Id ");
            strSql.Append("LEFT JOIN mtms_Customer D ON A.ReceiverId = D.Id, ");
            strSql.Append("mtms_TransportOrder E  ");
            strSql.Append("LEFT JOIN mtms_Driver F ON E.DriverId = F.Id ");
            strSql.Append("WHERE A.TransportOrderId = E.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }

            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
