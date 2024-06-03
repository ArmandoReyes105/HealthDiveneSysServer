using HealthDiveneSysServer.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace HealthDiveneSysServer
{
    [ServiceContract]
    public interface Scheduling
    {
        [OperationContract]
        int CreateAppointment(Appointment appointment);

        [OperationContract]
        int DeleteAppointment(int appointmentId);

        [OperationContract]
        int UpdateAppointment(Appointment appointment); 

        [OperationContract]
        List<Entities.Appointment> GetAppointmentsByMonth(int nutritionistId, int month, int year);

        [OperationContract]
        List<Entities.Appointment> GetAppointmentsByDay(DateTime day, int nutritionistId); 
    }
}
