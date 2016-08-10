package com.allen.server.socketManager;



public interface SocketManager {
	public abstract boolean Add(byte[] bstream,int socketID) throws Exception;//将接收到的数据处理，然后传入数据库
	public abstract boolean GiveOrder(int FacNumber,byte[] order);
	boolean GiveOrder(long FacNumber, byte[] order);
}
