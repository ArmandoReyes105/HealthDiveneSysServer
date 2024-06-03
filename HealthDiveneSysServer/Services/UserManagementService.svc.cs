using HealthDiveneSysServer.Converters;
using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Configuration;

namespace HealthDiveneSysServer
{
    
    public class UserManagementService : UserManagement
    {
        public int AddPatient(Patient patient)
        {
            int result;

            using (var context = new HealthDivineEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        People person = EntityToDBEntity.Convert(patient.Person); 
                        context.People.Add(person);
                        context.SaveChanges();

                        Patients newPatient = EntityToDBEntity.Convert(patient); 
                        newPatient.IdPerson = person.IdPerson;
                        context.Patients.Add(newPatient);
                        context.SaveChanges();

                        Model.MedicalInformation medicalInformation = EntityToDBEntity.Convert(patient.MedicalInformation);
                        Model.GeneralInformation generalInformation = EntityToDBEntity.Convert(patient.GeneralInfomation);
                        Model.HabitsAndGoals habitsAndGoals = EntityToDBEntity.Convert(patient.HabitsAndGoals);
                        medicalInformation.IdPatient = newPatient.IdPatient;
                        generalInformation.IdPatient = newPatient.IdPatient; 
                        habitsAndGoals.IdPatient = newPatient.IdPatient;

                        context.MedicalInformation.Add(medicalInformation); 
                        context.GeneralInformation.Add(generalInformation);
                        context.HabitsAndGoals.Add(habitsAndGoals);
                        context.SaveChanges();

                        result = 1;
                        transaction.Commit(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.ToString());
                        result = 0; 
                    }
                     
                }
            }
            
