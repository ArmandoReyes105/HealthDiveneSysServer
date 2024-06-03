using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;
using System;
using System.Collections.Generic;

namespace HealthDiveneSysServer.Converters
{
    public static class DBEntityToEntity
    {

        public static Person Convert(People dbPerson)
        {

            Person person = new Person();
            person.IdPerson = dbPerson.IdPerson;
            person.Names = dbPerson.Names;
            person.FirstLastName = dbPerson.FirstLastName;
            person.SecondLastName = dbPerson.SecondLastName;
            person.Email = dbPerson.Email;
            person.Phone = dbPerson.Phone;

            return person; 

        }

        public static Patient Convert(Patients dbPatient, Person person,Entities.MedicalInformation medical, Entities.GeneralInformation general, Entities.HabitsAndGoals goals)
        {
            Patient patient = new Patient();
            patient.IdPatient = dbPatient.IdPatient;
            patient.Height = (float)dbPatient.Height;
            patient.Birthday = (DateTime)dbPatient.Birthdate;
            patient.Gender = dbPatient.Gender; 
            patient.Nutritionist = (int)dbPatient.IdNutritionist;

            patient.Person = person;
            patient.MedicalInformation = medical;
            patient.GeneralInfomation = general;
            patient.HabitsAndGoals = goals; 

            return patient; 
        }

        public static Entities.MedicalInformation Convert(Model.MedicalInformation dbMedical)
        {
            Entities.MedicalInformation medicalInformation = new Entities.MedicalInformation();
            medicalInformation.IdMedicalInformation = dbMedical.IdMedicalInformation;
            medicalInformation.ChronicDiseases = dbMedical.ChronicDiseases;
            medicalInformation.HereditaryFamilyHistory = dbMedical.HereditaryFamilyHistory;
            medicalInformation.GastrointestinalDiseases = dbMedical.GastrointestinalDiseases; 
            medicalInformation.FoodAllergies = dbMedical.FoodAllergies;
            medicalInformation.NonFoodAllergies = dbMedical.NOFoodAllergies; 
            medicalInformation.SurgicalHistory = dbMedical.SurgicalHistory;
            medicalInformation.Medications = dbMedical.Medications;
            medicalInformation.GeneralMedicalComments = dbMedical.GeneralMedicalComments;

            return medicalInformation;
        }

        public static Entities.GeneralInformation Convert(Model.GeneralInformation dbGeneral)
        {

            Entities.GeneralInformation generalInformation = new Entities.GeneralInformation();
            generalInformation.IdGeneralInformation = dbGeneral.IdGeneralInformation;
            generalInformation.GeneralComments = dbGeneral.GeneralComments;
            generalInformation.PhysicalActivity = (int)dbGeneral.PhysicalActivity; 
            generalInformation.PhysicalActivityComments = dbGeneral.PhysicalActivityComments;
            generalInformation.FavoriteFoods = dbGeneral.FavoriteFoods; 
            generalInformation.NonFavoriteFoods = dbGeneral.NonFavoriteFoods;
            generalInformation.DietarySupplements = dbGeneral.DietarySupplements;
            generalInformation.NutritionalFamiliarity = dbGeneral.NutritionalFamiliarity;
            generalInformation.EatingEmotionalBehavior = dbGeneral.EatingEmotionalBehavior;

            return generalInformation;

        }

        public static Entities.HabitsAndGoals Convert(Model.HabitsAndGoals dbGoals)
        {
            Entities.HabitsAndGoals habitsAndGoals = new Entities.HabitsAndGoals();
            habitsAndGoals.IdHabitsAndGoals = dbGoals.IdHabitsAndGoals;
            habitsAndGoals.Caffeine = dbGoals.Caffeine; 
            habitsAndGoals.Alcohol = dbGoals.Alcohol;
            habitsAndGoals.Cigarette = dbGoals.Cigarette;
            habitsAndGoals.Drugs = dbGoals.Drugs;
            habitsAndGoals.HealthGoals = dbGoals.HealthGoals;
            habitsAndGoals.SpecificNutritionalGoals = dbGoals.SpecificNutritionalGoals; 
            habitsAndGoals.Expectations = dbGoals.Expectations;
            habitsAndGoals.GeneralComment = dbGoals.GeneralComments; 

            return habitsAndGoals;
        } 

