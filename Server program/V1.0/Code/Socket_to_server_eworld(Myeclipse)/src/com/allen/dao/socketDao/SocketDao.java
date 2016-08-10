package com.allen.dao.socketDao;

import com.allen.model.Eworld;
import com.allen.model.EworldCO2;
import com.allen.model.EworldDust;
import com.allen.model.EworldFormaldehyde;
import com.allen.model.EworldHumidity;
import com.allen.model.EworldTemperayure;

public interface SocketDao {
	public boolean Save(Eworld eworld) throws Exception;
	public boolean SaveTem(EworldTemperayure eworldT) throws Exception;
	public boolean SaveHum(EworldHumidity eworldH) throws Exception;
	public boolean SaveCO2(EworldCO2 eworldCo2) throws Exception;
	public boolean SaveDust(EworldDust eworldDust) throws Exception;
	public boolean SaveFor(EworldFormaldehyde eworldFor) throws Exception;
}