            return result;
        }

        public int UpdatePatient(Patient patient)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            People dbPerson = context.People.FirstOrDefault(d => d.IdPerson == patient.Person.IdPerson);
                            Patients dbPatient = context.Patients.FirstOrDefault(d => d.IdPatient == patient.IdPatient);

                            dbPerson.Names = patient.Person.Names;
                            dbPerson.FirstLastName = patient.Person.FirstLastName;
                            dbPerson.SecondLastName = patient.Person.SecondLastName;
                            dbPerson.Email = patient.Person.Email;
                            dbPerson.Phone = patient.Person.Phone;

                            dbPatient.Birthdate = patient.Birthday;
                            dbPatient.Gender = patient.Gender;
                            dbPatient.Height = patient.Height;

                            result = context.SaveChanges();
                            transaction.Commit();

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                }
            }

            return result; 
        }

        public int UpdateMedicalInformation(Entities.MedicalInformation information)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    Model.MedicalInformation dbInformation = context.MedicalInformation.FirstOrDefault(d => d.IdMedicalInformation == information.IdMedicalInformation);

                    dbInformation.ChronicDiseases = information.ChronicDiseases; 
                    dbInformation.HereditaryFamilyHistory = information.HereditaryFamilyHistory;
                    dbInformation.GastrointestinalDiseases = information.GastrointestinalDiseases; 
                    dbInformation.FoodAllergies = information.FoodAllergies;
                    dbInformation.NOFoodAllergies = information.NonFoodAllergies; 
                    dbInformation.SurgicalHistory = information.SurgicalHistory;
                    dbInformation.Medications = information.Medications;
                    dbInformation.GeneralMedicalComments = information.GeneralMedicalComments;

                    result = context.SaveChanges();

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Ocurrio un error: " + ex.ToString());
                }
            }

            return result;
        }

        public Patient GetPatient(int id)
        {
            Patient result; 

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var patient = context.Patients.Where(d => d.IdPatient == id).FirstOrDefault();
                    var person = context.People.Where(d => d.IdPerson == patient.IdPerson).FirstOrDefault();
                    var medicalInfo = context.MedicalInformation.Where(d => d.IdPatient == id).FirstOrDefault();
                    var generalInfo = context.GeneralInformation.Where(d => d.IdPatient == id).FirstOrDefault();
                    var habitsInfo = context.HabitsAndGoals.Where(d => d.IdPatient == id).FirstOrDefault();

                    Person dataPerson = DBEntityToEntity.Convert(person);
                    Entities.MedicalInformation dataMedcial = DBEntityToEntity.Convert(medicalInfo);
                    Entities.GeneralInformation dataGeneral = DBEntityToEntity.Convert(generalInfo);
                    Entities.HabitsAndGoals dataHabits = DBEntityToEntity.Convert(habitsInfo);

                    result = DBEntityToEntity.Convert(patient, dataPerson, dataMedcial, dataGeneral, dataHabits);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = null;
                }
                
            }

            return result; 
        }
                
        public List<Patient> GetMyPatients(int NutririonistId)
        {
            List<Patient> result = new List<Patient>();

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var patients = context.Patients.Where(d => d.IdNutritionist == NutririonistId);

                    foreach (var patient in patients)
                    {
                        var person = context.People.Where(d => d.IdPerson == patient.IdPerson).FirstOrDefault();
                        Person dataPerson = DBEntityToEntity.Convert(person);

                        var medicalInfo = context.MedicalInformation.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.MedicalInformation dataMedicalInfo = DBEntityToEntity.Convert(medicalInfo);

                        var generalInfo = context.GeneralInformation.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.GeneralInformation dataGeneralInfo = DBEntityToEntity.Convert(generalInfo);

                        var habitsInfo = context.HabitsAndGoals.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.HabitsAndGoals dataHabitsAndGoals = DBEntityToEntity.Convert(habitsInfo);

                        Patient dataPatient = DBEntityToEntity.Convert(patient, dataPerson, dataMedicalInfo, dataGeneralInfo, dataHabitsAndGoals);
                        result.Add(dataPatient);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = null; 
                }
                
            }

            return result; 
        }

        public List<Patient> FilterPatients(int nutritionistId, string filter)
        {
            List<Patient> result = new List<Patient>();

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var patients = (from a in context.Patients
                                    join b in context.People on a.IdPerson equals b.IdPerson 
                                    where a.IdNutritionist == nutritionistId && b.Names.Contains(filter) || b.FirstLastName.Contains(filter) || b.SecondLastName.Contains(filter)
                                    select a).ToList();

                    foreach (var patient in patients)
                    {
                        var person = context.People.Where(d => d.IdPerson == patient.IdPerson).FirstOrDefault();
                        Person dataPerson = DBEntityToEntity.Convert(person);

                        var medicalInfo = context.MedicalInformation.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.MedicalInformation dataMedicalInfo = DBEntityToEntity.Convert(medicalInfo);

                        var generalInfo = context.GeneralInformation.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.GeneralInformation dataGeneralInfo = DBEntityToEntity.Convert(generalInfo);

                        var habitsInfo = context.HabitsAndGoals.Where(d => d.IdPatient == patient.IdPatient).FirstOrDefault();
                        Entities.HabitsAndGoals dataHabitsAndGoals = DBEntityToEntity.Convert(habitsInfo);

                        Patient dataPatient = DBEntityToEntity.Convert(patient, dataPerson, dataMedicalInfo, dataGeneralInfo, dataHabitsAndGoals);
                        result.Add(dataPatient);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    result = null;
                }

            }

            return result;
        }

        public Nutritionist LogIn(string username, string password)
        {
            Nutritionist result = new Nutritionist();

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var account = context.Account.Where(e => e.Username == username && e.AccountPassword == password).FirstOrDefault();

                    if (account != null)
                    {
                        var nutritionist = context.Nutritionists.Where(e => e.IdNutritionist == account.IdNutritionist).FirstOrDefault();
                        var dbperson = context.People.Where(e => e.IdPerson == nutritionist.IdPerson).FirstOrDefault();

                        Person person = DBEntityToEntity.Convert(dbperson); 

                        result.IdNutritionist = nutritionist.IdNutritionist; 
                        result.Person = person;
                        
                    }
                    else
                    {
                        result.IdNutritionist = 0; 
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                    result = null; 
                }
            }

            return result; 
        }
    }
}
