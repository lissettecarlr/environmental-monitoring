package com.allen.server.socketByteDeal;

import com.allen.model.Eworld;

public interface SocketByteDeal {
	public abstract void Deal(byte[] bstream,int socketID) throws Exception;//�����յ������ݴ���Ȼ�������ݿ�
	public abstract boolean Chick(byte[] bstream,int byteNumber) throws Exception;//�Ƚ���У�飬�������ǲ���������һ֡���ݣ��Ƿ���true

}