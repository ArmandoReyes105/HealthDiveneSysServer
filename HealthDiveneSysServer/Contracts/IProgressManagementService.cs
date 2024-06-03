using HealthDiveneSysServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HealthDiveneSysServer
{
    [ServiceContract]
    public interface IProgressManagementService
    {
        [OperationContract]
        int AddNewDiagnosis(Diagnosis diagnosis);

        [OperationContract]
        Diagnosis GetLastDiagnosis(int patientId);

        [OperationContract]
        List<Diagnosis> GetDiagnosisByPatient(int patientId); 

        [OperationContract]
        int UpdateDiagnosis(Diagnosis diagnosis);

        [OperationContract]
        int UpdateMeasures(Measure measure);

        [OperationContract]
        int UpdateBodyComposition(Entities.BodyCompositions bodyCompositions);

        [OperationContract]
        List<Measure> GetMeasuresByPatient(int patientId); 
    }
}
