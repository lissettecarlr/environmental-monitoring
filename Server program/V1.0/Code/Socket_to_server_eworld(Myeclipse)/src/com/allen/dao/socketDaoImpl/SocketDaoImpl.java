package com.allen.dao.socketDaoImpl;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;

import com.allen.dao.dbConnection.DB_Connection;
import com.allen.dao.socketDao.SocketDao;
import com.allen.model.Eworld;
import com.allen.model.EworldCO2;
import com.allen.model.EworldDust;
import com.allen.model.EworldFormaldehyde;
import com.allen.model.EworldHumidity;
import com.allen.model.EworldTemperayure;

public class SocketDaoImpl implements SocketDao{

	
	
	String SensorTable_name   = "Sensor";
	String OrderTable_name    = "Order";
	String FacilityTable_name = "Facility";
	String UserTable_name     = "User";
	String ColName = "(DeviceName,DeviceNumber,Type,DataValue,Battery,ReceiveTime)";
	@Override
	public boolean Save(Eworld eworld) throws Exception {
		return false;
	}

	@Override
	public boolean SaveTem(EworldTemperayure eworldT) throws Exception {
		
		java.util.Date datetime = new java.util.Date(System.currentTimeMillis());
//		System.out.println(datetime);
//		java.sql.Time date1 = new java.sql.Time(datetime.getTime());
//		System.out.println(date1);
		
		java.sql.Timestamp timeNow = new java.sql.Timestamp(datetime.getTime());
		System.out.println(timeNow);

		
		String condition = "Insert into "+SensorTable_name+ColName+" values('"/*+"?"+
																	"','"*/+eworldT.getDeviceName()+
																	"','"+eworldT.geteId()+
																	"','"+eworldT.geteType()+
																	"','"+eworldT.geteData()+
																	"','"+eworldT.getePower()+
																	"','"+timeNow+
																	"')";
		return InsertIntoMysql(condition);
	}

	@Override
	public boolean SaveHum(EworldHumidity eworldH) throws Exception {
		java.util.Date datetime = new java.util.Date(System.currentTimeMillis());	
		java.sql.Timestamp timeNow = new java.sql.Timestamp(datetime.getTime());
		System.out.println(timeNow);
		String condition = "Insert into "+SensorTable_name+ColName+" values('"/*+"?"+
				"','"*/+eworldH.getDeviceName()+
				"','"+eworldH.geteId()+
				"','"+eworldH.geteType()+
				"','"+eworldH.geteData()+
				"','"+eworldH.getePower()+
				"','"+timeNow+
				"')";
		return InsertIntoMysql(condition);
		
	}

	@Override
	public boolean SaveCO2(EworldCO2 eworldCo2) throws Exception {
		java.util.Date datetime = new java.util.Date(System.currentTimeMillis());	
		java.sql.Timestamp timeNow = new java.sql.Timestamp(datetime.getTime());
		System.out.println(timeNow);
		String condition = "Insert into "+SensorTable_name+ColName+" values('"/*+"?"+
				"','"*/+eworldCo2.getDeviceName()+
				"','"+eworldCo2.geteId()+
				"','"+eworldCo2.geteType()+
				"','"+eworldCo2.geteData()+
				"','"+eworldCo2.getePower()+
				"','"+timeNow+
				"')";
		return InsertIntoMysql(condition);
		
	}

	@Override
	public boolean SaveDust(EworldDust eworldDust) throws Exception {
		java.util.Date datetime = new java.util.Date(System.currentTimeMillis());	
		java.sql.Timestamp timeNow = new java.sql.Timestamp(datetime.getTime());
		System.out.println(timeNow);
		String condition = "Insert into "+SensorTable_name+ColName+" values('"/*+"?"+
				"','"*/+eworldDust.getDeviceName()+
				"','"+eworldDust.geteId()+
				"','"+eworldDust.geteType()+
				"','"+eworldDust.geteData()+
				"','"+eworldDust.getePower()+
				"','"+timeNow+
				"')";	
		return InsertIntoMysql(condition);
		
	}

	@Override
	public boolean SaveFor(EworldFormaldehyde eworldFor) throws Exception {
		java.util.Date datetime = new java.util.Date(System.currentTimeMillis());	
		java.sql.Timestamp timeNow = new java.sql.Timestamp(datetime.getTime());
		System.out.println(timeNow);
		String condition = "Insert into "+SensorTable_name+ColName+" values('"/*+"?"+
				"','"*/+eworldFor.getDeviceName()+
				"','"+eworldFor.geteId()+
				"','"+eworldFor.geteType()+
				"','"+eworldFor.geteData()+
				"','"+eworldFor.getePower()+
				"','"+timeNow+
				"')";				
		return InsertIntoMysql(condition);
		
	}
	public static boolean InsertIntoMysql(String condition){
		Connection con;
		Statement sql;
		try {
			Class.forName("com.mysql.jdbc.Driver");
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		DB_Connection DB_C = new DB_Connection();;
		String uri = DB_C.getConnection_2();

		try{
			con = DriverManager.getConnection(uri);
			sql = con.createStatement();
			sql.executeUpdate(condition);
			con.close();
		}catch(SQLException exp){
			String backNews=""+exp;
			System.out.println(backNews);
			return false;
		}
		return true;
	}

}
