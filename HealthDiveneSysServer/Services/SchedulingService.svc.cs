using HealthDiveneSysServer.Converters;
using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthDiveneSysServer
{
    public class SchedulingService : Scheduling
    {
        
        public int CreateAppointment(Entities.Appointment appointment)
        {
            int result;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    Model.Appointment dbAppointment = EntityToDBEntity.Convert(appointment);
                    context.Appointment.Add(dbAppointment);
                    context.SaveChanges();
                    result = 1; 
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    result = 0;
                }
            }

            return result;
        }

        public int DeleteAppointment(int appointmentId)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    Model.Appointment appointment = context.Appointment.FirstOrDefault(d => d.IdAppointment == appointmentId);

                    if (appointment != null)
                    {
                        context.Appointment.Remove(appointment);
                        context.SaveChanges();
                        result = 1;
                    }
                    else
                    {
                        Debug.WriteLine("No se encontró ninguna cita con el ID proporcionado: " + appointmentId);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error al eliminar la cita: " + ex.ToString());
                }
            }

            return result;

        }

        public int UpdateAppointment(Entities.Appointment appointment)
        {

            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    Model.Appointment dbAppointment = context.Appointment.FirstOrDefault(d => d.IdAppointment == appointment.IdAppointment);
                    
                    if (dbAppointment != null)
                    {
                        dbAppointment.AppointmentDate = appointment.AppointmentDate; 
                        dbAppointment.StartTime = appointment.StartTime;
                        dbAppointment.EndTime = appointment.EndTime;

                        result = context.SaveChanges(); 
                    }
                    else
                    {
                        Debug.WriteLine("No se encontró ninguna cita con el ID: " + appointment.IdAppointment); 
                    }
                }catch (Exception ex)
                {
                    Debug.WriteLine("Error al actualizar la cita: " + ex.ToString()); 
                }
            }

            return result; 

        }

        public List<Entities.Appointment> GetAppointmentsByMonth(int nutritionistId, int month, int year)
        {
            List<Entities.Appointment> result = new List<Entities.Appointment>();

            using (var context = new HealthDivineEntities())
            {
                var appointments = context.Appointment.Where(d => d.IdNutritionist == nutritionistId && d.AppointmentDate.Value.Year == year && d.AppointmentDate.Value.Month == month)
                    .OrderBy(d => d.AppointmentDate)
                    .ThenBy(d => d.StartTime);

                foreach (var appointment in appointments)
                {
                        Entities.Appointment newAppointment = DBEntityToEntity.Convert(appointment);
                        result.Add(newAppointment);
                }
            }

            return result;
        }

        public List<Entities.Appointment> GetAppointmentsByDay(DateTime day, int nutritionistId)
        {
            List<Entities.Appointment> result = new List<Entities.Appointment>();

            using (var context = new HealthDivineEntities())
            {
                var appointments = context.Appointment.Where(d => d.IdNutritionist == nutritionistId && d.AppointmentDate == day);

                foreach (var appointment in appointments)
                {
                    Entities.Appointment newAppointment = DBEntityToEntity.Convert(appointment);
                    result.Add(newAppointment);
                }
            }

            return result;
        }

    }
}
