package com.allen.server.socketManager;



public interface SocketManager {
	public abstract boolean Add(byte[] bstream,int socketID) throws Exception;//�����յ������ݴ���Ȼ�������ݿ�
	public abstract boolean GiveOrder(int FacNumber,byte[] order);
	boolean GiveOrder(long FacNumber, byte[] order);
}
