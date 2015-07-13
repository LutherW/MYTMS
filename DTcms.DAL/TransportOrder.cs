using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class TransportOrder
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_TransportOrder");
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
        public int Add(DTcms.Model.TransportOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_TransportOrder(");
            strSql.Append("Code,DispatchTime,FactDispatchTime,TimeLimit,ReceiptTime,WarningTime,BackTime,FactBackTime,DriverId,Advance,Payee,Repayment,FactRepayment,CarriageUnitPrice,Carriage,FactCarriage,CostTotal,Profit,AddTime,Status,CustomerRemarks,HaulwayRemarks,Remarks,FactTotalPrice,TotalPrice,UnitPrice,FactDispatchCount,DispatchCount,ReceivedWeight,UnloadingWeight,ArriveDate,FactArriveDate,LoadingCapacityRunning,NoLoadingCapacityRunning,Weight,FactWeight,LoadingDate");
            strSql.Append(") values (");
            strSql.Append("@Code,@DispatchTime,@FactDispatchTime,@TimeLimit,@ReceiptTime,@WarningTime,@BackTime,@FactBackTime,@DriverId,@Advance,@Payee,@Repayment,@FactRepayment,@CarriageUnitPrice,@Carriage,@FactCarriage,@CostTotal,@Profit,@AddTime,@Status,@CustomerRemarks,@HaulwayRemarks,@Remarks,@FactTotalPrice,@TotalPrice,@UnitPrice,@FactDispatchCount,@DispatchCount,@ReceivedWeight,@UnloadingWeight,@ArriveDate,@FactArriveDate,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@Weight,@FactWeight,@LoadingDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceiptTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WarningTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DriverId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CarriageUnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerRemarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@HaulwayRemarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FactTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReceivedWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnloadingWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ArriveDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactArriveDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@LoadingDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FactWeight", SqlDbType.Decimal,9)  
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.DispatchTime;
            parameters[2].Value = model.FactDispatchTime;
            parameters[3].Value = model.TimeLimit;
            parameters[4].Value = model.ReceiptTime;
            parameters[5].Value = model.WarningTime;
            parameters[6].Value = model.BackTime;
            parameters[7].Value = model.FactBackTime;
            parameters[8].Value = model.DriverId;
            parameters[9].Value = model.Advance;
            parameters[10].Value = model.Payee;
            parameters[11].Value = model.Repayment;
            parameters[12].Value = model.FactRepayment;
            parameters[13].Value = model.CarriageUnitPrice;
            parameters[14].Value = model.Carriage;
            parameters[15].Value = model.FactCarriage;
            parameters[16].Value = model.CostTotal;
            parameters[17].Value = model.Profit;
            parameters[18].Value = model.AddTime;
            parameters[19].Value = model.Status;
            parameters[20].Value = model.CustomerRemarks;
            parameters[21].Value = model.HaulwayRemarks;
            parameters[22].Value = model.Remarks;
            parameters[23].Value = model.FactTotalPrice;
            parameters[24].Value = model.TotalPrice;
            parameters[25].Value = model.UnitPrice;
            parameters[26].Value = model.FactDispatchCount;
            parameters[27].Value = model.DispatchCount;
            parameters[28].Value = model.ReceivedWeight;
            parameters[29].Value = model.UnloadingWeight;
            parameters[30].Value = model.ArriveDate;
            parameters[31].Value = model.FactArriveDate;
            parameters[32].Value = model.LoadingCapacityRunning;
            parameters[33].Value = model.NoLoadingCapacityRunning;
            parameters[34].Value = model.Weight;
            parameters[35].Value = model.LoadingDate;
            parameters[36].Value = model.FactWeight;

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
        public bool Update(DTcms.Model.TransportOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrder set ");

            strSql.Append(" Code = @Code , ");
            strSql.Append(" DispatchTime = @DispatchTime , ");
            strSql.Append(" FactDispatchTime = @FactDispatchTime , ");
            strSql.Append(" TimeLimit = @TimeLimit , ");
            strSql.Append(" ReceiptTime = @ReceiptTime , ");
            strSql.Append(" WarningTime = @WarningTime , ");
            strSql.Append(" BackTime = @BackTime , ");
            strSql.Append(" FactBackTime = @FactBackTime , ");
            strSql.Append(" DriverId = @DriverId , ");
            strSql.Append(" Advance = @Advance , ");
            strSql.Append(" Payee = @Payee , ");
            strSql.Append(" Repayment = @Repayment , ");
            strSql.Append(" FactRepayment = @FactRepayment , ");
            strSql.Append(" CarriageUnitPrice = @CarriageUnitPrice , ");
            strSql.Append(" Carriage = @Carriage , ");
            strSql.Append(" FactCarriage = @FactCarriage , ");
            strSql.Append(" CostTotal = @CostTotal , ");
            strSql.Append(" Profit = @Profit , ");
            strSql.Append(" AddTime = @AddTime , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" CustomerRemarks = @CustomerRemarks , ");
            strSql.Append(" HaulwayRemarks = @HaulwayRemarks , ");
            strSql.Append(" Remarks = @Remarks , ");
            strSql.Append(" FactTotalPrice = @FactTotalPrice , ");
            strSql.Append(" TotalPrice = @TotalPrice , ");
            strSql.Append(" UnitPrice = @UnitPrice , ");
            strSql.Append(" FactDispatchCount = @FactDispatchCount , ");
            strSql.Append(" DispatchCount = @DispatchCount , ");
            strSql.Append(" ReceivedWeight = @ReceivedWeight , ");
            strSql.Append(" UnloadingWeight = @UnloadingWeight , ");
            strSql.Append(" ArriveDate = @ArriveDate , ");
            strSql.Append(" FactArriveDate = @FactArriveDate , ");
            strSql.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
            strSql.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
            strSql.Append(" Weight = @Weight , ");
            strSql.Append(" FactWeight = @FactWeight , ");
            strSql.Append(" LoadingDate = @LoadingDate  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceiptTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WarningTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DriverId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CarriageUnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@CustomerRemarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@HaulwayRemarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FactTotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReceivedWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UnloadingWeight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ArriveDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactArriveDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Weight", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@LoadingDate", SqlDbType.DateTime),
                        new SqlParameter("@FactWeight", SqlDbType.Decimal,9)  
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.DispatchTime;
            parameters[3].Value = model.FactDispatchTime;
            parameters[4].Value = model.TimeLimit;
            parameters[5].Value = model.ReceiptTime;
            parameters[6].Value = model.WarningTime;
            parameters[7].Value = model.BackTime;
            parameters[8].Value = model.FactBackTime;
            parameters[9].Value = model.DriverId;
            parameters[10].Value = model.Advance;
            parameters[11].Value = model.Payee;
            parameters[12].Value = model.Repayment;
            parameters[13].Value = model.FactRepayment;
            parameters[14].Value = model.CarriageUnitPrice;
            parameters[15].Value = model.Carriage;
            parameters[16].Value = model.FactCarriage;
            parameters[17].Value = model.CostTotal;
            parameters[18].Value = model.Profit;
            parameters[19].Value = model.AddTime;
            parameters[20].Value = model.Status;
            parameters[21].Value = model.CustomerRemarks;
            parameters[22].Value = model.HaulwayRemarks;
            parameters[23].Value = model.Remarks;
            parameters[24].Value = model.FactTotalPrice;
            parameters[25].Value = model.TotalPrice;
            parameters[26].Value = model.UnitPrice;
            parameters[27].Value = model.FactDispatchCount;
            parameters[28].Value = model.DispatchCount;
            parameters[29].Value = model.ReceivedWeight;
            parameters[30].Value = model.UnloadingWeight;
            parameters[31].Value = model.ArriveDate;
            parameters[32].Value = model.FactArriveDate;
            parameters[33].Value = model.LoadingCapacityRunning;
            parameters[34].Value = model.NoLoadingCapacityRunning;
            parameters[35].Value = model.Weight;
            parameters[36].Value = model.LoadingDate;
            parameters[37].Value = model.FactWeight;
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

        public bool Update(DTcms.Model.TransportOrder model, IList<Model.Order> orders, IList<Model.Consumption> consumptions)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update mtms_TransportOrder set ");

                        strSql.Append(" Code = @Code , ");
                        strSql.Append(" DispatchTime = @DispatchTime , ");
                        strSql.Append(" FactDispatchTime = @FactDispatchTime , ");
                        strSql.Append(" TimeLimit = @TimeLimit , ");
                        strSql.Append(" ReceiptTime = @ReceiptTime , ");
                        strSql.Append(" WarningTime = @WarningTime , ");
                        strSql.Append(" BackTime = @BackTime , ");
                        strSql.Append(" FactBackTime = @FactBackTime , ");
                        strSql.Append(" DriverId = @DriverId , ");
                        strSql.Append(" Advance = @Advance , ");
                        strSql.Append(" Payee = @Payee , ");
                        strSql.Append(" Repayment = @Repayment , ");
                        strSql.Append(" FactRepayment = @FactRepayment , ");
                        strSql.Append(" CarriageUnitPrice = @CarriageUnitPrice , ");
                        strSql.Append(" Carriage = @Carriage , ");
                        strSql.Append(" FactCarriage = @FactCarriage , ");
                        strSql.Append(" CostTotal = @CostTotal , ");
                        strSql.Append(" Profit = @Profit , ");
                        strSql.Append(" AddTime = @AddTime , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" CustomerRemarks = @CustomerRemarks , ");
                        strSql.Append(" HaulwayRemarks = @HaulwayRemarks , ");
                        strSql.Append(" Remarks = @Remarks , ");
                        strSql.Append(" FactTotalPrice = @FactTotalPrice , ");
                        strSql.Append(" TotalPrice = @TotalPrice , ");
                        strSql.Append(" UnitPrice = @UnitPrice , ");
                        strSql.Append(" FactDispatchCount = @FactDispatchCount , ");
                        strSql.Append(" DispatchCount = @DispatchCount , ");
                        strSql.Append(" ReceivedWeight = @ReceivedWeight , ");
                        strSql.Append(" UnloadingWeight = @UnloadingWeight , ");
                        strSql.Append(" ArriveDate = @ArriveDate , ");
                        strSql.Append(" FactArriveDate = @FactArriveDate , ");
                        strSql.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
                        strSql.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
                        strSql.Append(" Weight = @Weight , ");
                        strSql.Append(" FactWeight = @FactWeight , ");
                        strSql.Append(" LoadingDate = @LoadingDate  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                                    new SqlParameter("@ReceiptTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@WarningTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@DriverId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@CarriageUnitPrice", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                                    new SqlParameter("@Status", SqlDbType.Int,4) ,            
                                    new SqlParameter("@CustomerRemarks", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@HaulwayRemarks", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@Remarks", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@FactTotalPrice", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@DispatchCount", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@ReceivedWeight", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@UnloadingWeight", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@ArriveDate", SqlDbType.DateTime) ,            
                                    new SqlParameter("@FactArriveDate", SqlDbType.DateTime) ,            
                                    new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@Weight", SqlDbType.Decimal,9) ,            
                                    new SqlParameter("@LoadingDate", SqlDbType.DateTime),
                                    new SqlParameter("@FactWeight", SqlDbType.Decimal,9)  
              
                        };

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.Code;
                        parameters[2].Value = model.DispatchTime;
                        parameters[3].Value = model.FactDispatchTime;
                        parameters[4].Value = model.TimeLimit;
                        parameters[5].Value = model.ReceiptTime;
                        parameters[6].Value = model.WarningTime;
                        parameters[7].Value = model.BackTime;
                        parameters[8].Value = model.FactBackTime;
                        parameters[9].Value = model.DriverId;
                        parameters[10].Value = model.Advance;
                        parameters[11].Value = model.Payee;
                        parameters[12].Value = model.Repayment;
                        parameters[13].Value = model.FactRepayment;
                        parameters[14].Value = model.CarriageUnitPrice;
                        parameters[15].Value = model.Carriage;
                        parameters[16].Value = model.FactCarriage;
                        parameters[17].Value = model.CostTotal;
                        parameters[18].Value = model.Profit;
                        parameters[19].Value = model.AddTime;
                        parameters[20].Value = model.Status;
                        parameters[21].Value = model.CustomerRemarks;
                        parameters[22].Value = model.HaulwayRemarks;
                        parameters[23].Value = model.Remarks;
                        parameters[24].Value = model.FactTotalPrice;
                        parameters[25].Value = model.TotalPrice;
                        parameters[26].Value = model.UnitPrice;
                        parameters[27].Value = model.FactDispatchCount;
                        parameters[28].Value = model.DispatchCount;
                        parameters[29].Value = model.ReceivedWeight;
                        parameters[30].Value = model.UnloadingWeight;
                        parameters[31].Value = model.ArriveDate;
                        parameters[32].Value = model.FactArriveDate;
                        parameters[33].Value = model.LoadingCapacityRunning;
                        parameters[34].Value = model.NoLoadingCapacityRunning;
                        parameters[35].Value = model.Weight;
                        parameters[36].Value = model.LoadingDate;
                        parameters[37].Value = model.FactWeight;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        #region 订单====================
                        if (orders.Count > 0)
                        {
                            Order orderDAL = new Order();
                            foreach (Model.Order order in orders)
                            {
                                orderDAL.UpdateField(conn, trans, order.Id,
                                    "UnitPrice = " + order.UnitPrice + ", Weight = " + order.Weight + ", Freight = " + order.Freight + ", PaidFreight = " + order.PaidFreight + ", UnpaidFreight = " + order.UnpaidFreight + ", Status = 1");
                            }
                        }
                        #endregion

                        #region 费用====================
                        Consumption consumptionDAL = new Consumption();
                        consumptionDAL.Delete(conn, trans, model.Id);
                        if (consumptions.Count > 0)
                        {
                            foreach (Model.Consumption consumption in consumptions)
                            {
                                consumptionDAL.Add(conn, trans, consumption);
                            }
                        }
                        #endregion

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }

            return true;

        }

        public int UpdateField(SqlConnection conn, SqlTransaction trans, int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrder set " + strValue);
            strSql.Append(" where Id=" + id);

            return DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString());
        }

        public bool Update(int id, DateTime warningTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrder set ");

            strSql.Append(" WarningTime = @WarningTime ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@WarningTime", SqlDbType.DateTime)         
              
            };

            parameters[0].Value = id;
            parameters[1].Value = warningTime;
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
            strSql.Append("delete from mtms_TransportOrder ");
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
            strSql.Append("delete from mtms_TransportOrder ");
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
        public DTcms.Model.TransportOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Code, DispatchTime, FactDispatchTime, TimeLimit, ReceiptTime, WarningTime, BackTime, FactBackTime, DriverId, Advance, Payee, Repayment, FactRepayment, CarriageUnitPrice, Carriage, FactCarriage, CostTotal, Profit, AddTime, Status, CustomerRemarks, HaulwayRemarks, Remarks, FactTotalPrice, TotalPrice, UnitPrice, FactDispatchCount, DispatchCount, ReceivedWeight, UnloadingWeight, ArriveDate, FactArriveDate, LoadingCapacityRunning, NoLoadingCapacityRunning, Weight, FactWeight, LoadingDate  ");
            strSql.Append("  from mtms_TransportOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DTcms.Model.TransportOrder model = new DTcms.Model.TransportOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["DispatchTime"].ToString() != "")
                {
                    model.DispatchTime = DateTime.Parse(ds.Tables[0].Rows[0]["DispatchTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactDispatchTime"].ToString() != "")
                {
                    model.FactDispatchTime = DateTime.Parse(ds.Tables[0].Rows[0]["FactDispatchTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TimeLimit"].ToString() != "")
                {
                    model.TimeLimit = int.Parse(ds.Tables[0].Rows[0]["TimeLimit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceiptTime"].ToString() != "")
                {
                    model.ReceiptTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceiptTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WarningTime"].ToString() != "")
                {
                    model.WarningTime = DateTime.Parse(ds.Tables[0].Rows[0]["WarningTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BackTime"].ToString() != "")
                {
                    model.BackTime = DateTime.Parse(ds.Tables[0].Rows[0]["BackTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactBackTime"].ToString() != "")
                {
                    model.FactBackTime = DateTime.Parse(ds.Tables[0].Rows[0]["FactBackTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DriverId"].ToString() != "")
                {
                    model.DriverId = int.Parse(ds.Tables[0].Rows[0]["DriverId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Advance"].ToString() != "")
                {
                    model.Advance = decimal.Parse(ds.Tables[0].Rows[0]["Advance"].ToString());
                }
                model.Payee = ds.Tables[0].Rows[0]["Payee"].ToString();
                if (ds.Tables[0].Rows[0]["Repayment"].ToString() != "")
                {
                    model.Repayment = decimal.Parse(ds.Tables[0].Rows[0]["Repayment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactRepayment"].ToString() != "")
                {
                    model.FactRepayment = decimal.Parse(ds.Tables[0].Rows[0]["FactRepayment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CarriageUnitPrice"].ToString() != "")
                {
                    model.CarriageUnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["CarriageUnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Carriage"].ToString() != "")
                {
                    model.Carriage = decimal.Parse(ds.Tables[0].Rows[0]["Carriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactCarriage"].ToString() != "")
                {
                    model.FactCarriage = decimal.Parse(ds.Tables[0].Rows[0]["FactCarriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CostTotal"].ToString() != "")
                {
                    model.CostTotal = decimal.Parse(ds.Tables[0].Rows[0]["CostTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Profit"].ToString() != "")
                {
                    model.Profit = decimal.Parse(ds.Tables[0].Rows[0]["Profit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.CustomerRemarks = ds.Tables[0].Rows[0]["CustomerRemarks"].ToString();
                model.HaulwayRemarks = ds.Tables[0].Rows[0]["HaulwayRemarks"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["FactTotalPrice"].ToString() != "")
                {
                    model.FactTotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["FactTotalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactDispatchCount"].ToString() != "")
                {
                    model.FactDispatchCount = decimal.Parse(ds.Tables[0].Rows[0]["FactDispatchCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DispatchCount"].ToString() != "")
                {
                    model.DispatchCount = decimal.Parse(ds.Tables[0].Rows[0]["DispatchCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReceivedWeight"].ToString() != "")
                {
                    model.ReceivedWeight = decimal.Parse(ds.Tables[0].Rows[0]["ReceivedWeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UnloadingWeight"].ToString() != "")
                {
                    model.UnloadingWeight = decimal.Parse(ds.Tables[0].Rows[0]["UnloadingWeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArriveDate"].ToString() != "")
                {
                    model.ArriveDate = DateTime.Parse(ds.Tables[0].Rows[0]["ArriveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactArriveDate"].ToString() != "")
                {
                    model.FactArriveDate = DateTime.Parse(ds.Tables[0].Rows[0]["FactArriveDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString() != "")
                {
                    model.LoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString() != "")
                {
                    model.NoLoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = decimal.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactWeight"].ToString() != "")
                {
                    model.FactWeight = decimal.Parse(ds.Tables[0].Rows[0]["FactWeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoadingDate"].ToString() != "")
                {
                    model.LoadingDate = DateTime.Parse(ds.Tables[0].Rows[0]["LoadingDate"].ToString());
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
            strSql.Append(" FROM mtms_TransportOrder ");
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
            strSql.Append(" FROM mtms_TransportOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetSelectList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.Id AS Id, A.Code, B.CarNumber, B.RealName AS Driver ");
            strSql.Append("FROM mtms_TransportOrder A LEFT JOIN mtms_Driver B ON A.DriverId = B.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetTotalList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*, B.CarNumber, B.RealName AS Driver, B.LinkTel AS DriverTel, B.LinkAddress AS DriverAddress, B.IdCardNumber ");
            strSql.Append("FROM mtms_TransportOrder A LEFT JOIN mtms_Driver B ON A.DriverId = B.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*, B.CarNumber, B.RealName AS Driver, B.LinkTel AS DriverTel, B.LinkAddress AS DriverAddress, B.IdCardNumber ");
            strSql.Append("FROM mtms_TransportOrder A LEFT JOIN mtms_Driver B ON A.DriverId = B.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //throw new Exception(PagingHelper.CreatePagingSql(1, pageSize, pageIndex, strSql.ToString(), filedOrder));
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
