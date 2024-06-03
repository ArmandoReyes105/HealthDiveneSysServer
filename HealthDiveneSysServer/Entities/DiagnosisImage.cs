using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace HealthDiveneSysServer.Entities
{
    [DataContract]
    public class DiagnosisImage
    {
        [DataMember]
        public int IdImage {  get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public byte[] Image { get; set; }

        [DataMember]
        public int IdDiagnosis {  get; set; }

    }
}