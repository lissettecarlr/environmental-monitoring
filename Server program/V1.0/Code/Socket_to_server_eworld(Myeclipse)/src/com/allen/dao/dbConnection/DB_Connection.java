package com.allen.dao.dbConnection;

public class DB_Connection {
	String Connection="jdbc:mysql://localhost:3306/ebox?"+
			"user=root&password=123456&characterEncoding=UTF8";
	String uri = "jdbc:mysql://localhost:3306/ebox?";
	String user = "user=root&password=123456&characterEncoding=UTF8";
	public String getConnection(){
		return Connection;
	}
	public String getConnection_2(){
		return uri+user;
	}
}
