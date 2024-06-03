using HealthDiveneSysServer.Entities;
using HealthDiveneSysServer.Model;

namespace HealthDiveneSysServer.Converters
{
    public static class EntityToDBEntity
    {

        public static People Convert(Person person)
        {

            People dbPerson = new People
            {
                IdPerson = person.IdPerson,
                Names = person.Names,
                FirstLastName = person.FirstLastName,
                SecondLastName = person.SecondLastName,
                Phone = person.Phone,
                Email = person.Email
            };

            return dbPerson;

        }

        public static Patients Convert(Patient patient)
        {
            Patients dbPatient = new Patients
            {
                IdPatient = patient.IdPatient,
                Height = patient.Height,
                Birthdate = patient.Birthday, 
                Gender = patient.Gender,
                IdPerson = patient.Person.IdPerson, 
                IdNutritionist = patient.Nutritionist
            };

            return dbPatient; 
        }

        public static Model.MedicalInformation Convert(Entities.MedicalInformation medicalInformation) 
        {
            Model.MedicalInformation dbMedicalInformation = new Model.MedicalInformation
            {
                IdMedicalInformation = medicalInformation.IdMedicalInformation,
                ChronicDiseases = medicalInformation.ChronicDiseases,
                HereditaryFamilyHistory = medicalInformation.HereditaryFamilyHistory,
                GastrointestinalDiseases = medicalInformation.GastrointestinalDiseases,
                FoodAllergies = medicalInformation.FoodAllergies, 
                NOFoodAllergies = medicalInformation.NonFoodAllergies, 
                SurgicalHistory = medicalInformation.SurgicalHistory,
                Medications = medicalInformation.Medications,
                GeneralMedicalComments = medicalInformation.GeneralMedicalComments
            }; 

            return dbMedicalInformation; 
        }

        public static Model.GeneralInformation Convert(Entities.GeneralInformation generalInformation)
        {
            Model.GeneralInformation dbGeneralInformation = new Model.GeneralInformation
            {
                IdGeneralInformation = generalInformation.IdGeneralInformation,
                PhysicalActivity = generalInformation.PhysicalActivity,
                PhysicalActivityComments = generalInformation.PhysicalActivityComments,
                FavoriteFoods = generalInformation.FavoriteFoods,
                NonFavoriteFoods = generalInformation.NonFavoriteFoods,
                DietarySupplements = generalInformation.DietarySupplements,
                NutritionalFamiliarity = generalInformation.NutritionalFamiliarity,
                EatingEmotionalBehavior = generalInformation.EatingEmotionalBehavior,
                GeneralComments = generalInformation.GeneralComments,
                
            };

            return dbGeneralInformation; 
        }

        public static Model.HabitsAndGoals Convert(Entities.HabitsAndGoals habitsAndGoals)
        {
            Model.HabitsAndGoals dbHabitsAndGoals = new Model.HabitsAndGoals
            {
                IdHabitsAndGoals = habitsAndGoals.IdHabitsAndGoals,
                Caffeine = habitsAndGoals.Caffeine,
                Alcohol = habitsAndGoals.Alcohol,
                Cigarette = habitsAndGoals.Cigarette,
                Drugs = habitsAndGoals.Drugs,
                HealthGoals = habitsAndGoals.HealthGoals,
                SpecificNutritionalGoals = habitsAndGoals.SpecificNutritionalGoals,
                Expectations = habitsAndGoals.Expectations,
                GeneralComments = habitsAndGoals.GeneralComment
            };

            return dbHabitsAndGoals;
        }

        public static Model.Appointment Convert(Entities.Appointment appointment)
        {
            Model.Appointment dbAppointment = new Model.Appointment();
            dbAppointment.IdAppointment = appointment.IdAppointment;
            dbAppointment.AppointmentDate = appointment.AppointmentDate;
            dbAppointment.StartTime = appointment.StartTime; 
            dbAppointment.EndTime = appointment.EndTime;
            dbAppointment.IdPatient = appointment.IdPatient;
            dbAppointment.IdNutritionist = appointment.IdNutritionist;
            
            return dbAppointment;
        }

        public static Model.Diagnoses ConvertDiagnoses(Entities.Diagnosis diagnosis)
        {
             return new Diagnoses
            {
                IdDiagnosis = diagnosis.IdDiagnosis,
                DiagnosisDate = diagnosis.DiagnosisDate,
                PhysicalActivity = diagnosis.PhysicalActivity,
                PhysicalPerception = diagnosis.PhysicalPerception,
                Feeding = diagnosis.Feeding,
                Appetite = diagnosis.Appetite,
                WaterConsumption = diagnosis.WaterConsumption,
                Dream = diagnosis.Dream,
                StomachUpset = diagnosis.StomachUpset,
                EnergyLevel = diagnosis.EnergyLevel,
                StressLevel = diagnosis.StressLevel,
                SubstanceUse = diagnosis.SubstanceUse, 
                GeneralComments = diagnosis.GeneralComments,
                IdPatient = diagnosis.PatientId, 
            };
            
        }

        public static Model.Measures ConvertMeasures(Measure measure)
        {
            return new Measures
            {
                IdMeasures = measure.IdMeasure, 
                Chest = measure.Chest,
                Arm = measure.Arm,
                ContractedArm = measure.ContractedArm,
                Forearm = measure.Forearm,
                Waist = measure.Waist,
                Hip = measure.Hip,
                Thigh = measure.Thigh,
                Calf = measure.Calf, 
                IdPatient = measure.IdPatient, 
                IdDiagnosis = measure.IdDiagnosis,
            }; 
        }

        public static Model.BodyCompositions ConvertBodyComposition(Entities.BodyCompositions bodyCompositions)
        {
            return new Model.BodyCompositions
            {
                IdBodyComposition = bodyCompositions.IdBodyComposition,
                VisceralFat = bodyCompositions.VisceralFat,
                TotalWeight = bodyCompositions.TotalWeight,
                WaterPercentage = bodyCompositions.WaterPercentage,
                FatPercentage = bodyCompositions.FatPercentage,
                MusclePercentage = bodyCompositions.MusclePercentage,
                IdPatient = bodyCompositions.IdPatient,
                IdDiagnosis = bodyCompositions.IdDiagnosis,
            };
        }

        public static MealPlans ConvertMealPlan(MealPlan plan)
        {
            return new MealPlans
            {
                IdMealPlan = plan.IdMealPlan,
                Comments = plan.Comments,
                PlanDescription = plan.PlanDescription,
                PlanDate = plan.PlanDate,
                Recommendations = plan.Recommendations,
                IdPatient = plan.IdPatient
            };
        }

        public static Meals ConvertMeal(Meal meal)
        {
            return new Meals
            {
                IdMeal = meal.IdMeal,
                MealType = meal.MealType,
                Equivalences = meal.Equivalences,
                MealExamples = meal.MealExamples,
                IdMealPlan = meal.IdMealPlan,
            };
        }
    }
}