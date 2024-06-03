using HealthDiveneSysServer.Converters;
using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HealthDiveneSysServer
{
    public class ProgressManagementService : IProgressManagementService
    {
        public int AddNewDiagnosis(Diagnosis diagnosis)
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
                            Diagnoses dbDiagnosis = EntityToDBEntity.ConvertDiagnoses(diagnosis);
                            context.Diagnoses.Add(dbDiagnosis);
                            context.SaveChanges();

                            Measures dbMeasures = EntityToDBEntity.ConvertMeasures(diagnosis.Measure);
                            dbMeasures.IdDiagnosis = dbDiagnosis.IdDiagnosis;
                            dbMeasures.IdPatient = dbDiagnosis.IdPatient;
                            context.Measures.Add(dbMeasures);

                            Model.BodyCompositions dbCompositions = EntityToDBEntity.ConvertBodyComposition(diagnosis.BodyComposition);
                            dbCompositions.IdDiagnosis = dbDiagnosis.IdDiagnosis;
                            dbCompositions.IdPatient = dbDiagnosis.IdPatient; 
                            context.BodyCompositions.Add(dbCompositions);

                            if(diagnosis.Image != null)
                            {
                                Model.Images image = new Images(); 

                                image.ImageComments = diagnosis.Image.Comments;
                                image.ImageData = diagnosis.Image.Image;
                                image.IdDiagnosis = dbDiagnosis.IdDiagnosis; 

                                context.Images.Add(image);
                            }

                            context.SaveChanges(); 

                            result = 1;
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

        public List<Diagnosis> GetDiagnosisByPatient(int patientId)
        {

            List<Diagnosis> diagnoses = new List<Diagnosis>();

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbDiagnoses = context.Diagnoses.Where(e => e.IdPatient == patientId);

                    foreach (var dbDiagnosis in dbDiagnoses)
                    {
                        var dbMeasure = context.Measures.Where(e => e.IdDiagnosis == dbDiagnosis.IdDiagnosis).FirstOrDefault();
                        var dbBodyComposition = context.BodyCompositions.Where(e => e.IdDiagnosis == dbDiagnosis.IdDiagnosis).FirstOrDefault();

                        Entities.BodyCompositions bodyCompositions = DBEntityToEntity.ConvertBodyComposition(dbBodyComposition); 
                        Measure measure = DBEntityToEntity.ConvertMeasure(dbMeasure);

                        Diagnosis diagnosis = DBEntityToEntity.ConvertDiagnosis(dbDiagnosis, bodyCompositions, measure);
                        diagnoses.Add(diagnosis);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    diagnoses = null; 
                }
            }

            return diagnoses; 

        }

        public Diagnosis GetLastDiagnosis(int patientId)
        {
            Diagnosis diagnosis = null;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbDiagnosis = context.Diagnoses.Where(e => e.IdPatient == patientId).OrderByDescending(e => e.DiagnosisDate).FirstOrDefault();
                    if(dbDiagnosis != null)
                    {
                        var dbMeasures = context.Measures.Where(e => e.IdDiagnosis == dbDiagnosis.IdDiagnosis).FirstOrDefault();
                        var dbBodyComposition = context.BodyCompositions.Where(e => e.IdDiagnosis == dbDiagnosis.IdDiagnosis).FirstOrDefault();

                        Measure measure = DBEntityToEntity.ConvertMeasure(dbMeasures);
                        Entities.BodyCompositions bodyCompositions = DBEntityToEntity.ConvertBodyComposition(dbBodyComposition);
                        diagnosis = DBEntityToEntity.ConvertDiagnosis(dbDiagnosis, bodyCompositions, measure);
                    }
                    else
                    {
                        diagnosis = new Diagnosis();
                        diagnosis.IdDiagnosis = 0; 
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); 
                }
            }

            return diagnosis; 
        }

        public List<Measure> GetMeasuresByPatient(int patientId)
        {
            List<Measure> result = new List<Measure>();

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var measures = context.Measures.Where(e => e.IdPatient == patientId);

                    foreach (var measure in measures)
                    {
                        result.Add(DBEntityToEntity.ConvertMeasure(measure)); 
                    }
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    result = null; 
                }
            }

            return result; 
        }

        public int UpdateBodyComposition(Entities.BodyCompositions bodyCompositions)
        {

            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbBodyComposition = context.BodyCompositions.Where(d => d.IdBodyComposition == bodyCompositions.IdBodyComposition).FirstOrDefault();

                    dbBodyComposition.VisceralFat = bodyCompositions.VisceralFat;
                    dbBodyComposition.TotalWeight = bodyCompositions.TotalWeight;
                    dbBodyComposition.WaterPercentage = bodyCompositions.WaterPercentage;
                    dbBodyComposition.FatPercentage = bodyCompositions.FatPercentage;
                    dbBodyComposition.MusclePercentage = bodyCompositions.MusclePercentage;

                    result = context.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

                return result; 
        }

        public int UpdateDiagnosis(Diagnosis diagnosis)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbDiagnosis = context.Diagnoses.Where(d => d.IdDiagnosis == diagnosis.IdDiagnosis).FirstOrDefault(); 

                    dbDiagnosis.PhysicalActivity = diagnosis.PhysicalActivity;
                    dbDiagnosis.PhysicalPerception = diagnosis.PhysicalPerception;
                    dbDiagnosis.Feeding = diagnosis.Feeding;
                    dbDiagnosis.Appetite = diagnosis.Appetite;
                    dbDiagnosis.WaterConsumption = diagnosis.WaterConsumption;
                    dbDiagnosis.Dream = diagnosis.Dream;
                    dbDiagnosis.StomachUpset = diagnosis.StomachUpset;
                    dbDiagnosis.EnergyLevel = diagnosis.EnergyLevel;
                    dbDiagnosis.StressLevel = diagnosis.StressLevel;
                    dbDiagnosis.SubstanceUse = diagnosis.SubstanceUse;
                    dbDiagnosis.GeneralComments = diagnosis.GeneralComments;

                    result = context.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public int UpdateMeasures(Measure measure)
        {
            int result = 0;

            using (var context = new HealthDivineEntities())
            {
                try
                {
                    var dbMeasure = context.Measures.Where(d => d.IdMeasures == measure.IdMeasure).FirstOrDefault(); 

                    dbMeasure.Chest = measure.Chest;
                    dbMeasure.Arm = measure.Arm;
                    dbMeasure.ContractedArm = measure.ContractedArm;
                    dbMeasure.Forearm = measure.Forearm;
                    dbMeasure.Waist = measure.Waist;
                    dbMeasure.Hip = measure.Hip;
                    dbMeasure.Thigh = measure.Thigh;
                    dbMeasure.Calf = measure.Calf;

                    result = context.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result; 
        }
    }
}
