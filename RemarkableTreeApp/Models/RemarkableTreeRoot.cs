using System;
using System.Collections.Generic;

namespace RemarkableTreeApp.Models
{
    public class Fields
    {
        public List<double> geom_x_y { get; set; }
        public string libellefrancais { get; set; }
        public int objectid { get; set; }
        public string idemplacement { get; set; }
        public string domanialite { get; set; }
        public string typeemplacement { get; set; }
        public double hauteurenm { get; set; }
        public string espece { get; set; }
        public string adresse { get; set; }
        public string arrondissement { get; set; }
        public string pepiniere { get; set; }
        public string stadedeveloppement { get; set; }
        public string remarquable { get; set; }
        public double idbase { get; set; }
        public double noteetatphyto { get; set; }
        public string genre { get; set; }
        public string complementadresse { get; set; }
        public double circonferenceencm { get; set; }
        public string dateplantation { get; set; }
        public string varieteoucultivar { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class RemarkableTreeRoot
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public Fields fields { get; set; }
        public Geometry geometry { get; set; }
        public DateTime record_timestamp { get; set; }
    }

}