        public static Entities.Appointment Convert(Model.Appointment dbAppointment)
        {
            Entities.Appointment appointment = new Entities.Appointment();
            appointment.IdAppointment = dbAppointment.IdAppointment;
            appointment.AppointmentDate = (DateTime)dbAppointment.AppointmentDate;
            appointment.StartTime = (TimeSpan)dbAppointment.StartTime; 
            appointment.EndTime = (TimeSpan)dbAppointment.EndTime;
            appointment.IdPatient = (int)dbAppointment.IdPatient;
            appointment.IdNutritionist = (int)dbAppointment.IdNutritionist; 
            return appointment;
        }

        public static Diagnosis ConvertDiagnosis(Model.Diagnoses dbDiagnosis, Entities.BodyCompositions bodyCompositions, Measure measure)
        {
            return new Diagnosis
            {
                IdDiagnosis = dbDiagnosis.IdDiagnosis,
                DiagnosisDate = (DateTime)dbDiagnosis.DiagnosisDate, 
                PhysicalActivity = dbDiagnosis.PhysicalActivity,
                PhysicalPerception = dbDiagnosis.PhysicalPerception,
                Feeding = dbDiagnosis.Feeding, 
                Appetite = dbDiagnosis.Appetite, 
                WaterConsumption = dbDiagnosis.WaterConsumption,
                Dream = dbDiagnosis.Dream,
                StomachUpset = dbDiagnosis.StomachUpset,
                EnergyLevel = dbDiagnosis.EnergyLevel,
                StressLevel = dbDiagnosis.StressLevel,
                SubstanceUse = dbDiagnosis.SubstanceUse,
                GeneralComments = dbDiagnosis.GeneralComments,
                PatientId = (int)dbDiagnosis.IdPatient, 
                BodyComposition = bodyCompositions, 
                Measure = measure
            }; 
        }

        public static Entities.BodyCompositions ConvertBodyComposition(Model.BodyCompositions dbBodyComposition)
        {
            return new Entities.BodyCompositions
            {
                IdBodyComposition = dbBodyComposition.IdBodyComposition,
                VisceralFat = (double)dbBodyComposition.VisceralFat, 
                TotalWeight = (double)dbBodyComposition.TotalWeight,
                WaterPercentage = (double)dbBodyComposition.WaterPercentage,
                FatPercentage = (double)dbBodyComposition.FatPercentage,
                MusclePercentage = (double)dbBodyComposition.MusclePercentage, 
                IdPatient = (int)dbBodyComposition.IdPatient,
                IdDiagnosis = (int)dbBodyComposition.IdDiagnosis
            };
        }

        public static Entities.Measure ConvertMeasure(Model.Measures dbMeasures)
        {
            return new Measure
            {
                IdMeasure = dbMeasures.IdMeasures,
                Chest = (double)dbMeasures.Chest,
                Arm = (double)dbMeasures.Arm,
                ContractedArm = (double)dbMeasures.ContractedArm,
                Forearm = (double)dbMeasures.Forearm,
                Waist = (double)dbMeasures.Waist,
                Hip = (double)dbMeasures.Hip,
                Thigh = (double)dbMeasures.Thigh,
                Calf = (double)dbMeasures.Calf,
                IdPatient = (int)dbMeasures.IdPatient,
                IdDiagnosis = (int)dbMeasures.IdDiagnosis
            }; 
        }

        public static MealPlan ConvertMealPlan(MealPlans dbMealPlan, List<Meal> meals)
        {
            return new MealPlan
            {
                IdMealPlan = dbMealPlan.IdMealPlan,
                Comments = dbMealPlan.Comments,
                PlanDescription = dbMealPlan.PlanDescription,
                PlanDate = (DateTime)dbMealPlan.PlanDate,
                Recommendations = dbMealPlan.Recommendations,
                IdPatient = (int)dbMealPlan.IdPatient,
                Meals = meals
            };
        }

        public static Meal ConvertMeal(Meals dbMeal)
        {
            return new Meal
            {
                IdMeal = dbMeal.IdMeal,
                MealType = dbMeal.MealType, 
                Equivalences = dbMeal.Equivalences,
                MealExamples = dbMeal.MealExamples,
                IdMealPlan = (int)dbMeal.IdMealPlan
            };
        } 

    }
}